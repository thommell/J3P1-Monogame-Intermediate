using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class PlayButton : Button
    {
        public PlayButton(Vector2 pPositon, Texture2D pTexture, Rectangle pRectangle, Game1 pGame) : base(pPositon, pTexture, pRectangle, pGame)
        {

        }
        public override void UpdateObject(GameTime pGameTime)
        {
            base.UpdateObject(pGameTime);
            Console.WriteLine(_currentButtonState);
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
    }
}
