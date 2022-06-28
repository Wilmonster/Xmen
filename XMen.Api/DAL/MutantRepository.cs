using System.Threading.Tasks;
using static XMen.Api.DAL.MutantContext;

namespace XMen.Api.DAL
{
    public class MutantRepository : IMutantReposirory
    {

        private MutantContext _context;

        public MutantRepository(MutantContext context)
        {
            _context = context;
        }

        public void AddMutant(Mutant mutant)
        {
            _context.Mutants.Add(mutant);
            _context.SaveChanges();
        }

        public Mutant GetMutantByDNA(string dna)
        {
            return _context.Mutants.Find(dna);
        }

        public Stats GetStats()
        {
            return new Stats { count_human_dna = 100, count_mutant_dna = 100, ratio = 0.4f };
        }
    }
}
