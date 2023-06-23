using ClaseBitCoins;
using System.Net;
using System.Text.Json;
internal class Program
{
    private static void Main(string[] args)
    {
        PrecioBitcoin obtenerBTC;
        obtenerBTC = ConsumirAPI();
        Console.WriteLine (@"╔═══════════════════════════╗  ╔═══════════════════════════╗");
        Console.WriteLine (@$"║ {obtenerBTC.bpi.USD.description.PadRight(26)}║  ║ {obtenerBTC.bpi.EUR.description.PadRight(26)}║");
        Console.WriteLine (@"╠───────────────────────────╣  ╠───────────────────────────╣");
        Console.WriteLine (@$"║ {obtenerBTC.bpi.USD.rate.PadRight(26)}║  ║ {obtenerBTC.bpi.EUR.rate.PadRight(26)}║");
        Console.WriteLine (@"╚═══════════════════════════╝  ╚═══════════════════════════╝");
        Console.WriteLine (@"               ╔═══════════════════════════╗");
        Console.WriteLine (@$"               ║ {obtenerBTC.bpi.GBP.description.PadRight(26)}║");
        Console.WriteLine (@"               ╠───────────────────────────╣");
        Console.WriteLine (@$"               ║ {obtenerBTC.bpi.GBP.rate.PadRight(26)}║");
        Console.WriteLine (@"               ╚═══════════════════════════╝");
   
    }
    public static PrecioBitcoin ConsumirAPI(){
        var url = $"https://api.coindesk.com/v1/bpi/currentprice.json";
        var request = (HttpWebRequest)WebRequest.Create(url);

        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        PrecioBitcoin obtBTC = null;
        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader == null) return obtBTC;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd();
                        obtBTC = JsonSerializer.Deserialize<PrecioBitcoin>(responseBody);// como es un objeto y no una lista no se pone list
                    }
            }
        }
        return obtBTC;
    }
}