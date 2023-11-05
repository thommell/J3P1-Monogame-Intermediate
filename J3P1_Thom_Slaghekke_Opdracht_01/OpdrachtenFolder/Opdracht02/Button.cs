using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Button : GameObject
    {
        private SpriteFont _font;
        public Button(Texture2D pTexture, Rectangle pRectangle, Vector2 pPosition, SpriteFont pFont) : base(pPosition, pTexture, pRectangle)
        {
            _font = pFont;
        }
        public override void UpdateObject(GameTime pGameTime)
        {
            MouseState _mouseState = Mouse.GetState();
            Point _mousePos = new Point(_mouseState.X, _mouseState.Y);

            if (_rectangle.Contains(_mousePos) && _mouseState.LeftButton == ButtonState.Pressed)
            {
                OnClick();
            }
        }
        public virtual void OnClick()
        {
            
        }

        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            pSpriteBatch.DrawString(_font, "hi", _position, Color.White);
        }
    }
}
