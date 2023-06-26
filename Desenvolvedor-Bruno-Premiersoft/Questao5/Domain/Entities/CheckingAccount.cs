namespace Questao5.Domain.Entities
{
    public class CheckingAccount
    {
        public CheckingAccount()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = "";
        public bool IsActive { get; set; }
        public virtual List<Movement> Movimentos { get; set; } = new List<Movement>();
    }
}
