using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using DataAnalysisTool.Models;

public class ExploreController : Controller
{
    private readonly string _csvPath = Path.Combine(
        Directory.GetCurrentDirectory(), "Data", "iris.csv");

    public IActionResult Index()
    {
        using var reader = new StreamReader(_csvPath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var rows = csv.GetRecords<IrisRow>().ToList();

        var stats = new
        {
            Count = rows.Count,
            Species = rows
                .GroupBy(r => r.Species)
                .Select(g => new { Species = g.Key, Count = g.Count() }),

            PetalStats = new
            {
                Min = rows.Min(r => r.PetalLength),
                Max = rows.Max(r => r.PetalLength),
                Mean = rows.Average(r => r.PetalLength),
                Std = Math.Sqrt(
                    rows.Average(
                        r => Math.Pow(
                            r.PetalLength - rows.Average(x => x.PetalLength), 2
                        )
                    )
                )
            }
        };

        return View(stats);
    }

}