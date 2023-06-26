using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class Movement
    {
        public Guid Id{ get; set; }
        public virtual Guid IdCheckingAccount { get; set; }
        public virtual CheckingAccount CheckingAccount { get; set; } 
        public DateTime MovementTime { get; set; } 
        public string MovementType { get; set; }
        public decimal Valor { get; set; }

        public MovementTypeEnum MovementTypeEnum
        {
            get
            {
                if (MovementType.Trim() == "C")
                    return MovementTypeEnum.Credito;
                else
                    return MovementTypeEnum.Debito;
            }
        }

        public Movement()
        {
            CheckingAccount = new CheckingAccount();
            MovementTime = new DateTime();
            MovementType = string.Empty;
        }
    }
}
