
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XMen.Api.DAL;
using static XMen.Api.DAL.MutantContext;

namespace XMen.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MutantController : ControllerBase
    {
        private readonly ILogger<MutantController> _logger;
        private readonly IMutantReposirory _repo;

        public MutantController(ILogger<MutantController> logger, IMutantReposirory mutantReposirory)
        {
            _logger = logger;
            _repo = mutantReposirory;
        }

        [HttpPost]
        public IActionResult IsMutant([FromBody] DNA dna)
        {
            if (!ModelState.IsValid || !dna.IsValidDna())
                return BadRequest();

            string plainDna = string.Join("", dna.dna);

            var mutant = _repo.GetMutantByDNA(plainDna);
            if (mutant == null)
            {
                mutant = new Mutant();
                mutant.ADN = plainDna;
                mutant.IsMutant = dna.IsMutant();
                _repo.AddMutant(mutant);
            }

            if(mutant.IsMutant)

                return Ok();
            else
                return  StatusCode(403);
        }

        [HttpGet]
        [Route("/Stats")]
        public IActionResult Stats()
        {
            return Ok(_repo.GetStats());
        }
        
    }
}
