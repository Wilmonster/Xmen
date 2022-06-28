// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

String[] dna = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
string[] adnMutant = { "AAAA", "CCCC", "TTTT", "GGGG" };

bool isMutant = IsMutant(dna);
Console.WriteLine(isMutant);

bool IsMutant(String[] dna)
{
    var a = ConvertStringToMatrix(dna);
    string adnMutante = "AAAA";
    List<string> result = new List<string>();
    result = getRows(a);
    result.AddRange(getColumns(a));
    for (int j = 0; j < a.GetLength(1); j++)
    {
        result.Add(FindLeftDiagonalWordsByIndex(a, 0, j));
        result.Add(FindLeftDiagonalWordsByIndex(a, j, 0));
        result.Add(FindRightDiagonalWordsByIndex(a, 0, j));
        result.Add(FindRightDiagonalWordsByIndex(a, j, 5));
    }
    var result2 = result.Select(x => x.Length >= adnMutante.Length ? x : null)
                    .Where(x => x != null)
                    .ToList().Distinct();

    int recurrences = 0;
    foreach (var r in result2)
    {
        if (adnMutant.Any(substring => r.Contains(substring)))
        {
            Console.WriteLine(r);
            recurrences++;
        }
    }

    return recurrences > 1;
}

static string FindLeftDiagonalWordsByIndex(char[,] matrix, int x, int y)
{
    var result = "";
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i - x == j - y)
            {
                result += matrix[i, j];
            }
        }
    }
    return result;
}

static string FindRightDiagonalWordsByIndex(char[,] matrix, int x, int y)
{
    var result = "";
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
        {
            if (i - x == y - j)
            {
                result += matrix[i, j];
            }
        }

    }
    return result;

}

List<string> getRows(char[,] matrix)
{
    List<string> result = new List<string>();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        var row = "";
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            row += matrix[i, j];
        }
        result.Add(row);
    }
    return result;
}

List<string> getColumns(char[,] matrix)
{
    List<string> result = new List<string>();
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        var column = "";
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            column += matrix[i, j];
        }
        result.Add(column);
    }
    return result;
}

static char[,] ConvertStringToMatrix(String[] dna)
{
    var matrix = new char[dna.Length, dna[0].Length];
    char[] adnValid = {'A','C','T','G'};
    for (int i = 0; i < dna.Length; i++)
    {
        for (int j = 0; j < dna[i].Length; j++)
        {
            if (adnValid.All(c => c != dna[i][j] ))
            {
                Console.WriteLine(dna[i][j]);
                throw new Exception("Invalid DNA");
            }
            matrix[i, j] = dna[i][j];
        }
    }
    return matrix;
}