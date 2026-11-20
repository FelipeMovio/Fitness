
using Fitness.Application.DependencyInjectionConfig;
using Fitness.Application.Modules.TreinoOps.Commands;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Fitness.UnitTests.Modules.TreinoOps.Commands;

public class TesteCommandPipelineTests
{
    private readonly IServiceProvider _serviceProvider;

    public TesteCommandPipelineTests()
    {
        var services = new ServiceCollection();

        services.AddLogging();
        services.AddApplication();

        var serviceProvider = services.BuildServiceProvider();

        _serviceProvider = serviceProvider;
    }
    [Fact]
    public async Task MediatR_DeveExecutarHandlerQuandoCommandForValido()
    {
        // Arrange
        var mediator = _serviceProvider
            .GetRequiredService<MediatR.IMediator>();

        var command = new TesteCommand("Treino de pernas");

        // Act
        var resposta = await mediator.Send(command);

        // Assert
        Assert.Equal(
            "Command recebido com sucesso! Nome: Treino de pernas",
            resposta);
    }

    [Fact]
    public async Task MediatR_DeveImpedirHandlerQuandoCommandForInvalido()
    {
        // Arrange
        var mediator = _serviceProvider
            .GetRequiredService<MediatR.IMediator>();

        var command = new TesteCommand("");

        // Act e Assert
        await Assert.ThrowsAsync<ValidationException>(
            () => mediator.Send(command));
    }
}
