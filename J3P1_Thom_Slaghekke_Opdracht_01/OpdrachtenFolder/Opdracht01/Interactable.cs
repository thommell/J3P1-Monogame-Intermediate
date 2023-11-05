using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht01;
public class Interactable : GameObject
{
    private Player _player;
    private Game1 _game1;
    private string _name;
    public Interactable(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Vector2 pOrigin, string pObjectName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pOrigin)
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
            Console.WriteLine(_name);
            _player.CollidedWith(_name);
            _game1._gameObjects.Remove(this);
        }
    }
}