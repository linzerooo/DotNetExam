namespace Models.Players;

public class Opponents
{
    public Player Player { get; }
    public Monster Monster { get; }

    public Opponents(Player player, Monster monster)
    {
        Player = player;
        Monster = monster;
    }
}