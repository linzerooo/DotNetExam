using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Players;
using Models;

namespace UI.Pages
{
    public class GameModel : PageModel
    {
        private const string DbUrl = "https://localhost:7006/monster/getMonster";
        private const string BlUrl = "https://localhost:7006/game/fight";

        [BindProperty] 
        public Player Player { get; set; } = new();
        public Monster Monster { get; set; }
        public Result? Result;

        public void OnGet() { }

        public async Task OnPostAsync()
        {
            if (!ModelState.IsValid) return;
            using var client = new HttpClient();
            var monster = await client.GetFromJsonAsync<Monster>(DbUrl);
            Monster = monster;
            var result = await client.PostAsJsonAsync(BlUrl, new Opponents(Player, monster!));
            Result = await result.Content.ReadFromJsonAsync<Result>();
        }
    }
}
