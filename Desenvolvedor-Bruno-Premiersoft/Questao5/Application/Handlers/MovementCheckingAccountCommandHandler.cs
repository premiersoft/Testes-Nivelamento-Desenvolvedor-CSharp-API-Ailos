using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Language;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.CrossCutting;
using AutoMapper;

namespace Questao5.Application.Handlers
{
    public class MovementCheckingAccountCommandHandler : IRequestHandler<CheckingAccountMovementCommand, CheckingAccountMovementResponse>
    {
        private readonly IBaseRepository<CheckingAccount> _checkingAccountRepository;
        private readonly IBaseRepository<Movement> _movementRepository;
        private readonly List<Notifications> _notifications;
        private readonly ILanguageSystem _languageSystem;
        private readonly IMapper _mapper;

        public MovementCheckingAccountCommandHandler(IBaseRepository<CheckingAccount> CheckingAccountRepository,
                                                     IBaseRepository<Movement> MovementRepository,
                                                     List<Notifications> Notifications,
                                                     ILanguageSystem LanguageSystem,
                                                     IMapper mapper)
        {
            _checkingAccountRepository = CheckingAccountRepository;
            _movementRepository = MovementRepository;
            _notifications = Notifications ?? new List<Notifications>();
            _languageSystem = LanguageSystem;
            _mapper = mapper;
        }

        public async Task<CheckingAccountMovementResponse> Handle(CheckingAccountMovementCommand request, CancellationToken cancellationToken)
        {
            var resp = new CheckingAccountMovementResponse();

            var contaCorrente = await MovimentIsValid(request);
            if (_notifications.Any())
                return resp;

            var movimentoAdd = _mapper.Map<Movement>(request);

            if (contaCorrente is not null)
            {
                movimentoAdd.IdCheckingAccount = contaCorrente.Id;
                _movementRepository.Add(movimentoAdd);
            }


            await _movementRepository.UnitOfWork.CommitAsync();
            return resp;
        }

        private async Task<CheckingAccount?> MovimentIsValid(CheckingAccountMovementCommand request)
        {

            string[] tipoMovimentoValid = { "C", "D" };

            if (request.Value <= 0)
                _notifications.Add(new Notifications { Message = _languageSystem.InvalidValue() });

            var numeroConta = request.Number;

            CheckingAccount? contaCorrente = await CurrentAccountIsValid(numeroConta);

            if (!tipoMovimentoValid.Any(x => x == request.MovementType))
                _notifications.Add(new Notifications { Message = _languageSystem.InvalidType() });

            return contaCorrente;
        }

        private async Task<CheckingAccount?> CurrentAccountIsValid(int numeroConta)
        {
            var contaCorrente = (await _checkingAccountRepository.RepositoryConsult.SearchAsync(x => x.Number == numeroConta, true))
                                  ?.FirstOrDefault();

            if (contaCorrente is null)
                _notifications.Add(new Notifications { Message = _languageSystem.InvalidAccount() });

            if (contaCorrente is not null
                              && !contaCorrente.IsActive)
                _notifications.Add(new Notifications { Message = _languageSystem.InactiveAccount() });
            return contaCorrente;
        }
    }
}
