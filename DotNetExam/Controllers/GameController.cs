using BusinessLogicDataBase.BattleLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Players;

namespace BusinessLogicDataBase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private IBattle _battle;

        public GameController(IBattle battle) => _battle = battle;

        [HttpPost]
        [Route("fight")]
        public JsonResult Fight([FromBody] Opponents opponents)
        {
            _battle = new Battle(opponents.Player, opponents.Monster);
            var result = _battle.GetResult();
            return new JsonResult(result);
        }
    }
}
