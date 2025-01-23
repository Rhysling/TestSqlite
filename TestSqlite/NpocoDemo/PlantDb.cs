namespace TestSqlite.NpocoDemo
{
	public class PlantDb(string connStr) : RepositoryBase(connStr)
	{
		public List<Plant> All()
		{
			return db.Fetch<Plant>("WHERE (IsDeleted = 0) ORDER BY Genus, Species");
		}

		public List<Plant> ByFlag(string flag)
		{
			return db.Fetch<Plant>("WHERE (Flag = @0) ORDER BY Genus, Species", flag);
		}

		public List<Plant> ByIds(IEnumerable<int> ids)
		{
			return db.Fetch<Plant>($"WHERE (PlantId IN ({String.Join(',', ids)})) ORDER BY Genus, Species");
		}

		public List<Plant> AllWithPictures()
		{
			return db.Fetch<Plant>("WHERE (len(Pics) > 2) ORDER BY Genus, Species");
		}


		public Plant Save(Plant plant)
		{
			plant.Flag = String.IsNullOrWhiteSpace(plant.Flag) ? null : plant.Flag.Trim();
			plant.LastUpdate = DateTime.UtcNow;

			db.Save(plant);
			return plant;
		}

		// *** Updates **
		public void SetFeatured(PlantToggle pt)
		{
			string sql = "UPDATE Plants SET IsFeatured = 0";
			db.Execute(sql);
			sql = $"UPDATE Plants SET IsFeatured = {(pt.Val ? "1" : "0")} WHERE PlantId = {pt.PlantId}";
			db.Execute(sql);
		}

		public void SetListed(PlantToggle pt)
		{
			string sql = $"UPDATE Plants SET IsListed = {(pt.Val ? "1" : "0")} WHERE PlantId = {pt.PlantId}";
			db.Execute(sql);
		}


	

		public bool Save(IEnumerable<Plant> items)
		{
			foreach (Plant item in items)
			{
				db.Save(item);
			}
			return true;
		}

		public bool Delete(int id)
		{
			string nw = DateTime.UtcNow.ToString("s");
			string sql = $"UPDATE Plants SET IsListed = 0, IsFeatured = 0, LastUpdate='{nw}', Flag = null, IsDeleted = 1 WHERE PlantId = {id}";
			db.Execute(sql);
			return true;
		}

		public bool Delete(IEnumerable<int> ids)
		{
			foreach (int id in ids)
			{
				db.Delete<Plant>(id);
			}
			return true;
		}

		public bool Destroy(int id)
		{
			db.Delete<Plant>(id);
			return true;
		}


	}
}

