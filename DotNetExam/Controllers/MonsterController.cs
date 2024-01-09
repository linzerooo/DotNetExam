using Microsoft.AspNetCore.Mvc;

namespace BusinessLogicDataBase.Controllersс
{ 
    [ApiController]
    [Route("[controller]")]
    public class MonsterController
    {
        private readonly MonstersDbContext _db;
        public MonsterController(MonstersDbContext db) => _db = db;

        [HttpGet]
        [Route("getMonster")]
        public JsonResult GetRandom()
        {
            var count = _db.Monsters.Count();
            var rnd = new Random().Next(0,count);
            return new JsonResult(_db.Monsters.ToList().ElementAt(rnd));
        }
    }
}
