namespace Student_game.Server.Dtos.Item
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoryDTO
    {
        Weapon = 1,
        Food = 2,
        Armour = 3
    }
}