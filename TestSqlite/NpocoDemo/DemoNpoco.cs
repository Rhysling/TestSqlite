using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSqlite.NpocoDemo;

public class DemoNpoco
{
	private readonly string connStr;

	public DemoNpoco(string dbFullPath)
	{
		connStr = $"Data Source={dbFullPath}";
	}


	public List<Plant> GetPlants()
	{
		using (var db = new PlantDb(connStr))
		{
			var p = db.All();
			return p;
		}
	}
}
