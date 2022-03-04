using System.Text.Json;
using HerokuAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HerokuTest.Pages;

public class IndexModel : PageModel
{
    public IndexModel()
    {
    }

    public async Task<IActionResult> OnGet()
    {
        var client = new HttpClient();
        var rnd = new Random();
        var user = new User(rnd.Next(0, 10000), rnd.Next(0, 10000).ToString());
        
        var json = JsonSerializer.Serialize(user);
        var response = await client.PostAsJsonAsync("https://localhost:7159/User/SetUser", json);
        var result = await response.Content.ReadFromJsonAsync<bool>();
        return Content(result.ToString());
    }
}