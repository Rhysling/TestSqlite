namespace TestSqlite.ADO;

internal static class AdoMenu
{
	private readonly static int[] commands = [ 1, 2, 3, 9 ];

	internal static int Run()
	{
	menu:
		Console.WriteLine();
		Console.WriteLine("1. Add");
		Console.WriteLine("2. Find by Id");
		Console.WriteLine("3. List All");
		Console.WriteLine("9. Exit");
		Console.WriteLine("Command?");

		if(!Int32.TryParse(Console.ReadLine(), out int command))
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
}
