using DndManager.Models;

namespace DndManager.Views
{
    public partial class CharacterListPage : ContentPage
    {
        // Temporäre Liste für Test-Daten
        private List<Character> characters = new List<Character>();

        public CharacterListPage()
        {
            InitializeComponent();
            LoadCharacters();
        }

        private void LoadCharacters()
        {
            // Erstmal Test-Daten, später laden wir aus Speicher
            characters = new List<Character>
            {
                new Character
                {
                    Name = "Gandalf",
                    Class = "Wizard",
                    Gender = "Male",
                    Intelligence = 18,
                    Wisdom = 16
                },
                new Character
                {
                    Name = "Legolas",
                    Class = "Ranger",
                    Gender = "Male",
                    Dexterity = 18,
                    Wisdom = 14
                }
            };

            CharactersCollection.ItemsSource = characters;
        }

        private void OnCharacterSelected(object sender, SelectionChangedEventArgs e)
        {
            // Später: Charakter bearbeiten
            if (e.CurrentSelection.Count > 0)
            {
                var character = e.CurrentSelection[0] as Character;
                DisplayAlert("Charakter", $"Du hast {character?.Name} ausgewählt", "OK");
            }
        }

        private async void OnAddCharacterClicked(object sender, EventArgs e)
        {
            // Später: Navigation zur Detailseite
            await DisplayAlert("Info", "Detailseite kommt als nächstes!", "OK");
        }
    }
}