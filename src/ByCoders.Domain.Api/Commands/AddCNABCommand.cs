using ByCoders.Core.Commands;
using ByCoders.Domain.Api.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ByCoders.Domain.Api.Commands
{
    public class AddCNABCommand : Command
    {
        public string File { get; set; }
        public override bool Valid()
        {
            return base.Valid();
        }


        public class AddCNABValidation : AbstractValidator<AddCNABCommand>
        {
            public AddCNABValidation()
            {
                RuleFor(c => c.File)
                    .NotEmpty()
                    .WithMessage("Invalid value file")
                    .NotNull()
                    .WithMessage("Invalid value file");
            }
        }


        public class AddCNABCommandHandler : CommandHandler,
            IRequestHandler<AddCNABCommand, ValidationResult>
        {

            private readonly ITituloRepository _tituloRepository;

            public AddCNABCommandHandler(ITituloRepository tituloRepository)
            {
                _tituloRepository = tituloRepository;
            }

            public async Task<ValidationResult> Handle(AddCNABCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
