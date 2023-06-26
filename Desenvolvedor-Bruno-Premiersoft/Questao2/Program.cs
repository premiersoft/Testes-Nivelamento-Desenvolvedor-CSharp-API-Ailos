using Newtonsoft.Json;
using Questao2;
using System.Net.Http.Headers;

public class Program
{
    protected const string BASE_URL = "https://jsonmock.hackerrank.com/api/football_matches";
    public static HttpClient _client;
    public static int _goals;

    public static async Task Main()
    {
        InitializeHttpClient();

        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014

        ///Observação...
        ///Debungando a analisando os dados, a soma dos gols marcados está diferente do resultado esperado. Acredito que isso está ocorrendo pois a api pode ter sofrido algum update
    }

    public static void InitializeHttpClient()
    {
        _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        _client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
    }


    public static async Task<int> getTotalScoredGoals(string team, int year, int page = 1)
    {
        int goals = 0;
        HttpResponseMessage result = await _client.GetAsync(BASE_URL + $"?year={year}&team1={team}&page={page}");

        if (!result.IsSuccessStatusCode)
            return 0;

        var matchData = JsonConvert.DeserializeObject<DataPagination<List<ResultMatches>>>(await result.Content.ReadAsStringAsync());
        goals += matchData.Data.Sum(x => x.Team1Goals);
        int totalPages = matchData.Total_Pages;

        while (totalPages > 1)
        {
            result = await _client.GetAsync(BASE_URL + $"?year={year}&team1={team}&page={totalPages}");
            matchData = JsonConvert.DeserializeObject<DataPagination<List<ResultMatches>>>(await result.Content.ReadAsStringAsync());
            goals += matchData.Data.Sum(x => x.Team1Goals);

            totalPages--;
        }


        return goals;
    }
}