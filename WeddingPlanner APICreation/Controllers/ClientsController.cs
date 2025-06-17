using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_API.Data;
using WeddingPlanner_APICreation.Models;

namespace WeddingPlanner_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientsRepository _clientRepository;

        public ClientsController(ClientsRepository clientsRepository)
        {
            _clientRepository = clientsRepository;
        }

        // This ClientsController is used for calling methods from ClientRepository

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _clientRepository.SelectAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            var client = _clientRepository.SelectByPK(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var isDeleted = _clientRepository.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertClient([FromBody] ClientsModel client)
        {
            if (client == null)
                return BadRequest();

            bool isInserted = _clientRepository.Insert(client);
            if (isInserted)
                return Ok(new { Message = "Client Inserted Successfully!" });

            return StatusCode(500, "An error occurred while inserting the client");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientsModel client)
        {
            if (client == null || id != client.ClientID)
                return BadRequest();

            var isUpdated = _clientRepository.Update(client);
            if (!isUpdated)
                return NotFound();

            return NoContent();
        }
    }
}
