using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class QuitButton : Button
    {
        public QuitButton(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, SpriteFont pFont, string pString) : base(pPosition, pTexture, pRectangle, pFont)
        {
            _buttonText = pString;
            _textDimensions.X = _texture.Width / 2f - _font.MeasureString(_buttonText).X / 2;
            _textDimensions.Y = _texture.Height / 2f - _font.MeasureString(_buttonText).Y / 2;
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
            pSpriteBatch.DrawString(_font, _buttonText, new Vector2(_position.X + _textDimensions.X, _position.Y + _textDimensions.Y), Color.White);
        }
        /// <summary>
        /// Exits the environment and cancels the build.
        /// </summary>
        protected override void OnClick()
        {
            ExitGame();
        }
        private void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
