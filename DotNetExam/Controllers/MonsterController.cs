using BusinessLogicDataBase.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicDataBase.Controllersс
{ 
    [ApiController]
    [Route("[controller]")]
    public class MonsterController
    {
        private readonly IMonsterService _monsterService;

        public MonsterController(IMonsterService monsterService)
        {
            _monsterService = monsterService;
        }

        [HttpGet]
        [Route("getMonster")]
        public JsonResult GetRandom()
        {
            var randomMonster = _monsterService.GetMonster();
            return new JsonResult(randomMonster);
        }
    }
}
