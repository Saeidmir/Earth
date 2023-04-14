using Earth.Samples.Core.Contracts.People.Commands;
using Earth.Samples.Core.Domain;
using Earth.Samples.Core.Domain.People.ValueObjects;
using FluentValidation;
using Zamin.Extentions.Translations.Abstractions;

namespace Earth.Samples.Core.ApplicationServices.People.Commands.CreatePersonHandler;

public class CreatePersonValidator:AbstractValidator<CreatePerson>
{
    public CreatePersonValidator(ITranslator translator)
    {
        /// This is a Validation about Person FirstName
        RuleFor(c => c.FirstName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, Messages.FirstName]);
        
    }
}