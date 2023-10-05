using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_Thom_Slaghekke_Opdracht_01;




public enum PlayerItems
{
    Normal,
    Sword,
    Shield,
    SwordAndShield
}
public class Player : GameObject
{
    private Game1 _game1;
    private readonly float _speed = 350f;
    private readonly Viewport _viewPort;
    protected PlayerItems _items = PlayerItems.Normal;
    private Texture2D[] _playerTextures;
    public Player(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Viewport pViewPort, Texture2D[] pPlayerTextures, Game1 pGame) : base(pPosition, pTexture, pRectangle)
    {
        _viewPort = pViewPort;
        _playerTextures = pPlayerTextures;
        _game1 = pGame;
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        PlayerMovement(pGameTime);
        ClampPlayer(pGameTime, _viewPort);
        UpdateTexture();
        UpdateRect();
    }

    private void ClampPlayer(GameTime pGameTime, Viewport pViewport)
    {
        _position = new Vector2(Math.Clamp(_position.X, 0, pViewport.Width - _texture.Width),
        Math.Clamp(_position.Y, 0, pViewport.Height - _texture.Height));
    }
    private void UpdateTexture()
    {
        switch (_items)
        {
            case PlayerItems.Normal:
                _texture = _playerTextures[0];
                break;
            case PlayerItems.Shield:
                _texture = _playerTextures[1];
                break;
            case PlayerItems.Sword:
                _texture = _playerTextures[2];
                break;
            case PlayerItems.SwordAndShield:
                _texture = _playerTextures[3];
                break;
            default:
                Console.WriteLine("no texture ? ");
                break;
        }
    }
    private void UpdateRect()
    {
        _rectangle = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
    }
    private void PlayerMovement(GameTime pGameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        Vector2 translation = Vector2.Zero;
        
        if (keyboardState.IsKeyDown(Keys.W))
        {
            translation.Y -= _speed;
        }
        if (keyboardState.IsKeyDown(Keys.S))
        {
            translation.Y += _speed;
        }
        if (keyboardState.IsKeyDown(Keys.A))
        {
            translation.X -= _speed;
        }
        if (keyboardState.IsKeyDown(Keys.D))
        {
            translation.X += _speed;
        }
        if (translation != Vector2.Zero)
        {
            translation.Normalize();
            _position += translation * _speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
    }
    public void CollidedWith(string pObjectName)
    {
        if (pObjectName == "shield")
        {
            Console.WriteLine(_game1._gameObjects.Count);
            _items = PlayerItems.Shield;
        }
        else if (pObjectName == "sword")
        {
            _items = PlayerItems.Sword;
        }
        else if (pObjectName == "swordAndShield" && _items == PlayerItems.Sword)
        {
            _items = PlayerItems.SwordAndShield;
        }
        else if (pObjectName == "swordAndShield" && _items == PlayerItems.Shield)
        {
            _items = PlayerItems.SwordAndShield;
        }
    }

}