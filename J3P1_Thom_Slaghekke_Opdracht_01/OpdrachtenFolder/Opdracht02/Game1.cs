﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;

public class Game1 : Game
{
    // Objects
    private Player _player;
    private Enemy _enemy1;
    private Enemy _enemy2;

    private List<Waypoint> _waypointsLevel1 = new List<Waypoint>();
    private List<Waypoint> _waypointsLevel2 = new List<Waypoint>();


    private Waypoint _waypoint1;
    private Waypoint _waypoint2;
    private Waypoint _waypoint3;

    private Waypoint _waypoint4;
    private Waypoint _waypoint5;
    private Waypoint _waypoint6;

    public Interactable _shieldObject;
    public Interactable _weaponObject;
    public Interactable _gateLevel1;
    public Interactable _gateLevel2;

    private Game1 _game;

    private Button _playButton;
    private Button _quitButton;
    private Button _backButton;

    // Variables
    private GraphicsDeviceManager _graphics;

    private SpriteBatch _sb;

    private SpriteFont _font;

    public List<GameObject> _gameObjectsMenu = new List<GameObject>();
    public List<GameObject> _gameObjectsLevel1 = new List<GameObject>();
    public List<GameObject> _gameObjectsLevel2 = new List<GameObject>();
    private Viewport _viewport;

    private float _windowWidth;
    private float _windowHeight;

    // Enums
    private LevelState _currentLevel = LevelState.Menu;
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

        _font = Content.Load<SpriteFont>("buttonFont");

        _windowWidth = GraphicsDevice.Viewport.Width;
        _windowHeight = GraphicsDevice.Viewport.Height;
        // Player Textures
        Texture2D[] playerTextures = {
                Content.Load<Texture2D>("Knight"), // 0
                Content.Load<Texture2D>("KnightShield"), // 1
                Content.Load<Texture2D>("KnightWeapon"), // 2
                Content.Load<Texture2D>("KnightWeaponShield") // 3
        };
        Texture2D _enemyTexture = Content.Load<Texture2D>("Enemy");
        // Interactable Textures
        Texture2D _weaponTexture = Content.Load<Texture2D>("Weapon");
        Texture2D _shieldTexture = Content.Load<Texture2D>("Shield");
        Texture2D _gateTexture = Content.Load<Texture2D>("Gate");
        Texture2D _waypointTexture = Content.Load<Texture2D>("Flag");
        Texture2D[] _buttonTextures =
        {
            Content.Load<Texture2D>("UI_Tile_64x64"),
            Content.Load<Texture2D>("UI_Tile_128x64")
        };
        _game = this;
        _player = new Player(new Vector2(100, 100), playerTextures[0], new Rectangle(0, 0, 0, 0), _viewport, playerTextures, _game);
        _shieldObject = new Shield(_shieldTexture, new Rectangle(0, 0, 0, 0), new Vector2(100, 300), "shield", _player, _game);
        _weaponObject = new Weapon(_weaponTexture, new Rectangle(0, 0, 0, 0), new Vector2(_windowWidth - (_weaponTexture.Width / 2), 300), "weapon", _player, _game);
        _gateLevel1 = new Gate(_gateTexture, new Rectangle(0, 0, 0, 0), new Vector2(_windowWidth - (_gateTexture.Width / 2), _windowHeight - (_gateTexture.Height / 2)), "gate", _player, _game);
        _playButton = new PlayButton(new Vector2(_windowWidth / 2, _windowHeight / 2), _buttonTextures[1], new Rectangle(0,0,0,0), _game, _font, "PLAY");
        _quitButton = new QuitButton(new Vector2(_windowWidth / 2, _windowHeight / 2 + 100), _buttonTextures[1], new Rectangle(0, 0, 0, 0), _font, "QUIT");
        _backButton = new BackButton(new Vector2(_windowWidth - (_buttonTextures[1].Width / 2), 0 + _buttonTextures[1].Height - (_buttonTextures[1].Height / 2)), _buttonTextures[1], new Rectangle(0, 0, 0, 0), _font, _game, "MENU");
        _gateLevel2 = new Gate(_gateTexture, new Rectangle(0, 0, 0, 0), new Vector2(0 + (_gateTexture.Width / 2), _windowHeight - (_gateTexture.Height / 2)), "gate2", _player, _game);

