using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EventoContoller : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]
            {
                new Evento()
                {
                EventoId = 1,
                Tema = "Angular 11 e .NET 6",
                Local = "Linhares",
                Lote = "1 Lote",
                QtdPessoas = 20,
                DataEvento = DateTime.Now,
                ImagemURL = "foto.url"
                },

                new Evento()
                {
                EventoId = 2,
                Tema = "Angular",
                Local = "Baixo Quartel",
                Lote = "2 Lote",
                QtdPessoas = 50,
                DataEvento = DateTime.Now,
                ImagemURL = "foto1.url"
                }
            };



        [HttpGet(Name = "GetEventoController")]
        public IEnumerable<Evento> Get()
        {
            return _evento;

        }

        //[HttpGet(Name = "GetEventoController")]
        //public IEnumerable<Evento> GetById(int id)
        //{
        //    return _evento.Where(evento => evento.EventoId == id);

        //}

        [HttpPost(Name = "PostEventoController")]
        public string Post()
        {
            return "exemplo post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"exemplo delete com id = {id}";
        }
    }
}
