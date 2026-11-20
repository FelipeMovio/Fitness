
using FluentValidation;
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

    public sealed class Validator : AbstractValidator<TesteCommand>
    {
        public Validator()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.")
                .MinimumLength(2)
                .WithMessage("O nome deve ter pelo menos 2 caracteres.")
                .MaximumLength(100)
                .WithMessage("O nome deve ter no máximo 100 caracteres.");
        }
    }
}
