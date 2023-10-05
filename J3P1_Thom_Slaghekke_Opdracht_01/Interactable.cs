using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Thom_Slaghekke_Opdracht_01;

public class Interactable : GameObject
{
    private Player _player;
    private Game1 _game1;
    private string _name;
    private string pName;
    private Player pPlayer;
    public Interactable(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, string pObjectName, Player pPlayer, Game1 pGame ) : base(pPosition, pTexture, pRectangle)
    {
        _player = pPlayer;
        _name = pObjectName;
        _game1 = pGame;
    }

    public override void UpdateObject(GameTime pGameTime)
    {
        CollisionCheck();
    }
    private void CollisionCheck()
    {
        _rectangle = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        if (_player._rectangle.Intersects(_rectangle))
        {
            Console.WriteLine("Collided with player");
            _player.CollidedWith(_name);
            _game1._gameObjects.Remove(this);
        }
    }

    //protected virtual void OnCollision(string pObjectName)
    //{

    //}
}

//public class Weapon : Interactable
//{
//    public Weapon(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Player pPlayer) : base(pPosition, pTexture, pRectangle, pPlayer)
//    {
//    }

//    protected override void OnCollision()
//    {
//        _player.CollidedWithWeapon();
//    }
//}