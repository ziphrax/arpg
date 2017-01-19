using Otter;

namespace DeathOfAButler.Scenes
{
    public class CreditsScene : Scene
    {
        public CreditsScene() : base()
        {
            Program.currentScene = "Credits Scene";
            AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.Black));
        }
    }
}
