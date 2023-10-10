using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace J3P1_CSharp_Advanced.Opdracht02;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _sb;

    private Player _player;
    public Interactable _shieldObject;
    public Interactable _weaponObject;
    public Interactable _gateObject;
    private Game1 _game;

    public List<GameObject> _gameObjects = new List<GameObject>();
    private Viewport _viewport;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        System.Console.WriteLine("Initialize");

        _viewport = new Viewport(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        //System.Console.WriteLine("LoadContent");
        _sb = new SpriteBatch(GraphicsDevice);

        // Player Textures
        Texture2D[] playerTextures = {
                Content.Load<Texture2D>("Knight"), // 0
                Content.Load<Texture2D>("KnightShield"), // 1
                Content.Load<Texture2D>("KnightWeapon"), // 2
                Content.Load<Texture2D>("KnightWeaponShield") // 3
        };
        // Interactable Textures
        Texture2D _weaponTexture = Content.Load<Texture2D>("Weapon");
        Texture2D _shieldTexture = Content.Load<Texture2D>("Shield");
        Texture2D _gateTexture = Content.Load<Texture2D>("Gate");
        _game = this;
        _player = new Player(new Vector2(100, 100), playerTextures[0], new Rectangle(0, 0, 0, 0), _viewport, playerTextures, _game);
        _shieldObject = new Interactable(new Vector2(200, 200), _shieldTexture, new Rectangle(0, 0, 0, 0), "shield", _player, _game);
        _weaponObject = new Interactable(new Vector2(200, 400), _weaponTexture, new Rectangle(0, 0, 0, 0), "weapon", _player, _game);
        _gateObject = new Interactable(new Vector2(400, 200), _gateTexture, new Rectangle(0, 0, 0, 0), "gate", _player, _game);

        _gameObjects.Add(_player);
        _gameObjects.Add(_shieldObject);
        _gameObjects.Add(_weaponObject);
        _gameObjects.Add(_gateObject);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        //System.Console.WriteLine("Update");
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // System.Console.WriteLine(_gameObjects.Count);
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            _gameObjects[i].UpdateObject(gameTime);
        }

        // TODO: Add your update logic here
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _sb.Begin();

        for (int i = 0; i < _gameObjects.Count; i++)
        {
            _gameObjects[i].DrawObject(_sb);
        }

        _sb.End();

        base.Draw(gameTime);
    }
}