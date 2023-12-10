using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class Scene
    {
        protected Game1 _game;
        protected GraphicsDeviceManager _device;
        protected SpriteBatch _spriteBatch;
        public List<GameObject> _objectsInScene = new List<GameObject>();
        protected SceneManager _sceneManager;
        public Scene(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pDevice)
        {
            _game = pGame;
            _device = pDevice;
            _spriteBatch = pSpriteBatch;
        }
        public virtual void LoadScene(SceneManager pSceneManager)
        {
            _sceneManager = pSceneManager;
            for (int i = 0; i < _objectsInScene.Count; i++)
            {
                _objectsInScene[i].LoadObject(_game.Content, _sceneManager);
            }
        }
        public virtual void UpdateScene(GameTime pGameTime)
        {
            for (int i = 0; i < _objectsInScene.Count; i++)
            {
                _objectsInScene[i].UpdateObject(pGameTime);
            }
        }
        public virtual void DrawScene(SpriteBatch pSpriteBatch)
        {
            for (int i = 0; i < _objectsInScene.Count; i++)
            {
                _objectsInScene[i].DrawObject(_spriteBatch);
            }
        }
        public void RemoveObject(GameObject obj)
        {
            _objectsInScene.Remove(obj);
        }
    }
}
