using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlite.NpocoDemo;

public class DemoNpoco(string dbFullPath)
{
	private readonly string connStr = $"Data Source={dbFullPath}";

	public List<Plant> GetPlants()
	{
		using var db = new PlantDb(connStr);
		var p = db.All();
		return p;
	}

	public void SavePlant(Plant plant)
	{
		using var db = new PlantDb(connStr);
		var p = db.Save(plant);
		Console.WriteLine($"Saved plant Id: {p.PlantId}");
	}

	public void UpdateOnePlant(int plantId)
	{
		using var db = new PlantDb(connStr);
		
		List<Plant> pl = db.ByIds([plantId]);

		if (pl.Count == 0)
		{
			Console.WriteLine($"Plant Id: {plantId} not found.");
			return;
		}

		var p = pl[0];
		Console.WriteLine($"Was: {p.PlantId}-{p.Genus} {p.Species} - Last updated: {p.LastUpdate}");
		p.Genus += "-up";
		p = db.Save(p);
		Console.WriteLine($"Now: {p.PlantId}-{p.Genus} {p.Species} - Last updated: {p.LastUpdate}");
	}
}
