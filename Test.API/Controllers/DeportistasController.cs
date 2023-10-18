using AutoMapper;
using BusinessLayer.Services;
using DataLayer.DBContext;
using DataLayer.Repositories;
using EntitiesLayer.DTOs;
using EntitiesLayer.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Test.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Deportista")]
    public class DeportistasController : ApiController
    {
        private IMapper mapper;
        private readonly DeportistasService deportistasService = new DeportistasService(new DeportistaRepository(TestContext.Create()));

        public DeportistasController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet] 
        public async Task<IHttpActionResult> GetAllDeportista()
        {
            var deportistas = await deportistasService.GetAll();
            var deportistaDTO = deportistas.Select(x => mapper.Map<DeportistaDTO>(x));

            return Ok(deportistaDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByIdDeportista(int id) 
        {
            var course = await deportistasService.GetById(id);

            if (course == null)
                return NotFound();
            
            var courseDTO = mapper.Map<DeportistaDTO>(course);

            return Ok(courseDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertDeportista(DeportistaDTO deportistaDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var deportistas = mapper.Map<Deportistas>(deportistaDTO);
                deportistas = await deportistasService.Insert(deportistas);
                return Ok(deportistas);

            } 
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateDeportista(DeportistaDTO deportistaDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (deportistaDTO.ID != id)
                return BadRequest();

            var depid = await deportistasService.GetById(id);

            if (depid == null)
                return NotFound();
            try
            {
                var deportistas = mapper.Map<Deportistas>(deportistaDTO);
                deportistas = await deportistasService.Update(deportistas);

                return Ok(deportistas);

            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteDeportista(int id)
        {
            var depid = await deportistasService.GetById(id);

            if (depid == null)
                return NotFound();
            try
            {
                await deportistasService.Delete(id);
                return Ok();

            }
            catch (System.Exception ex)
            {


                return InternalServerError(ex);
            }


        }


    }
}
