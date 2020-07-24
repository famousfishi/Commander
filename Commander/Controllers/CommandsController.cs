using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Dtos;
using Commander.MockRepository;
using Commander.Models;
using Commander.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




        //GET all commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }


        //GET a command by ID
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommand(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }


        //Post a COMMAND
        [HttpPost]
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
        {

            var commandModel = _mapper.Map<Command>(commandCreateDto);

            if (commandModel == null)
            {
                return BadRequest(nameof(commandModel));
            }
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);
            //return Ok(commandReadDto);

            return CreatedAtRoute(nameof(GetCommandById), new {commandReadDto.Id }, commandReadDto);

        }


        //Update a command
        [HttpPut("{id}")]

        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommand(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }
            
    }
}
