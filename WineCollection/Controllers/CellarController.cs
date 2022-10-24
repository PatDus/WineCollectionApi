using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCollection.Entities;
using WineCollection.Models;
using WineCollection.Services;

namespace WineCollection.Controllers
{
    [Route($"api/cellar")]
    [ApiController]
    [Authorize]


    public class CellarController : ControllerBase
    {
        private readonly ICellarService _cellarService;


        public CellarController(ICellarService cellarService)
        {
            _cellarService = cellarService;
        }




        [HttpPost]
        public ActionResult<WineCellar> CreateCellar([FromBody] CreateCellarDto dto)
        {
            int id = _cellarService.Create(dto);

            return Created($"/api/cellar/{id}", null);
        }

        [HttpGet("{id}")]
        public ActionResult<WineCellar> GetCellar([FromRoute] int id)
        {

            var cellar = _cellarService.Get(id);

            return Ok(cellar);
        }

        [HttpGet]

        public ActionResult<CellarDto> GetAllCellars()
        {
            List<CellarDto> cellars = _cellarService.GetAll();

            return Ok(cellars);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCellar([FromRoute] int id)
        {

            _cellarService.DeleteById(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCellar([FromRoute] int id)
        {
            _cellarService.UpdateCellar(id);
            return Ok();
        }
    }
}
