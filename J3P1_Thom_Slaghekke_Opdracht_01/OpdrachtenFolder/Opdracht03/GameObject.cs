using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class GameObject
    {
        public Vector2 position;
        protected Texture2D _texture;
        public Rectangle _rectangle;
        public SceneManager _sceneManager;
        protected ContentManager _content;
        protected GameObject(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle)
        {
            _texture = pTexture;
            _rectangle = pRectangle;
            position = new Vector2(pPosition.X - (_texture.Width / 2), pPosition.Y - (_texture.Height / 2));
        }
        protected GameObject(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, SceneManager pSceneManager)
        {
            _texture = pTexture;
            _rectangle = pRectangle;
            position = new Vector2(pPosition.X - (_texture.Width / 2), pPosition.Y - (_texture.Height / 2));
            _sceneManager = pSceneManager;
        }
        public virtual void LoadObject(ContentManager pContent, SceneManager pSceneManager)
        {
            _content = pContent;
            _sceneManager = pSceneManager;
        }
        public virtual void UpdateObject(GameTime pGameTime)
        {

        }
        public virtual void UpdateRectangle(GameTime pGameTime)
        {
            _rectangle = new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
        }
        public virtual void DrawObject(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_texture, position, null, Color.White, 0f, Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0f);
        }
        public virtual void DrawString(SpriteBatch pSpriteBatch)
        {

        }
    }
}