using Commander.AppDbContext;
using Commander.Models;
using Commander.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.MockRepository
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommandContext _context;

        public SqlCommanderRepo(CommandContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentException(nameof(command));

            _context.Commands.Add(command);

            
        }

        public Command GetCommand(int id)
        {
            var commandItem = _context.Commands.FirstOrDefault(p => p.Id == id);
            return commandItem;
        }

        public IEnumerable<Command> GetCommands()
        {
            var commandItems = _context.Commands.ToList();
            return commandItems;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            //Returns nothing
        }
    }
}
