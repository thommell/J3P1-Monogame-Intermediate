using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class Level1Scene : Scene
    {
        private Viewport _viewPort;
        public Level1Scene(SpriteBatch pSpriteBatch, Game1 pGame, GraphicsDeviceManager pDevice, Viewport pViewport) : base(pSpriteBatch, pGame, pDevice)
        {
            _viewPort = pViewport;
        }
        public override void LoadScene(SceneManager pSceneManager)
        {
            
            Texture2D _playerTexture = _game.Content.Load<Texture2D>("Knight");

            Texture2D[] _playerTextures = {
                _game.Content.Load<Texture2D>("Knight"), // 0
                _game.Content.Load<Texture2D>("KnightShield"), // 1
                _game.Content.Load<Texture2D>("KnightWeapon"), // 2
                _game.Content.Load<Texture2D>("KnightWeaponShield") // 3
        };
            Player _player = new Player(new Vector2(10, 10), _playerTexture, new Rectangle(0,0,0,0), _viewPort, _playerTextures, _game);

            _objectsInScene.Add(_player);

            base.LoadScene(pSceneManager);
        }
        public override void UpdateScene(GameTime pGameTime)
        {
            base.UpdateScene(pGameTime);
        }
        public override void DrawScene(SpriteBatch pSpriteBatch)
        {
            base.DrawScene(pSpriteBatch);
        }
    }
}
