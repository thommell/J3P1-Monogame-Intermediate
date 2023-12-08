using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02;
public class GameObject
{
    protected Vector2 _position;
    protected Texture2D _texture;
    public Rectangle _rectangle;
    protected GameObject(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle)
    {
        _position = pPosition;
        _texture = pTexture;
        _rectangle = pRectangle;
        _position = new Vector2(_position.X - (_texture.Width / 2), _position.Y - (_texture.Height / 2));
    }
    public virtual void UpdateObject(GameTime pGameTime)
    {
        
    }
    public virtual void DrawObject(SpriteBatch pSpriteBatch)
    {
        pSpriteBatch.Draw(_texture, _position, null, Color.White, 0f, Vector2.Zero, new Vector2(1,1), SpriteEffects.None, 0f);
    }
}