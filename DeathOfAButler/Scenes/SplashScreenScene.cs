using DeathOfAButler.Entitys;
using Otter;

namespace DeathOfAButler.Scenes
{
    public class SplashScreenScene : Scene {

        ImageEntity image;
        bool display = true;

        public SplashScreenScene() : base() {
            //example
            image = new ImageEntity(0, 0, "Assets/SplashScreen.png");
            image.image.Alpha = 0;
            Add(image);
        }

        public override void Update()
        {
            base.Update();

            if (display) {
                display = false;
                Tween(image.image, new { Alpha = 1 }, 30f, 0);                
            }

            if (Input.KeyPressed(Key.Space))
            {
                Tween(image.image, new { Alpha = 0 }, 30f, 0).OnComplete(SwitchScene);
            }
        }

        void SwitchScene() {
            // When the space bar is pressed switch to the SecondScene.
            Game.SwitchScene(new IntroScene());
        }
    }
    
}
