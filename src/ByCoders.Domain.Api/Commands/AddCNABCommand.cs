using ByCoders.Core.Commands;
using ByCoders.Core.Extensions;
using ByCoders.Domain.Api.Entities;
using ByCoders.Domain.Api.Repositories;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace ByCoders.Domain.Api.Commands
{
    public class AddCNABCommand : Command
    {
        public string File { get; set; }
        public override bool Valid()
        {
            validationResult = new AddCNABValidation().Validate(this);
            return validationResult.IsValid;
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
                if (!request.Valid()) return request.validationResult;
                var titulos = MappTitulo(request.File);
                titulos.ForEach(x => _tituloRepository.Add(x));
                return await PersistData(_tituloRepository.UnitOfWork);
            }


            private List<Titulo> MappTitulo(string cnab)
            {
                var listaTitulos = new List<Titulo>();
                string[] linhasCnab = cnab.Split('\n');

                linhasCnab.ForEach(x=> listaTitulos.Add(new Titulo(x)));
                return  listaTitulos;
            } 
        }
    }
}
