using Fitness.Application.Modules.TreinoOps.Commands;

namespace Fitness.UnitTests.Modules.TreinoOps.Commands;

public class TesteCommandTests
{
    [Fact]
    public void Validator_DeveAceitarNomeValido()
    {
        // Arrange
        var command = new TesteCommand("Treino de pernas");

        var validator = new TesteCommand.Validator();

        // Act
        var resultado = validator.Validate(command);

        // Assert
        Assert.True(resultado.IsValid);
    }

    [Fact]
    public void Validator_DeveRejeitarNomeVazio()
    {
        // Arrange
        var command = new TesteCommand("");

        var validator = new TesteCommand.Validator();

        // Act
        var resultado = validator.Validate(command);

        // Assert
        Assert.False(resultado.IsValid);
        Assert.Contains(
            resultado.Errors,
            erro => erro.ErrorMessage == "O nome é obrigatório.");
    }

    [Fact]
    public void Validator_DeveRejeitarNomeComMenosDeDoisCaracteres()
    {
        // Arrange
        var command = new TesteCommand("A");

        var validator = new TesteCommand.Validator();

        // Act
        var resultado = validator.Validate(command);

        // Assert
        Assert.False(resultado.IsValid);
        Assert.Contains(
            resultado.Errors,
            erro => erro.ErrorMessage == "O nome deve ter pelo menos 2 caracteres.");
    }

}