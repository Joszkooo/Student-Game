

namespace Student_game.Server.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Boost
    {
        HealthBoost = 1,
        AttackBoost = 2,
        DefenseBoost = 3,
        LuckBoost = 4
    }
}