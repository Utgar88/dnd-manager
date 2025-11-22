using DndManager.Views;

namespace DndManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Navigation für CharacterDetailPage registrieren
            Routing.RegisterRoute("CharacterDetailPage", typeof(CharacterDetailPage));
        }
    }
}