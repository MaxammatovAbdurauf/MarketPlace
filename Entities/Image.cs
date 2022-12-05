using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace MarketPlays.Entities;

[Table("Photos",Schema = "public")]
public class Image
{
    public Guid Name { get; set; }
    public IFormFile? fileForm { get; set; }
}