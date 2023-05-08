using Interventions.Entities;

namespace Interventions.Services
{
    public interface ITypesProblemeRepository
    {
        Task<IEnumerable<TypeProbleme>> GetTypesProblemeAsync();
    }
}
