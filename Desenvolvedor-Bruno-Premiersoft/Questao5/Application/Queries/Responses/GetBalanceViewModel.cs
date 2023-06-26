namespace Questao5.Application.Queries.Responses
{
    public class GetBalanceViewModel
    {
        public string Saldo { get; set; }

        public int Numero { get; set; }

        public string Nome { get; set; }

        public string DataHoraConsulta { get; set; }


        public GetBalanceViewModel()
        {
            DataHoraConsulta = DateTime.Now.ToString();
        }
    }
}
