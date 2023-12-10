using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class SceneManager
    {
        private Scene _currentScene;
        private List<Scene> _scenes;
        private Game1 _game;
        public SceneManager(List<Scene> pScenes, Game1 pGame) 
        {
            _scenes = pScenes;
            _currentScene = _scenes[0];
            _game = pGame;
        }
        public void SwapScene(int pInt)
        {
            _game._currentScene = pInt;
            _currentScene = _scenes[pInt];
        }
        public void Load()
        {
            _currentScene.LoadScene(this);
        }
        public void Update(GameTime pGameTime)
        {
            _currentScene.UpdateScene(pGameTime);
        }
        public void Draw(SpriteBatch pSpriteBatch)
        {
            _currentScene.DrawScene(pSpriteBatch);
        }
    }
}
