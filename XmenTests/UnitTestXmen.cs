
using XMen.Api;

namespace XmenTests;

public class UnitTestXmen
{
    [Fact]
    public void IsMutant()
    {
        var dna = new DNA();

        dna.dna  = new string[] {"ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"};

        bool IsMutant = dna.IsMutant();

        Assert.True(IsMutant);

    }

    [Fact]
    public void IsValidDAN()
    {
        var dna = new DNA();

        dna.dna = new string[] { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

        bool isValidDna = dna.IsValidDna();

        Assert.True(isValidDna);

    }

    [Fact]
    public void IsInValidDAN()
    {
        var dna = new DNA();

        dna.dna = new string[] { "ATGCGP", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

        bool isValidDna = dna.IsValidDna();

        Assert.False(isValidDna);

    }

}