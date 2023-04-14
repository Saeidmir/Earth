﻿using Earth.Infra.Data.Sql.Commands;
using Earth.Samples.Core.Contracts.People.Commands;
using Earth.Samples.Core.Domain.People.Entities;
using Earth.Samples.Infra.Data.SqlCommands.Common;

namespace Earth.Samples.Infra.Data.SqlCommands.People;

public class PersonCommandRepository:BaseCommandRepository<Person,SampleCommandDbContext>,IPersonCommandRepository
{
    public PersonCommandRepository(SampleCommandDbContext dbContext) : base(dbContext)
    {
    }
}