using DeathOfAButler.Entitys;
using Otter;
using System.Collections.Generic;

namespace DeathOfAButler.Scenes
{
    public class MainGameScene : Scene
    {
        public bool IsDebug { get; set; }
        public MainGameScene(string level = "EntranceHallWay") : base()
        {

#if DEBUG
            IsDebug = true;
#else
            IsDebug = false;
#endif
            Program.currentScene = level;
            LevelData levelData = LevelLoader.Load(@"Assets/Levels/" + level + ".json");

            AddGraphics(levelData.Graphics.ToArray());
            AddGraphics(levelData.Items.ToArray());

            var CollisionsMap = new CollisionEntity(0, 0, IsDebug);            
            CollisionsMap.AddColliders(levelData.Colliders);
            CollisionsMap.AddColliders(levelData.Doors);

            Add(CollisionsMap);

            Add(
                new PlayerEntity(
                    (levelData.PlayerSpawnX * levelData.TileSizeX) + levelData.OriginX, 
                    (levelData.PlayerSpawnY * levelData.TileSizeY) + levelData.OriginY
                )
            );

            Add(new Hud());
            
        }

        public override void Update()
        {
            base.Update();

          
        }
    }
}
