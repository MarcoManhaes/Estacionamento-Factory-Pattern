using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Service;
using EstacionamentoApp.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EstacionamentoApp;
using EstacionamentoApp.Util;

try
{
    int vagasMoto, vagasCarro, vagasVan;
    LogFluxoControleExecucao.ConfiguirarEstacionamento(out vagasMoto, out vagasCarro, out vagasVan);

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
    Console.WriteLine(Resource.msgTriste);
    Console.WriteLine(Resource.msgOps);
}






