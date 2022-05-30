using ChallengeAlkemy.BusinessLogic;
using ChallengeAlkemy.Data;
using ChallengeAlkemy.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChallengeAlkemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeliculaController : ControllerBase
    {


        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(PeliculaRepositoryAdmin.GetPeliculas());
        }



        [HttpGet]
        [Route("Details")]
        public ActionResult GetDetails(int id)
        {
            return Ok(PeliculaRepositoryAdmin.GetDetails(id));
        }
        [HttpGet]
        [Route("PorNombre")]
        public ActionResult GetDetails(string name)
        {
            return Ok(PeliculaRepositoryAdmin.GetPeliculaPorNombre(name));
        }

        [HttpGet]
        [Route("Ordenada")]
        public ActionResult GetOrdenada(string order)
        {
            return Ok(PeliculaRepositoryAdmin.GetPeliculaOrdenada(order));
        }


        [HttpPost]

        public ActionResult InsertOrUpdate(Pelicula model)
        {
            PeliculaRepositoryAdmin.InsertOrUpdate(model);

            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            PeliculaRepositoryAdmin.Delete(id);

            return Ok("Se borro correctamente el registro");
        }
    }

}
