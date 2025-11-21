namespace DndManager.Models
{
    public class Character
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        // Die 6 Grundattribute
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        // Konstruktor mit Standard-ID
        public Character()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}