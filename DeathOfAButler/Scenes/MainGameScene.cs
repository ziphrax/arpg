using Otter;

namespace DeathOfAButler.Scenes
{
    public class MainGameScene : Scene
    {
        public MainGameScene() : base()
        {
            //example
            AddGraphic(Image.CreateRectangle(Game.Instance.Width, Game.Instance.Height, Color.Yellow));
        }

        public override void Update()
        {
            base.Update();

            if (Input.KeyPressed(Key.Space))
            {
                // When the space bar is pressed switch to the SecondScene.
                Game.SwitchScene(new MainMenuScene());
            }
        }
    }
}
