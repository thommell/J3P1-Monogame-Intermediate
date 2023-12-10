using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class MenuScene : Scene
    {
       
        private float _windowWidth;
        private float _windowHeight;
       
        public MenuScene(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pDevice) : base(pSpriteBatch, pGame, pDevice)
        {
            _windowWidth = _device.GraphicsDevice.Viewport.Width;
            _windowHeight = _device.GraphicsDevice.Viewport.Height;
        }
        public override void LoadScene(SceneManager pSceneManager)
        {
            Texture2D _buttonTexture = _game.Content.Load<Texture2D>("UI_Tile_128x64");

            PlayButton _playButton = new PlayButton(new Vector2(_windowWidth / 2, _windowHeight / 2), _buttonTexture, new Rectangle(0, 0, 0, 0), pSceneManager, _game.Content.Load<SpriteFont>("buttonFont"), "PLAY");
            QuitButton _quitButton = new QuitButton(new Vector2(_windowWidth / 2, _windowHeight / 2 + 100), _buttonTexture, new Rectangle(0, 0, 0, 0), _game.Content.Load<SpriteFont>("buttonFont"), "QUIT");

            _objectsInScene.Add(_playButton);
            _objectsInScene.Add(_quitButton);

            base.LoadScene(pSceneManager);
        }
    }
}
