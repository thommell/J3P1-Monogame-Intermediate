using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_Thom_Slaghekke_Opdracht_01;

public class Interactable : GameObject
{
    private Player _player;
    public Interactable(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle) : base(pPosition, pTexture, pRectangle)
    {
        
    }

    public override void UpdateObject()
    {
        CollisionCheck();
    }

    private void CollisionCheck()
    {
        if (_rectangle.Intersects(_player._rec))
    }
}