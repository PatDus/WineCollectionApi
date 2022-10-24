using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCollection.Models;
using WineCollection.Services;

namespace WineCollection.Controllers
{
    [Route("api/wine")]
    [ApiController]
    [Authorize]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteWine([FromRoute] int id)
        {
            _wineService.DeleteById(id);
            return NoContent();
        }

        [HttpPost("cellar/{wineCellarId}")]
        public ActionResult CreateWine([FromRoute] int wineCellarId, [FromBody] CreateWineDto dto)
        {

            int id = _wineService.Create(wineCellarId, dto);

            return Created($"/api/wine/{id}", null);
        }

        [HttpGet]
        public ActionResult<WineDto> GetAll()
        {
            var winesDtos = _wineService.GetAll();

            return Ok(winesDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<WineDto> Get([FromRoute] int id)
        {
            var wineDto = _wineService.GetById(id);
            return Ok(wineDto);
        }

        //not finished
        [HttpPut("{id}")]
        public ActionResult UpdateWine([FromRoute] int id, [FromRoute] int wineCellarId, [FromBody] UpdateWineDto dto)
        {
            _wineService.UpdateWine(id, wineCellarId, dto);

            return Ok();
        }

    }
}
