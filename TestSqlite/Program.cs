using TestSqlite.NpocoDemo;

string dbPath = @"D:\UserData\Documents\AppTest\TestSqlite\TestSqlite\db\hello.db";

//Ado.RunAdo(dbPath);

var dnp = new DemoNpoco(dbPath);

//var pl = dnp.GetPlants();

//foreach (var p in pl)
//{
//	Console.WriteLine($"{p.PlantId}-{p.Genus} {p.Species}");
//}

var pn = new Plant
{
	Genus = "Aloe3",
	Species = "Vera",
	Family = "Hallooo",
	Description = "Aloe Vera is a succulent plant species of the genus Aloe. An evergreen perennial, it originates from the Arabian Peninsula, but grows wild in tropical, semi-tropical, and arid climates around the world. It is cultivated for agricultural and medicinal uses.",
	PlantZone = "Zone 12."
};

dnp.SavePlant(pn);

//#pragma warning disable IDE0305 // Simplify collection initialization
//pl = dnp.GetPlants().OrderBy(a => a.PlantId).ToList();
//#pragma warning restore IDE0305 // Simplify collection initialization

//var pt = pl[^1];
//Console.WriteLine($"{pt.PlantId}-{pt.Genus} {pt.Species}");

//dnp.UpdateOnePlant(2);

Console.WriteLine("Done.");
Console.ReadKey();