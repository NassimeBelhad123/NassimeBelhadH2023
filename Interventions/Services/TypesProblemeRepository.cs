using Interventions.DbContexts;
using Interventions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Interventions.Services
{
    public class TypesProblemeRepository : ITypesProblemeRepository
    {
        private readonly InterventionsDbContext _context;
        private readonly ILogger<TypesProblemeRepository> _logger;

        public TypesProblemeRepository(InterventionsDbContext context, ILogger<TypesProblemeRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Retourne une liste de types de problème
        /// </summary>
        /// <returns></returns>
        /// 

        public async Task<IEnumerable<TypeProbleme>> GetTypesProblemeAsync()
        {
            try
            {
                return await _context.TypeProbleme.OrderBy(o => o.descriptionTypeProbleme).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans l'obtention des données de la base de données : {ex}");
            }
            return null;
            
        }

    }
}
