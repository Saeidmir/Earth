using Earth.Core.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Commands;
using Earth.Samples.Core.Contracts.People.Commands;
using Earth.Samples.Core.Domain.People.Entities;
using Earth.Utilities;

namespace Earth.Samples.Core.ApplicationServices.People.Commands.CreatePersonHandler;

public class CreatePersonHandler : CommandHandler<CreatePerson, long>
{
    private readonly IPersonCommandRepository _repository;

    public CreatePersonHandler(EarthAttachedServices services, IPersonCommandRepository repository) : base(services)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<long>> Handle(CreatePerson request)
    {
        Person person = new Person(new(request.FirstName), new(request.LastName));
        await _repository.InsertAsync(person);
        await _repository.CommitAsync();

        return Ok(person.Id);
    }
}