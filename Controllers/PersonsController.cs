using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CadastroAPI.Data;
using CadastroAPI.Model;
using System.Globalization;

namespace CadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonsController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            List<Person> persons = _context.Persons.ToList();

            if (persons.Count == 0)
            {
                var errorMessage = "Nenhuma pessoa encontrada.";
                return NotFound(new { Message = errorMessage });
            }

            return Ok(persons);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
            {
                var errorMessage = "Pessoa não encontrada.";
                return NotFound(new { Message = errorMessage });
            }

            return person;
        }

        [HttpPost]
        public ActionResult<Person> CreatePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();

            var successMessage = "Pessoa adicionada com sucesso.";
            return CreatedAtAction(nameof(GetPerson), new { id = person.PersonID }, new { Message = successMessage, PersonDetails = person });
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            if (id != person.PersonID)
            {
                return BadRequest("IDs não correspondem.");
            }

            var existingPerson = _context.Persons.Find(id);

            if (existingPerson == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            existingPerson.Nome = person.Nome;
            existingPerson.Endereco = person.Endereco;
            existingPerson.Cidade = person.Cidade;
            existingPerson.Telefone = person.Telefone;
            existingPerson.CPF = person.CPF;

            _context.SaveChanges();

            return Ok("Pessoa atualizada com sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = _context.Persons.Find(id);

            if (person == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            _context.Persons.Remove(person);
            _context.SaveChanges();

            return Ok("Pessoa excluída com sucesso.");
        }
    }
}
