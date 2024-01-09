using Models.Players;

namespace Models;

public class Result
{
    public List<Log> Logs { get; set; }
    public Character Winner { get; set; }
    public Result() { }
}