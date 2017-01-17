using Otter;

namespace DeathOfAButler.Scenes
{
    public class CreditsScene : Scene
    {
        public CreditsScene() : base()
        {
            //example
            AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.Black));
        }
    }
}
