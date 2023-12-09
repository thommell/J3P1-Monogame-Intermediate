using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;
public class Interactable : GameObject
{
    private Player _player;
    private Game1 _game1;

    public Interactable(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle)
    {
        _player = pPlayer;
        _game1 = pGame;
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        CollisionCheck();
        UpdateRectangle();
    }
    public void UpdateRectangle()
    {
        _rectangle = new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
    }
    private void CollisionCheck()
    {
        if (_player._rectangle.Intersects(_rectangle))
        {
            Console.WriteLine("Collided with player");
            OnCollision();
        }
    }
    public virtual void OnCollision()
    {

    }
}