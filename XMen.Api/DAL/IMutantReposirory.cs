using System.Threading.Tasks;
using static XMen.Api.DAL.MutantContext;

namespace XMen.Api.DAL
{
    public interface IMutantReposirory
    {
        Stats GetStats();
        void AddMutant(Mutant mutant);
        Mutant GetMutantByDNA(string dna);
    }
}
