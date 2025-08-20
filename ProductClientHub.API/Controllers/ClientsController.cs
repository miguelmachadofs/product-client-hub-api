using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Delete;
using ProductClientHub.API.UseCases.Clients.GetAll;
using ProductClientHub.API.UseCases.Clients.GetById;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.API.UseCases.Clients.Update;
using ProductClientHub.Communication.Request;
using ProductClientHub.Communication.Response;

namespace ProductClientHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        /* Swagger */
        // Descreve o Json de retorno e o Status Code correto para cada caso
        [ProducesResponseType(typeof(ResponseShortClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            var useCase = new RegisterClientUseCase();

            var response = useCase.Execute(request: request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Update([FromRoute] Guid id, [FromBody] RequestClientJson request)
        {
            var useCase = new UpdateClientUseCase();

            useCase.Execute(clientId: id, request: request);

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllClientsJson), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllClientsUseCase();

            var response = useCase.Execute();

            return Ok(response);
        }

        /* Outra forma de informar ao navegador que esse Get recebe um Id, ao contrário do de cima, para que ele saiba qual dos dois chamar
         * [HttpGet("id")]
         */
        // Forma de deixar obrigatório informar esse parâmetro na própria rota/url da requisição:
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseClientJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var useCase = new GetClientByIdUseCase();

            var response = useCase.Execute(clientId: id);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var useCase = new DeleteClientUseCase();

            useCase.Execute(clientId: id);

            return NoContent();
        }
    }
}
