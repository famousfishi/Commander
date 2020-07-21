using Commander.Models;
using Commander.Repository;
using System.Collections.Generic;

namespace Commander.MockRepository
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public Command GetCommand(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Tear open a Lion's mouth", Platform = "ASP.net core 3.1" };
        }

        public IEnumerable<Command> GetCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Tear open a Lion's mouth", Platform = "ASP.net core 3.1" },
                new Command { Id = 1, HowTo = "Read a book", Line = "Tear open a Lion's mouth", Platform = "ASP.net core 3.1" },
                new Command { Id = 2, HowTo = "Learn how to code", Line = "Tear open a Lion's mouth", Platform = "ASP.net core 3.1" },
                new Command { Id = 3, HowTo = "Learn how to date a girl", Line = "Tear open a Lion's mouth", Platform = "ASP.net core 3.1" },
            };

            return commands;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}