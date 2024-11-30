namespace Student_game.Server.Models
{
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rarity
    {
        Common = 1, // grey
        Uncommon = 2, // green
        Rare = 3, // blue
        Epic = 4, // purple
        Legendary = 5, //orange
        Godlike = 6, // red
        Mythic = 7, // gold
        Cheater = 8 // black
    }
}