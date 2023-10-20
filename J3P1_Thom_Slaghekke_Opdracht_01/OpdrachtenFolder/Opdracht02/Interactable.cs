using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;
public class Interactable : GameObject
{
    private Player _player;
    private Game1 _game1;
    private string _name;
    public Interactable(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, string pObjectName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle)
    {
        _player = pPlayer;
        _name = pObjectName;
        _game1 = pGame;
    }
    public override void UpdateObject(GameTime pGameTime)
    {
        UpdateRect();
        CollisionCheck();
    }
    private void CollisionCheck()
    {
        if (_player._rectangle.Intersects(_rectangle))
        {
            _player.CollidedWith(_name);
            OnCollision();
        }
    }
    private void UpdateRect()
    {
        _rectangle = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
    }
    public virtual void OnCollision()
    {

    }
}