using Otter;
using DeathOfAButler.Scenes;

namespace DeathOfAButler
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game("Death of a Butler", 800, 600, 60, false);

            game.Start(new SplashScreenScene());
        }
    }
}
