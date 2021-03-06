﻿using Otter;

namespace DeathOfAButler.Scenes
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene() : base()
        {
            Program.currentScene = "Main Menu";
            var text = new Text("Main Menu", 16);
            text.SetPosition(Game.Instance.HalfWidth, Game.Instance.HalfHeight * 1 / 3);
            text.Color = Color.White;
            text.CenterOrigin();
            AddGraphic(text);

            //need to add a character select screen. ♀ Jane Marpole or ♂ Darren Hollister 
        }
    }
}
