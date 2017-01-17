using Otter;
using System.Collections.Generic;

namespace DeathOfAButler.Scenes
{
    public class MainGameScene : Scene
    {
        public MainGameScene() : base()
        {

            LevelData levelData = LevelLoader.Load(@"Assets/Levels/EntranceHallWay.json");

            AddGraphics(levelData.Graphics.ToArray());
            
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
