
using MediatR;

namespace Fitness.Application.Modules.TreinoOps.Commands;

public sealed record TesteCommand(string Nome) : IRequest<string>
{
    public sealed class Handler
        : IRequestHandler<TesteCommand, string>
    {
        public Task<string> Handle(
            TesteCommand request,
            CancellationToken cancellationToken)
        {
            string mensagem =
                $"Command recebido com sucesso! Nome: {request.Nome}";

            return Task.FromResult(mensagem);
        }
    }
}
