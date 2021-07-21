using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoAPI.Data;
using VideoAPI.Models;

namespace VideoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideoController : ControllerBase
    {
        private VideoContext _context;

        public VideoController(VideoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaVideo([FromBody] Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVideoPorId), new { Id = video.Id }, video);
        }

        //Verbo Get, reconhecido como padrão na ação de recuperar informações do sistema.
        [HttpGet]
        public IEnumerable<Video> RecuperaVideos()
        {
            return _context.Videos;
        }


        [HttpGet("{id}")]
        public IActionResult RecuperaVideoPorId(int id)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video != null)
            {
                return Ok(video);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVideo(int id, [FromBody] Video videoNovo)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            video.Titulo = videoNovo.Titulo;
            video.Descricao = videoNovo.Descricao;
            video.Url = videoNovo.Url;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVideo(int id)
        {
            Video video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (video == null)
            {
                return NotFound();
            }
            _context.Remove(video);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
