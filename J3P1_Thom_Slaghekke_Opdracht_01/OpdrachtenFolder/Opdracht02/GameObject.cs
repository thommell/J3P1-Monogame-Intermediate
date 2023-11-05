using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;

public class GameObject
{
    public Vector2 _position;
    public Texture2D _texture;
    public Rectangle _rectangle;

    protected GameObject(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle)
    {
        _position = pPosition;
        _texture = pTexture;
        _rectangle = pRectangle;
    }
    public virtual void UpdateObject(GameTime pGameTime)
    {

    }
    public virtual void DrawObject(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(_texture, _position, Color.White);
    }
}
