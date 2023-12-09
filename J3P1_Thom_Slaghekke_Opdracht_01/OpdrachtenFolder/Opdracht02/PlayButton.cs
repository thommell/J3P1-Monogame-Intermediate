using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class PlayButton : Button
    {
        protected string _playText;
        protected float _playTextX;
        protected float _playTextY;
        public PlayButton(Vector2 pPositon, Texture2D pTexture, Rectangle pRectangle, Game1 pGame, SpriteFont pFont, string pString) : base(pPositon, pTexture, pRectangle, pFont, pGame)
        {
            _playText = pString;
            _playTextX = _texture.Width / 2f - _font.MeasureString(_playText).X / 2;
            _playTextY = _texture.Height / 2f - _font.MeasureString(_playText).Y / 2;
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
            pSpriteBatch.DrawString(_font, _playText, new Vector2(_position.X + _playTextX, _position.Y +_playTextY), Color.White);
        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            DrawString(pSpriteBatch);
        }
    }
}
