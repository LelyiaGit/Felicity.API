using CsvHelper;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.Person.Mappers;
using Felicity.Repository.Person.Repositories.Interfaces;
using System.Globalization;

namespace Felicity.Repository.Person.Repositories.Implementations;

public class CsvPersonRepository : IPersonRepository
{
    private readonly string csvPath;

    public CsvPersonRepository()
    {
        this.csvPath = LocateCsvPath();
    }

    public Task<IEnumerable<PersonEntity>> GetPersons()
    {
        using var reader = new StreamReader(this.csvPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Context.RegisterClassMap<PersonEntityMap>();

        var persons = csv.GetRecords<PersonEntity>().ToList();

        return Task.FromResult<IEnumerable<PersonEntity>>(persons);
    }

    private static string LocateCsvPath()
    {
        const string fileName = "persons.csv";

        // 1) Check base directory (output folder)
        var baseDir = AppContext.BaseDirectory ?? string.Empty;
        var candidate = Path.Combine(baseDir, fileName);
        if (File.Exists(candidate))
        {
            return candidate;
        }

        // 2) Walk up the directory tree and look for the repository project folder
        var dir = new DirectoryInfo(baseDir);
        for (var i = 0; i < 10 && dir != null; i++)
        {
            var repoCandidate = Path.Combine(dir.FullName, "Fer.Felicity.Repository", "Person", "Data", fileName);
            if (File.Exists(repoCandidate))
            {
                return repoCandidate;
            }

            dir = dir.Parent;
        }

        // 3) As a last resort, search subdirectories of the base directory (catch IO errors)
        try
        {
            var found = Directory.EnumerateFiles(baseDir, fileName, SearchOption.AllDirectories).FirstOrDefault();
            if (!string.IsNullOrEmpty(found))
            {
                return found;
            }
        }
        catch
        {
            // ignore and throw below
        }

        throw new FileNotFoundException($"Could not locate '{fileName}'. Looked in: {baseDir} and parent repositories. Ensure the file exists or is copied to the output directory.");
    }
}
