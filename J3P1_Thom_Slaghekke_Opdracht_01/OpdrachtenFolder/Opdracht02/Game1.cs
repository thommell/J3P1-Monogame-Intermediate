using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _sb;


    public Interactable _shieldObject;
    public Interactable _weaponObject;
    public Interactable _gateObject;

    private MouseState _mouseState;
    private Point _mousePos;
    private int mouseX, mouseY;

    public Button[] buttons = new Button[2];

    #region Classes
    private Player _player;
    private Game1 _game;
    private Button _button;
    #endregion

    public List<GameObject> _gameObjectsMenu = new List<GameObject>();
    public List<GameObject> _gameObjectsLevel1 = new List<GameObject>();
    public List<GameObject> _gameObjectsLevel2 = new List<GameObject>();
    private Viewport _viewport;

    private Scenes scene = Scenes.Menu;
    private ButtonStates buttonState = ButtonStates.Normal;

    public enum Scenes
    {
        Menu,
        Level1,
        Level2
    }
    public enum ButtonStates
    {
        Normal,
        Hovered,
        Pressed
    }

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

        Texture2D[] buttonTextures =
        {
            Content.Load<Texture2D>("UI_Panel"),
            Content.Load<Texture2D>("UI_Slot"),
            Content.Load<Texture2D>("UI_Tile_64x64"),
            Content.Load<Texture2D>("UI_Tile_128x64"),
            Content.Load<Texture2D>("UI_Title")
        };
        //buttons
        buttons[0] = new PlayButton(buttonTextures[2], new Rectangle(0,0,0,0), new Vector2(200,200));

        // Interactable Textures
        Texture2D _weaponTexture = Content.Load<Texture2D>("Weapon");
        Texture2D _shieldTexture = Content.Load<Texture2D>("Shield");
        Texture2D _gateTexture = Content.Load<Texture2D>("Gate");
        _game = this;
        _player = new Player(new Vector2(100, 100), playerTextures[0], new Rectangle(0, 0, 0, 0), _viewport, playerTextures, _game);
        _shieldObject = new Shield(new Vector2(200, 200), _shieldTexture, new Rectangle(0, 0, 0, 0), "shield", _player, _game);
        _weaponObject = new Weapon(new Vector2(200, 400), _weaponTexture, new Rectangle(0, 0, 0, 0), "weapon", _player, _game);
        _gateObject = new Gate(new Vector2(400, 200), _gateTexture, new Rectangle(0, 0, 0, 0), "gate", _player, _game);

        _gameObjectsMenu.Add(buttons[0]);

        _gameObjectsLevel1.Add(_player);
        _gameObjectsLevel1.Add(_shieldObject);
        _gameObjectsLevel1.Add(_weaponObject);
        _gameObjectsLevel1.Add(_gateObject);
    }
    protected override void Update(GameTime gameTime)
    {
        buttons[0]._rectangle = new Rectangle((int)buttons[0]._position.X, (int)buttons[0]._position.Y, buttons[0]._texture.Width, buttons[0]._texture.Height);

        // mouse behaviour

        _mouseState = Mouse.GetState();
        _mousePos = new Point(_mouseState.X, _mouseState.Y);

        if (buttons[0]._rectangle.Contains(_mousePos) && _mouseState.LeftButton == ButtonState.Pressed)
        {
            scene = Scenes.Level1;
        }

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        switch (scene)
        {
        case Scenes.Menu:
            for (int i = 0; i < _gameObjectsMenu.Count; i++)
            {
                _gameObjectsMenu[i].UpdateObject(gameTime);
            }
            break;
        case Scenes.Level1:
            for (int i = 0; i < _gameObjectsLevel1.Count; i++)
            {
                _gameObjectsLevel1[i].UpdateObject(gameTime);
            }
            break;
        case Scenes.Level2:
            for (int i = 0; i < _gameObjectsMenu.Count; i++)
            {
                //_gameObjectsLevel2.UpdateObject(gameTime);
            }
            break;
        }
    }
    public void ExitGame()
    {
        Environment.Exit(0);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _sb.Begin();

        switch (scene)
        {
            case Scenes.Menu:
                for (int i = 0; i < _gameObjectsMenu.Count; i++)
                {
                    _gameObjectsMenu[i].DrawObject(_sb);
                }
                break;
            case Scenes.Level1:
                for (int i = 0; i < _gameObjectsLevel1.Count; i++)
                {
                    _gameObjectsLevel1[i].DrawObject(_sb);
                }
                break;
            case Scenes.Level2:
                for (int i = 0; i < _gameObjectsMenu.Count; i++) // verander count naar level2
                {
                    //_gameObjectsLevel2.DrawObject(_sb);
                }
                break;
        }
        _sb.End();

        base.Draw(gameTime);
    }
}