using Otter;

namespace DeathOfAButler.Scenes
{
    public class GameOverScene : Scene
    {
        public GameOverScene() : base()
        {
            Program.currentScene = "Game Over Scene";
            AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.White));
        }
    }
}
