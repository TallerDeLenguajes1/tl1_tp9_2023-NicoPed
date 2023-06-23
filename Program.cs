using ClaseBitCoins;
internal class Program
{
    private static void Main(string[] args)
    {
        PrecioBitcoin obtenerBTC;
        obtenerBTC = ConsumirAPI();

    }
    PrecioBitcoin ConsumirAPI(){
        
        var hola = new PrecioBitcoin();
        return hola;
    }
}