using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;
public enum PlayerItems
{
    Normal,
    Weapon,
    Shield,
    WeaponAndShield
}
public class Player : GameObject
{
    private Game1 _game1;
    private readonly float _speed = 350f;
    private readonly Viewport _viewPort;
    public PlayerItems items = PlayerItems.Normal;
    private Texture2D[] _playerTextures;
    private Vector2 _originalPosition;
    public Player(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Viewport pViewPort, Texture2D[] pPlayerTextures, Game1 pGame) : base(pPosition, pTexture, pRectangle)
    {
        _viewPort = pViewPort;
        _playerTextures = pPlayerTextures;
        _game1 = pGame;
        _originalPosition = pPosition;
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        PlayerMovement(pGameTime);
        ClampPlayer(pGameTime, _viewPort);
        //UpdateTexture();
        UpdateRectangle(pGameTime);
    }

    private void ClampPlayer(GameTime pGameTime, Viewport pViewport)
    {
        position = new Vector2(Math.Clamp(position.X, 0, pViewport.Width - _texture.Width),
        Math.Clamp(position.Y, 0, pViewport.Height - _texture.Height));
    }
    private void UpdateTexture()
    {
        switch (items)
        {
            case PlayerItems.Normal:
                _texture = _playerTextures[0];
                break;
            case PlayerItems.Shield:
                _texture = _playerTextures[1];
                break;
            case PlayerItems.Weapon:
                _texture = _playerTextures[2];
                break;
            case PlayerItems.WeaponAndShield:
                _texture = _playerTextures[3];
                break;
            default:
                Console.WriteLine("no texture ? ");
                break;
        }
    }
    public override void UpdateRectangle(GameTime pGameTime)
    {
        base.UpdateRectangle(pGameTime);
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
            position += translation * _speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
    }
    public void CollidedWith(string pObjectName)
    {
        if (pObjectName == "shield" && items == PlayerItems.Normal)
        {
            items = PlayerItems.Shield;
        } 
        else if (pObjectName == "weapon" && items == PlayerItems.Normal)
        {
            items = PlayerItems.Weapon;
        }
        else if (pObjectName == "gate")
        {
            //_game1.Exit();
            _game1.SwapScene("level2");
            SetPlayerToOriginalPosition();
        }
        else if (pObjectName == "gate2")
        {
            _game1.SwapScene("level1");
            SetPlayerToOriginalPosition();
        }
        else
        {
            items = PlayerItems.WeaponAndShield;
        }
        UpdateTexture();
    }
    private void SetPlayerToOriginalPosition()
    {
        position = new Vector2(_originalPosition.X, _originalPosition.Y);
    }
    public void KillPlayer()
    {
        Environment.Exit(0);
    }

}