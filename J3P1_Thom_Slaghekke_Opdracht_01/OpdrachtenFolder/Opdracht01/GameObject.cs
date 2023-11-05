using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht01;
public class GameObject
{
    protected Vector2 _position;
    protected Texture2D _texture;
    public Rectangle _rectangle;
    protected Vector2 _origin;

    protected GameObject(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Vector2 pOrigin)
    {
        _position = pPosition;
        _texture = pTexture;
        _rectangle = pRectangle;
        _origin = pOrigin;
    }
    public virtual void UpdateObject(GameTime pGameTime)
    {
        
    }
    public virtual void DrawObject(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(_texture, _position, Color.White);
        //pSpriteBatch.Draw(_texture, _rectangle, Color.Red); for every rectangle 
    }
}

