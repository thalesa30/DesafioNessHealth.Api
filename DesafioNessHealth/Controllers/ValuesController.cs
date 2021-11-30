using DesafioNessHealth.Contexto;
using DesafioNessHealth.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesafioNessHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly PersonagemDbContexto _personagemDbContexto;
        public ValuesController(PersonagemDbContexto personagemDbContexto)
        {
            _personagemDbContexto = personagemDbContexto;
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonagem()
        {
            return Ok(new
            {
                sucess = true,
                data = await _personagemDbContexto.Personagens.ToListAsync()
            });
        }
        [HttpPost]
        public async Task<IActionResult> CreatePersonagem(Personagem personagem)
        {
            _personagemDbContexto.Personagens.Add(personagem);
            await _personagemDbContexto.SaveChangesAsync();
            return Ok(new
            {
                sucess = true,
                data = personagem
            });
        }
    }
}

    

