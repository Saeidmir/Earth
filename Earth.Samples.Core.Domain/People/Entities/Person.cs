
using Earth.Core.Domain.Entities;
using Earth.Core.Domain.Exceptions;
using Earth.Samples.Core.Domain.People.Events;
using Earth.Samples.Core.Domain.People.ValueObjects;

namespace Earth.Samples.Core.Domain.People.Entities;

public class Person:AggregateRoot
{
    #region Properties
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    #endregion

    public Person( FirstName firstName, LastName lastName)
    {
        // this is not useful
        // if (id == 0)
        //     throw new InvalidEntityStateException(Messages.InvalidNumberValueRange, "1");
        FirstName = firstName;
        LastName = lastName;
        AddEvent(new PersonCreated(BusinessId.Value, firstName.Value,lastName.Value));
    }   
}