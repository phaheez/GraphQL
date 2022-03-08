using GraphQL.Data;
using GraphQL.Models;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.GraphQL.Platforms
{
    public class PlatformType: ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface");

            descriptor.Field(x => x.LicenseKey).Ignore();

            descriptor.Field(x => x.Commands)
                        .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                        .UseDbContext<AppDbContext>()
                        .Description("This is the list of available commands for this plaform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(x => x.PlatformId == platform.Id);
            }
        }
    }
}
