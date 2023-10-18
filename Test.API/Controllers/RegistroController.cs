using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataLayer.DBContext;
using DataLayer.Repositories;
using EntitiesLayer.DTOs;
using EntitiesLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Test.API.Controllers
{
   // [Authorize]
    [RoutePrefix("api/Registros")]
    public class RegistroController : ApiController
    {
        private IMapper mapper;
        private readonly RegistroService registroService = new RegistroService(new RegistroRepository(TestContext.Create()));

        public RegistroController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
                
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllRegister()
        {
            var registros = await registroService.GetAll();
            var registrosDTO  = registros.Select(x => mapper.Map<RegistroDTO>(x));

            return Ok(registrosDTO);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetByIdRegistros(int id)
        {
            var registros = await registroService.GetById(id);

            if (registros == null)
                return NotFound();

            var registroDTO = mapper.Map<RegistroDTO>(registros);

            return Ok(registroDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertRegistros(RegistroDTO registroDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var registros = mapper.Map<Registros>(registroDTO);
                registros = await registroService.Insert(registros);
                return Ok(registros);

            }
            catch (System.Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateRegistros(RegistroDTO registroDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (registroDTO.ID != id)
                return BadRequest();

            var registroid = await registroService.GetById(id);

            if (registroid == null)
                return NotFound();
            try
            {
               var registros = mapper.Map<Registros>(registroDTO);
               registros = await registroService.Update(registros);

                return Ok(registros);

            }
            catch (System.Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRegistro(int id)
        {
            var registerid = await registroService.GetById(id);

            if (registerid == null)
                return NotFound();
            try
            {
                await registroService.Delete(id);
                return Ok();

            }
            catch (System.Exception ex)
            {


                return InternalServerError(ex);
            }


        }

    }
}
