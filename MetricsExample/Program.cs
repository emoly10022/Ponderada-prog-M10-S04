using System.Diagnostics.Metrics;

class Program
{
    // Criando o medidor para monitorar vendas na floricultura
    static Meter s_meter = new Meter("Floricultura.Vendas");

    // Contadores para os tipos de buquês vendidos
    static Counter<int> s_rosesSold = s_meter.CreateCounter<int>("floricultura.vendas.rosas_vendidas");
    static Counter<int> s_tulipsSold = s_meter.CreateCounter<int>("floricultura.vendas.tulipas_vendidas");

    static void Main(string[] args)
    {
        int totalRosesSold = 0;  // Total de buquês de rosas vendidos
        int totalTulipsSold = 0; // Total de buquês de tulipas vendidos

        Console.WriteLine("Monitoramento de vendas da floricultura iniciado. Pressione qualquer tecla para sair.");

        Random random = new Random();

        // Simulação de vendas
        while (!Console.KeyAvailable)
        {
            Thread.Sleep(1000);

            // Simulando a venda de buquês de rosas
            int rosesSold = random.Next(1, 6); // Vende de 1 a 5 buquês de rosas
            s_rosesSold.Add(rosesSold);
            totalRosesSold += rosesSold;

            // Simulando a venda de buquês de tulipas
            int tulipsSold = random.Next(1, 4); // Vende de 1 a 3 buquês de tulipas
            s_tulipsSold.Add(tulipsSold);
            totalTulipsSold += tulipsSold;

            Console.WriteLine($"Buquês de Rosas vendidos: {totalRosesSold}, Buquês de Tulipas vendidos: {totalTulipsSold}");
        }

        Console.WriteLine("Monitoramento de vendas encerrado.");
    }
}
