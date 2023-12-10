using J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class PlayButton : Button
    {
        public PlayButton(Vector2 pPositon, Texture2D pTexture, Rectangle pRectangle, Game1 pGame, SpriteFont pFont, string pString) : base(pPositon, pTexture, pRectangle, pFont, pGame)
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
        protected override void OnClick()
        {
            _game.SwapScene("level1");
        }
        public override void DrawString(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.DrawString(_font, _buttonText, new Vector2(position.X + _textDimensions.X, position.Y + _textDimensions.Y), Color.White);
        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            DrawString(pSpriteBatch);
        }
    }
}
