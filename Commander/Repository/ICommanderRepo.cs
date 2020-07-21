using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Repository
{
    public interface ICommanderRepo
    {
        bool SaveChanges();

        //list of commands
        IEnumerable<Command> GetCommands();

        //get command by Id
        Command GetCommand(int id);

        //Create a command Resource
        void CreateCommand(Command command);

        //Update a command resource
        void UpdateCommand(Command command);


    }
}
