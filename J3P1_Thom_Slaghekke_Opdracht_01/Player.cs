using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace J3P1_Thom_Slaghekke_Opdracht_01;

public class Player : GameObject
{
    private readonly float _speed = 350f;
    public Player(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle) : base(pPosition, pTexture, pRectangle)
    {
        
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        PlayerMovement(pGameTime);
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

        Console.WriteLine(_position);
        Console.WriteLine(translation);

    }
}