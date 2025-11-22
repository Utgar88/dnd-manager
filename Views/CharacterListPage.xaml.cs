using CommunityToolkit.Mvvm.Messaging;
using DndManager.Models;

namespace DndManager.Views
{
    public partial class CharacterListPage : ContentPage
    {

        private List<Character> characters = new List<Character>();

        public CharacterListPage()
        {
            InitializeComponent();
            LoadCharacters();

            // WeakReferenceMessenger abonnieren
            WeakReferenceMessenger.Default.Register<CharacterSavedMessage>(this, (recipient, message) =>
            {
                var character = message.Character;
                var isNew = message.IsNew;

                if (isNew && character != null)
                {
                    characters.Add(character);
                }

                RefreshCharacterList();
            });
        }

        private void LoadCharacters()
        {
            // Beispielhafte Charaktere hinzufügen
            characters = new List<Character>
            {
                new Character
                {
                    Name = "Gandalf",
                    Class = "Wizard",
                    Gender = "Male",
                    Intelligence = 18,
                    Wisdom = 16,
                    Strength = 10,
                    Dexterity = 12,
                    Constitution = 14,
                    Charisma = 15
                },
                new Character
                {
                    Name = "Legolas",
                    Class = "Ranger",
                    Gender = "Male",
                    Dexterity = 18,
                    Wisdom = 14,
                    Strength = 13,
                    Intelligence = 12,
                    Constitution = 14,
                    Charisma = 13
                }
            };

            RefreshCharacterList();
        }

        private void RefreshCharacterList()
        {
            CharactersCollection.ItemsSource = null;
            CharactersCollection.ItemsSource = characters;
        }

        private async void OnCharacterSelected(object sender, SelectionChangedEventArgs e)
        {

            if (e.CurrentSelection.Count > 0)
            {
                var character = e.CurrentSelection[0] as Character;

                if (character == null)
                {
                }
                else
                {
                    await Shell.Current.GoToAsync("CharacterDetailPage", new Dictionary<string, object>
                    {
                        { "Character", character }
                    });
                }

                CharactersCollection.SelectedItem = null;
            }
        }

        private async void OnAddCharacterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("CharacterDetailPage");
        }
    }

    // Neue Message-Klasse für das Messaging
    public class CharacterSavedMessage
    {
        public Character Character { get; set; }
        public bool IsNew { get; set; }

        public CharacterSavedMessage(Character character, bool isNew)
        {
            Character = character;
            IsNew = isNew;
        }
    }
}