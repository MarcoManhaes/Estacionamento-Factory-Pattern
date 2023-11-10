using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Service;
using EstacionamentoApp.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EstacionamentoApp;

try
{
    int vagasMoto, vagasCarro, vagasVan;
    ConfiguirarEstacionamento(out vagasMoto, out vagasCarro, out vagasVan);

    using IHost _host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((services) =>
    {
        services.AddSingleton<Client>();
        services.AddScoped<SelecionaServico>();
        services.AddSingleton<Estacionamento>(provider =>
        {
            return new Estacionamento(vagasMoto, vagasCarro, vagasVan);
        });
    }).Build();

    var app = _host.Services.GetRequiredService<Client>();
    app.ExecutaCriacaoServico();
}
catch (Exception)
{
    Console.WriteLine("='(\n");
    Console.WriteLine("Ops! Infelizmente eu não realizei validações para entradas diferentes de números.\n");
}

static void ConfiguirarEstacionamento(out int vagasMoto, out int vagasCarro, out int vagasVan)
{
    Console.WriteLine("Vamos configurar a quantidade de vagas do estacionamento:");
    Console.WriteLine("Observação: Eu não realizei validações para entradas diferentes de números. Não era o objetivo !!!\n");
    Console.WriteLine("Quantas vagas para as Motos?");
    vagasMoto = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Quantas vagas para os Carros?");
    vagasCarro = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Quantas vagas para as Vans?");
    vagasVan = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Quantidade de vagas do estacionamento configurada com sucesso!\n");
}




