using ChallengeAlkemy.BusinessLogic;
using ChallengeAlkemy.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeAlkemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajeController : ControllerBase
    {
         


        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(PersonajeRepositoryAdmin.GetPersonajes());
        }



        [HttpGet]
        [Route("Details")]
        public ActionResult GetDetails(int id)
        {
            return Ok(PersonajeRepositoryAdmin.GetDetails(id));
        }

        [HttpGet]
        [Route("PorNombre")]
        public ActionResult GetDetails(string name)
        {
            return Ok(PersonajeRepositoryAdmin.GetPersonajePorNombre(name));
        }

        [HttpGet]
        [Route("PorEdad")]
        public ActionResult GetOrdenada(int edad)
        {
            return Ok(PersonajeRepositoryAdmin.GetPersonajePorEdad(edad));
        }


        [HttpPost]

        public ActionResult InsertOrUpdate(Personaje model)
        {
            PersonajeRepositoryAdmin.InsertOrUpdate(model);

            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            PersonajeRepositoryAdmin.Delete(id);

            return Ok("Se borro correctamente el registro");
        }
    }
}
