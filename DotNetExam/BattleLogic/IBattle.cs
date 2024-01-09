using Models;
using Models.Players;

namespace BusinessLogicDataBase.BattleLogic
{
    public interface IBattle
    {
        public Result GetResult();
        public void CreateCouple(Opponents opponents);
    }
}
