using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostaMate.Core.Domain;
using PostaMate.DataAccess.Repositories;

namespace PostaMate.WebHost.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostamatsController : ControllerBase
    {
        private readonly InMemoryPostamatRepository _postamatRepository;

        public PostamatsController(InMemoryPostamatRepository postamatRepository)
        {
            _postamatRepository = postamatRepository;
        }
        
        [HttpGet("{num}")]
        public async Task<ActionResult<Postamat>> GetPostamatByIdAsync(string num)
        {
            var postamat = await _postamatRepository.GetByIdAsync(num);

            if (postamat == null) return NotFound();
            
            return postamat;
        }
    }
}