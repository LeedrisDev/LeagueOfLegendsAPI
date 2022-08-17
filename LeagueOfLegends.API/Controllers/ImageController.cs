using LeagueOfLegends.API.Business.DTO;

namespace LeagueOfLegends.API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("images")]
public class ImageController: ControllerBase
{
    private readonly ILogger<ImageController> _logger;
    
    public ImageController(ILogger<ImageController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("profileIcon/{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundObject))]
    public IActionResult GetProfileIconImage(int id)
    {
        var path = "images/profileIcons/" + id + ".png";
        try
        {
            var image = System.IO.File.OpenRead(path);
            return File(image, "image/png");
        }
        catch (FileNotFoundException)
        {
            var notFound = new NotFoundObject("Image not found");
            return NotFound(notFound);
        }
    }
}