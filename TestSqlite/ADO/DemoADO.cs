using Microsoft.Data.Sqlite;


namespace TestSqlite.ADO;

internal class DemoADO 
{
	private readonly string connStr;

	internal DemoADO (string dbFullPath)
	{
		connStr = $"Data Source={dbFullPath}";
	}


	internal void Create()
	{
		using var connection = new SqliteConnection(connStr);
		connection.Open();

		var command = connection.CreateCommand();
		command.CommandText =
		@"
				CREATE TABLE user (
					id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
					name TEXT NOT NULL
				);

				INSERT INTO user
				VALUES (1, 'Brice'),
							 (2, 'Alexander'),
							 (3, 'Nate');
				";

		try
		{
			command.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		finally
		{
			SqliteConnection.ClearAllPools();
		}
	}


	internal void Add()
	{
		using (var connection = new SqliteConnection(connStr))
		{
		add_start:
			Console.Write("Name: ");
			var name = Console.ReadLine();

			if (String.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("Name cannot be empty.");
				goto add_start;
			}

			connection.Open();
			var command = connection.CreateCommand();
			command.CommandText =
			@"
					INSERT INTO user (name)
					VALUES ($name)
				";

			command.Parameters.AddWithValue("$name", name);
			command.ExecuteNonQuery();

			command.CommandText =
			@"
					SELECT last_insert_rowid()
				";

			var res = command.ExecuteScalar();

			string newId = res?.ToString() ?? "missing";
			Console.WriteLine($"Your new user ID is {newId}.");

			SqliteConnection.ClearAllPools();
		}
	}

	internal void FindById()
	{
		Console.Write("User ID: ");

		if (!Int32.TryParse(Console.ReadLine(), out int id))
		{
			id = -1;
		}

		if (id <= 0)
		{
			Console.WriteLine("Invalid ID.");
			return;
		}


		using var connection = new SqliteConnection(connStr);
		connection.Open();

		var command = connection.CreateCommand();
		command.CommandText =
		@"
					SELECT name
					FROM user
					WHERE id = $id
				";
		command.Parameters.AddWithValue("$id", id);

		using (SqliteDataReader reader = command.ExecuteReader())
		{
			if (reader.Read())
			{
				var name = reader.GetString(0);
				Console.WriteLine($"Hello, {name}!");
			}
			else
			{
				Console.WriteLine("User not found.");
			}
		}

		SqliteConnection.ClearAllPools();
	}

	internal void ListAll()
	{
		using var connection = new SqliteConnection(connStr);
		connection.Open();

		var command = connection.CreateCommand();
		command.CommandText =
		@"
				SELECT id, name
				FROM user
				ORDER BY name
			";

		using (var reader = command.ExecuteReader())
		{
			Console.WriteLine("Here are all the names:");
			while (reader.Read())
			{
				int id = reader.GetInt32(0);
				var name = reader.GetString(1);

				Console.WriteLine($"{name} - ({id})");
			}
		}

		SqliteConnection.ClearAllPools();
	}

	//File.Delete("hello.db");
}