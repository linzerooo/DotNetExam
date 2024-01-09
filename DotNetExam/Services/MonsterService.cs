using Microsoft.AspNetCore.Mvc;
using Models.Players;

namespace BusinessLogicDataBase.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly MonstersDbContext _db;

        public MonsterService(MonstersDbContext db)
        {
            _db = db;
        }
        public Monster GetMonster()
        {
            var count = _db.Monsters.Count();
            var rnd = new Random().Next(0, count);
            return _db.Monsters.ToList().ElementAt(rnd);
        }
    }
}
