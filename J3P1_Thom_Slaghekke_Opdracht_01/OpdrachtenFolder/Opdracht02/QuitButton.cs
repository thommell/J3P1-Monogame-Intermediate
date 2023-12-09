using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class QuitButton : Button
    {
        protected string _quitText;
        protected float _quitTextX;
        protected float _quitTextY;
        public QuitButton(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, SpriteFont pFont, string pString) : base(pPosition, pTexture, pRectangle, pFont)
        {
            _quitText = pString;
            _quitTextX = _texture.Width / 2f - _font.MeasureString(_quitText).X / 2;
            _quitTextY = _texture.Height / 2f - _font.MeasureString(_quitText).Y / 2;
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
            pSpriteBatch.DrawString(_font, _quitText, new Vector2(_position.X + _quitTextX, _position.Y + _quitTextY), Color.White);
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
