using CommunityToolkit.Mvvm.Messaging;
using DndManager.Models;

namespace DndManager.Views
{
    [QueryProperty(nameof(CharacterToEdit), "Character")]
    public partial class CharacterDetailPage : ContentPage
    {
        private Character _character;
        private bool _isNewCharacter;

        public Character CharacterToEdit
        {
            set
            {
                _character = value;
                _isNewCharacter = false;
                Title = "Charakter bearbeiten";
                LoadCharacterData();
            }
        }

        public CharacterDetailPage()
        {
            InitializeComponent();
            _character = new Character();
            _isNewCharacter = true;
            Title = "Neuer Charakter";

            // Standardwerte für die Labels setzen
            UpdateAttributeLabels();
        }

        private void UpdateAttributeLabels()
        {
            StrengthLabel.Text = ((int)StrengthStepper.Value).ToString();
            DexterityLabel.Text = ((int)DexterityStepper.Value).ToString();
            ConstitutionLabel.Text = ((int)ConstitutionStepper.Value).ToString();
            IntelligenceLabel.Text = ((int)IntelligenceStepper.Value).ToString();
            WisdomLabel.Text = ((int)WisdomStepper.Value).ToString();
            CharismaLabel.Text = ((int)CharismaStepper.Value).ToString();
        }

        private void LoadCharacterData()
        {
            NameEntry.Text = _character.Name;
            GenderEntry.Text = _character.Gender;
            ClassEntry.Text = _character.Class;

            StrengthStepper.Value = _character.Strength > 0 ? _character.Strength : 10;
            DexterityStepper.Value = _character.Dexterity > 0 ? _character.Dexterity : 10;
            ConstitutionStepper.Value = _character.Constitution > 0 ? _character.Constitution : 10;
            IntelligenceStepper.Value = _character.Intelligence > 0 ? _character.Intelligence : 10;
            WisdomStepper.Value = _character.Wisdom > 0 ? _character.Wisdom : 10;
            CharismaStepper.Value = _character.Charisma > 0 ? _character.Charisma : 10;

            UpdateAttributeLabels();
        }

        private void OnAttributeChanged(object sender, ValueChangedEventArgs e)
        {
            var stepper = sender as Stepper;
            var value = (int)e.NewValue;

            if (stepper == StrengthStepper)
                StrengthLabel.Text = value.ToString();
            else if (stepper == DexterityStepper)
                DexterityLabel.Text = value.ToString();
            else if (stepper == ConstitutionStepper)
                ConstitutionLabel.Text = value.ToString();
            else if (stepper == IntelligenceStepper)
                IntelligenceLabel.Text = value.ToString();
            else if (stepper == WisdomStepper)
                WisdomLabel.Text = value.ToString();
            else if (stepper == CharismaStepper)
                CharismaLabel.Text = value.ToString();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                await DisplayAlert("Fehler", "Bitte gib einen Namen ein", "OK");
                return;
            }

            _character.Name = NameEntry.Text.Trim();
            _character.Gender = GenderEntry.Text?.Trim() ?? string.Empty;
            _character.Class = ClassEntry.Text?.Trim() ?? string.Empty;

            _character.Strength = (int)StrengthStepper.Value;
            _character.Dexterity = (int)DexterityStepper.Value;
            _character.Constitution = (int)ConstitutionStepper.Value;
            _character.Intelligence = (int)IntelligenceStepper.Value;
            _character.Wisdom = (int)WisdomStepper.Value;
            _character.Charisma = (int)CharismaStepper.Value;

            // MessagingCenter entfernt, stattdessen WeakReferenceMessenger verwenden
            WeakReferenceMessenger.Default.Send(new CharacterSavedMessage(_character, _isNewCharacter));

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}