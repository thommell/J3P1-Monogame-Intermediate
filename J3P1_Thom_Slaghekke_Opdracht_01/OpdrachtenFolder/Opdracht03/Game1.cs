using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _sb;

        public int _sceneIndex = 0;

        private Viewport _viewport;
        private SceneManager _sceneManager;

        List<Scene> _scenes = new List<Scene>();
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _viewport = new Viewport(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            


            _sb = new SpriteBatch(GraphicsDevice);
            MenuScene _menuScene = new MenuScene(_sb, this, _graphics);
            Level1Scene _level1Scene = new Level1Scene(_sb, this, _graphics, _viewport);

            _scenes.Add(_menuScene);
            _scenes.Add(_level1Scene);

            _sceneManager = new SceneManager(_scenes, this);
            for (int i = 0; i < _scenes.Count; i++)
            {
                _scenes[i].LoadScene(_sceneManager);
            }
        }
        protected override void Update(GameTime pGameTime)
        {
            _scenes[_sceneIndex].UpdateScene(pGameTime);
            Console.WriteLine(_scenes[_sceneIndex]._objectsInScene.Count);
        }
        protected override void Draw(GameTime pGameTime)
        {
            base.Draw(pGameTime);
            _sb.Begin();
            _scenes[_sceneIndex].DrawScene(_sb);

            _sb.End();
        }
        public void RemoveGameObject(GameObject obj)
        {
            _scenes[_sceneIndex].RemoveObject(obj); 
        }
    }
}