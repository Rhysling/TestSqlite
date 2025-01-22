
using TestSqlite.ADO;

string dbPath = @"D:\UserData\Documents\AppTest\TestSqlite\TestSqlite\db\hello.db";

var demo = new DemoADO(dbPath);
demo.Create();

start:
int com = AdoMenu.Run();

switch (com)
{
	case 1:
		demo.Add();
		break;
	case 2:
		demo.FindById();
		break;
	case 3:
		demo.ListAll();
		break;
	case 9:
		goto end;
}
goto start;

end:
Console.WriteLine("Done.");
Console.ReadKey();


