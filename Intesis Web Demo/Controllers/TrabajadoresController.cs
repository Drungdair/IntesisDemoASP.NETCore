using Intesis_Web_Demo.Context;
using Intesis_Web_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intesis_Web_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajadoresController : ControllerBase
    {
        private readonly AppDBContext context;
        public TrabajadoresController(AppDBContext context)
        {
            this.context = context;
        }
        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Trabajador.ToList());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}", Name ="GetTrabajador")]
        public ActionResult Get(int id)
        {
            try
            {
                var trabajador = context.Trabajador.FirstOrDefault(t => t.id == id);
                return Ok(trabajador);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody]Trabajadores_BD trabajador)
        {
            try
            {
                context.Trabajador.Add(trabajador);
                context.SaveChanges();
                return CreatedAtRoute("GetTrabajador", new{id = trabajador.id}, trabajador);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Trabajadores_BD trabajador)
        {
            try
            {
                if (trabajador.id == id)
                {
                    context.Entry(trabajador).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetTrabajador", new { id = trabajador.id }, trabajador);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var trabajador = context.Trabajador.FirstOrDefault(t => t.id == id);
                if(trabajador != null)
                {
                    context.Trabajador.Remove(trabajador);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
