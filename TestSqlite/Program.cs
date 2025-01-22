
using TestSqlite.ADO;
using TestSqlite.NpocoDemo;

string dbPath = @"D:\UserData\Documents\AppTest\TestSqlite\TestSqlite\db\hello.db";

//Ado.RunAdo(dbPath);

var db = new DemoNpoco(dbPath);
var pl = db.GetPlants();

foreach (var p in pl)
{
	Console.WriteLine($"{p.Genus} {p.Species}");
}

Console.WriteLine("Done.");
Console.ReadKey();