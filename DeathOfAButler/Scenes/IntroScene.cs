using Otter;
using System.Collections;

namespace DeathOfAButler.Scenes
{
    public class IntroScene : Scene
    {
        public Image ImageBox;

        public IntroScene() : base() {

            ImageBox = Image.CreateRectangle(32,Color.Cyan);
            AddGraphic(ImageBox);
            ImageBox.X = 0;
            ImageBox.Y = Game.Instance.HalfHeight;

        }

        public override void Begin()
        {
            base.Begin();

            // Start the coroutine, yo.
            Game.Coroutine.Start(MainRoutine());
        }


        IEnumerator MainRoutine()
        {
            yield return Coroutine.Instance.WaitForFrames(30);
            yield return MoveBoxTo(540, 100);
            yield return MoveBoxTo(540, 380);
            yield return MoveBoxTo(100, 380);
            yield return MoveBoxTo(100, 100);
            Game.SwitchScene(new MainGameScene());
        }

        IEnumerator MoveBoxTo(float x, float y)
        {
            // Used to determine the completion.
            var initialDistance = Util.Distance(ImageBox.X, ImageBox.Y, x, y);

            float currentDistance = float.MaxValue;
            while (currentDistance > 1)
            {
                currentDistance = Util.Distance(ImageBox.X, ImageBox.Y, x, y);

                // Determine the completion of the movement from 0 to 1.
                var completion = Util.ScaleClamp(currentDistance, 0, initialDistance, 1, 0);

                // Lerp the color of the box based on the completion of the movement.
                //ImageBox.Color = Util.LerpColor(CurrentColor, NextColor, completion);

                // Spin the box along with its movement because why not.
                //ImageBox.Angle = Util.ScaleClamp(completion, 0, 1, 0, 360);

                // Actually move the box toward the destination.
                ImageBox.X = Util.Approach(ImageBox.X, x, 5);
                ImageBox.Y = Util.Approach(ImageBox.Y, y, 5);

                // Wait until next frame.
                // See how magical this is? We're in the middle of a while loop
                // and we can just wait until the next frame to resume it!
                yield return 0;
            }

            // Done moving.  Update the color.
            //CurrentColor = NextColor;
        }

        public override void Update()
        {
            base.Update();

            if (Input.KeyPressed(Key.Space))
            {
                // When the space bar is pressed switch to the SecondScene.
                Program.currentScene = "MainGameScene";
                Game.SwitchScene(new MainGameScene());
            }
        }
    }
}

