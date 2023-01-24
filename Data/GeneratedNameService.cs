namespace BlazorApp.Data;

public class GeneratedNameService
{
    private static readonly string[] Names = new[]
    {
        "Emil", "Erik", "Anders", "Nils", "Ess", "Hans", "Christian", "Olof", "Johan", "Per", "Petter", "Gustaf", "Fors", "Sten", "Johanna", "Joacim", "Dante", "Hannes", "Irshai", "Hirv"
    };

    private static readonly string[] Suffixes = new[]
    {
        "son", "ner", "quist", "sen", "berg", "rehn", "dat", "hol", "onen", "man", "lund"
    };

    public int GetNumberOfPermutations()
    {
        return (int)(Math.Pow(Names.Length, 3) * Suffixes.Length);
    }

    public string GetFirstName()
    {
        return Names[Random.Shared.Next(Names.Length)];
    }

    public string GetSurnameName()
    {
        return Names[Random.Shared.Next(Names.Length)] + Suffixes[Random.Shared.Next(Suffixes.Length)];
    }

    public string GetGeneratedName()
    {
        string firstName = Names[Random.Shared.Next(Names.Length)];
        string secondName = Names[Random.Shared.Next(Names.Length)];
        string surName = Names[Random.Shared.Next(Names.Length)];

        string suffix = Suffixes[Random.Shared.Next(Suffixes.Length)];

        return firstName + "-" + secondName + " " + surName + suffix;
    }
}
