using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class BackButton : Button
    {
        public BackButton(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, SpriteFont pFont, Game1 pGame, string pString) : base(pPosition, pTexture, pRectangle, pFont, pGame)
        {
            _buttonText = pString;
            _textDimensions.X = _texture.Width / 2 - _font.MeasureString(_buttonText).X / 2;
            _textDimensions.Y = _texture.Height / 2 - _font.MeasureString(_buttonText).Y / 2;
        }
        protected override void StateNormal()
        {
            base.StateNormal();
        }
        protected override void StateHovered()
        {
            base.StateHovered();
        }
        protected override void StatePressed() 
        {
            base.StatePressed();
        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            DrawString(pSpriteBatch);
        }
        public override void DrawString(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.DrawString(_font, _buttonText, new Vector2(position.X + _textDimensions.X, position.Y + _textDimensions.Y), Color.White);
        }
        protected override void OnClick()
        {
            _game.SwapScene("menu");
        }
    }
}
