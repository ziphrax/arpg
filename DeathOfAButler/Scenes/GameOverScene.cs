using Otter;

namespace DeathOfAButler.Scenes
{
    public class GameOverScene : Scene
    {
        public GameOverScene() : base()
        {
            //example
            AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.White));
        }
    }
}