        _waypoint1 = new Waypoint(_waypointTexture, new Vector2(600, 50), new Rectangle(0, 0, 0, 0));
        _waypoint2 = new Waypoint(_waypointTexture, new Vector2(500, 350), new Rectangle(0, 0, 0, 0));
        _waypoint3 = new Waypoint(_waypointTexture, new Vector2(300, 300), new Rectangle(0, 0, 0, 0));

        _waypoint4 = new Waypoint(_waypointTexture, new Vector2(150, 150), new Rectangle(0, 0, 0, 0));
        _waypoint5 = new Waypoint(_waypointTexture, new Vector2(200, 450), new Rectangle(0, 0, 0, 0));
        _waypoint6 = new Waypoint(_waypointTexture, new Vector2(750, 350), new Rectangle(0, 0, 0, 0));

        _waypointsLevel1.Add(_waypoint1);
        _waypointsLevel1.Add(_waypoint2);
        _waypointsLevel1.Add(_waypoint3);

        _waypointsLevel2.Add(_waypoint4);
        _waypointsLevel2.Add(_waypoint5);
        _waypointsLevel2.Add(_waypoint6);

        _enemy1 = new Enemy(new Vector2(_windowWidth / 2, _windowHeight / 2), _enemyTexture, new Rectangle(0, 0, 0, 0), _player, GraphicsDevice, 120f, 4, _waypointsLevel1);
        _enemy2 = new Enemy(new Vector2(_windowWidth / 2, _windowHeight / 2), _enemyTexture, new Rectangle(0, 0, 0, 0), _player, GraphicsDevice, 120f, 4, _waypointsLevel2);
        
        // Menu
        _gameObjectsMenu.Add(_playButton);
        _gameObjectsMenu.Add(_quitButton);

        // Level1
        _gameObjectsLevel1.Add(_player);
        _gameObjectsLevel1.Add(_shieldObject);
        _gameObjectsLevel1.Add(_weaponObject);
        _gameObjectsLevel1.Add(_gateLevel1);
        _gameObjectsLevel1.Add(_backButton);
        _gameObjectsLevel1.Add(_enemy1);

        for (int i = 0; i < _waypointsLevel1.Count; i++)
        {
            _gameObjectsLevel1.Add(_waypointsLevel1[i]);
        }

        // Level2
        _gameObjectsLevel2.Add(_player);
        _gameObjectsLevel2.Add(_gateLevel2);
        _gameObjectsLevel2.Add(_backButton);
        _gameObjectsLevel2.Add(_enemy2);
        
        for (int i = 0; i < _waypointsLevel2.Count; i++)
        {
            _gameObjectsLevel2.Add(_waypointsLevel2[i]);
        }
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Environment.Exit(0);
        }
        switch (_currentLevel)
        {
        case LevelState.Menu:
            {
                for (int i = 0; i < _gameObjectsMenu.Count; i++)
                {
                    _gameObjectsMenu[i].UpdateObject(gameTime);
                }
                break;
            }
        case LevelState.Level1:
            {
                for (int i = 0; i < _gameObjectsLevel1.Count; i++)
                {
                    _gameObjectsLevel1[i].UpdateObject(gameTime);
                }
                break;
            }
        case LevelState.Level2:
            {
                for (int i = 0; i < _gameObjectsLevel2.Count; i++)
                {
                    _gameObjectsLevel2[i].UpdateObject(gameTime);
                }
                break;
            }
        }
    }
    public void SwapScene(string pString)
    {
        switch (pString.ToLower())
        {
            case "menu":
                _currentLevel = LevelState.Menu;
                break;
            case "level1":
                _currentLevel = LevelState.Level1;
                break;
            case "level2":
                _currentLevel = LevelState.Level2;
                break;
            default:
                Console.WriteLine("ERROR! Not a correct string.");
                throw new SyntaxErrorException();
        }
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _sb.Begin();
        switch (_currentLevel)
        {
        case LevelState.Menu:
            {
                for (int i = 0; i < _gameObjectsMenu.Count; i++)
                {
                    _gameObjectsMenu[i].DrawObject(_sb);
                }
                break;
            }
        case LevelState.Level1:
            {
                for (int i = 0; i < _gameObjectsLevel1.Count; i++)
                {
                    _gameObjectsLevel1[i].DrawObject(_sb);
                }
                break;
            }
        case LevelState.Level2:
            {
                for (int i = 0; i < _gameObjectsLevel2.Count; i++)
                {
                    _gameObjectsLevel2[i].DrawObject(_sb);
                  //  _gameObjectsLevel2[i].DrawString(_sb);
                }
                break;
            }
        }
        _sb.End();
        base.Draw(gameTime);
    }

}