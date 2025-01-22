using NPoco;
using System.ComponentModel.DataAnnotations;


namespace TestSqlite.NpocoDemo;

//[TypeScriptModel]
[TableName("Plants")]
[PrimaryKey("PlantId", AutoIncrement = true)]
[ExplicitColumns]
public class Plant
{
	[NPoco.Column]
	public int PlantId { get; set; }

	[NPoco.Column]
	[StringLength(50)]
	[Required()]
	public string Genus { get; set; } = "";

	[NPoco.Column]
	[StringLength(50)]
	[Required()]
	public string Species { get; set; } = "";

	[NPoco.Column]
	[StringLength(50)]
	public string? Family { get; set; }

	[NPoco.Column]
	[StringLength(1023)]
	public string? Description { get; set; }

	[NPoco.Column]
	[StringLength(1023)]
	public string? Notes { get; set; }

	[NPoco.Column]
	[StringLength(50)]
	public string? PlantSize { get; set; }

	[NPoco.Column]
	[StringLength(50)]
	public string? PlantType { get; set; }

	[NPoco.Column]
	[StringLength(50)]
	public string? PlantZone { get; set; }

	[NPoco.Column]
	[StringLength(150)]
	public string? PictureLocation { get; set; }

	[NPoco.Column]
	public bool IsNwNative { get; set; }

	[NPoco.Column]
	[StringLength(4095)]
	public string Pics { get; set; } = "[]";

	[NPoco.Column]
	public bool IsListed { get; set; }

	[NPoco.Column]
	public bool IsFeatured { get; set; }

	[NPoco.Column]
	[StringLength(100)]
	public string Slug { get; set; } = "";

	[NPoco.Column]
	public DateTime LastUpdate { get; set; }

	[NPoco.Column]
	[StringLength(2)]
	public string? Flag { get; set; }

}
