using Models;
using Models.Players;

namespace BusinessLogicDataBase.BattleLogic
{
    public class Battle : IBattle
    {
        private IPlayer? Player { get; set; }
        private IPlayer? Monster { get; set; }

        public Battle() { }

        public Battle(Player player, Monster monster)
        {
            Player = player;
            Monster = monster;
        }

        public Result GetResult()
        {
            var result = new Result { Logs = new List<Log>() };
            while (Player.HitPoints > 0 && Monster.HitPoints > 0)
            {
                if (Player.HitPoints > 0)
                {
                    var log = ProcessRound(false);
                    log.CharacterName = Player.Name;
                    log.EnemyName = Monster.Name;
                    result.Logs.Add(log);
                }

                if (Monster.HitPoints > 0)
                {
                    var log = ProcessRound(true);
                    log.CharacterName = Monster.Name;
                    log.EnemyName = Player.Name;
                    result.Logs.Add(log);
                }
            }

            result.Winner = Player.HitPoints > 0 ? Character.Player : Character.Monster;
            return result;
        }

        private Log ProcessRound(bool swap = false)
        {
            var active = Player;
            var passive = Monster;
            if (swap) (active, passive) = (passive, active); //определение кто пассив а кто актив
            var log = new Log();
            var rnd = new Random();

            // определние damage *d*
            var throws = int.Parse(active.Damage.Split('d')[0]); 
            var dice = int.Parse(active.Damage.Split('d')[1]);

            log.HitType = new HitType[active.AttackPerRound];
            log.Damage = new int[active.AttackPerRound];
            log.EnemyHp = new int[active.AttackPerRound];
            log.DiceRoll = new int[active.AttackPerRound];
            log.AttackModifier = active.AttackModifier;
            for (var i = 0; i < active.AttackPerRound && passive.HitPoints > 0; i++) // начало атаки, нанесение damage
            {
                var hitRoll = rnd.Next(1, 21);
                log.DiceRoll[i] = hitRoll;
                log.EnemyHp[i] = passive.HitPoints;
                if (hitRoll == 1 || log.DiceRoll[i] + log.AttackModifier <= passive.ArmorClass) //если выпало 1 или (кубик + ам < брони соперника) -> неудача. 
                {
                    log.HitType[i] = HitType.Miss;
                    continue;
                }

                if (hitRoll == 20) //критическое попадание
                    log.HitType[i] = HitType.Critical; 

                else log.HitType[i] = HitType.Hit;

                for (var j = 0; j < throws; j++) //нанесение урона
                    log.Damage[i] += (rnd.Next(1, dice + 1) + active.DamageModifier) * hitRoll / 10;
                passive.HitPoints -= Math.Min(passive.HitPoints, log.Damage[i]);
                log.EnemyHp[i] = passive.HitPoints;
                if (passive.HitPoints == 0) break; // гг
            }

            return log;
        }
        public void CreateCouple(Opponents character)
        {
            Player = character.Player;
            Monster = character.Monster;
        }
    }
}
