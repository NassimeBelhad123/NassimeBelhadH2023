using AutoMapper;
using Interventions.Entities;
using Interventions.Models;
using Interventions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Interventions.Controllers
{
    [ApiController]
    [Route("v{version:apiversion}/probleme")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [EnableRateLimiting("LimiterFenetre")]

    public class ProblemeController : ControllerBase
    {
        private readonly ITypesProblemeRepository _typesProblemeRepository;
        private readonly ILogger<ProblemeController> _logger;
        private readonly IMapper _mapper;

        public ProblemeController(ITypesProblemeRepository typesProblemeRepository, 
            ILogger<ProblemeController> logger, IMapper mapper) 
        {
            this._typesProblemeRepository = typesProblemeRepository ?? throw new ArgumentNullException(nameof(typesProblemeRepository));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TypeProbleme>>> GetTypesProblemeAsync()
        {
            try
            {
                
                var infos = await _typesProblemeRepository.GetTypesProblemeAsync();
                var infosDTO = _mapper.Map<IEnumerable<TypeProblemeDTO>>(infos);
                return Ok(infosDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention des données du repo : {ex}");
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }
            
        }
    }
}
