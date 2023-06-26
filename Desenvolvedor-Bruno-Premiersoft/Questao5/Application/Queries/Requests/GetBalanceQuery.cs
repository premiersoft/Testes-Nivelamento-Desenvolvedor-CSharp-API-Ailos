using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class GetBalanceQuery : IRequest<GetBalanceViewModel>
    {
        public int Numero { get; set; }

    }
}
