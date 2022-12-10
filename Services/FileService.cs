using MarketPlays.Filters;
using System.Text;

namespace MarketPlays.Services;

[scoped]
public static class FileService
{
    public static string SaveImage(IFormFile? formfile, string folder)
    {
        string imagePath = "";
        if (formfile is not null)
        {
            var mc = new MemoryStream();
            formfile.CopyTo(mc);
            byte[] bytes = Encoding.UTF8.GetBytes(mc.ToString()!);

            var imageName = Guid.NewGuid().ToString("N").Take(20);
            imagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot", $"{folder}", $"{imageName}");
            File.WriteAllBytes(imagePath, bytes);
        }
        else
        {
            imagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot", $"{folder}", $"default.png");
        }
            
        return imagePath;
    }
   /* public static List <string> SaveImages (List <IFormFile>? formfiles, string folder)
    {
        var stringList = new List<string>();
        if (formfiles is not null)
        {
            foreach (var formfile in formfiles)
            {
                var mc = new MemoryStream();
                formfile.CopyTo(mc);
                byte[] bytes = Encoding.UTF8.GetBytes(mc.ToString()!);

                var imageName = Guid.NewGuid().ToString("N").Take(20);
                imagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot", $"{folder}", $"{imageName}");
                File.WriteAllBytes(imagePath, bytes);
            }
           
        }
        else
        {
            stringList.Add Path.Combine(Environment.CurrentDirectory, "wwwroot", $"{folder}", $"default.png");
        }

        return stringList;
    }*/
}