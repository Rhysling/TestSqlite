namespace TestSqlite.ADO;

internal static class Ado
{
	private readonly static int[] commands = [1, 2, 3, 9];

	internal static int RunMenu()
	{
	menu:
		Console.WriteLine();
		Console.WriteLine("1. Add");
		Console.WriteLine("2. Find by Id");
		Console.WriteLine("3. List All");
		Console.WriteLine("9. Exit");
		Console.WriteLine("Command?");

		if (!Int32.TryParse(Console.ReadLine(), out int command))
			command = -1;

		if (commands.Contains(command))
		{
			Console.WriteLine();
			return command;
		}

		Console.WriteLine("Bad Command");
		Console.WriteLine();
		goto menu;
	}


	internal static void RunAdo(string dbPath)
	{
		var demo = new DemoADO(dbPath);
		demo.Create();

	start:
		int com = RunMenu();

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
		return;
	}
}