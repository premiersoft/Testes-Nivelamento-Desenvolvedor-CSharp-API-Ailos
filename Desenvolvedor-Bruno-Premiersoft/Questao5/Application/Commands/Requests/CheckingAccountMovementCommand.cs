using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class CheckingAccountMovementCommand:IRequest<CheckingAccountMovementResponse>
    {
        public string MovementType { get; set; } = "";

        public int Number { get; set; }

        public decimal Value { get; set; }

        public CheckingAccountMovementCommand()
        {
        }
    }
}
