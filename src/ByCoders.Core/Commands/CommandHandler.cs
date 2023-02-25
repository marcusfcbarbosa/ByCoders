using ByCoders.Core.Data;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ByCoders.Core.Commands
{
    public abstract class CommandHandler
    {
        protected ValidationResult _validationResult;
        protected CommandHandler()
        {
            _validationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            _validationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("There was an error persisting the data");

            return _validationResult;
        }
    }
}
