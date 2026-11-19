using MediatR;

namespace Fitness.Application.Modules.TreinoOps.Commands.TesteCommand;

public record TesteCommand(string Nome) : IRequest<string>;