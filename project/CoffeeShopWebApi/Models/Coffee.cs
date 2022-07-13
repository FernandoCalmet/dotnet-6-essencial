namespace CoffeeShopWebApi.Models;

[Table("Coffee")]
public class Coffee : ICoffeeWrapper
{
    [Key]
    [Column("CoffeeId")]
    [JsonPropertyName("coffeeId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Column("Name", TypeName = "varchar(100)")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [Column("Description", TypeName = "nvarchar(200)")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Column("Price", TypeName = "decimal(18,2)")]
    public double Price { get; set; }

    [Column("OrderDate", TypeName = "datetime")]
    public DateTime OrderDate { get; set; }    
}