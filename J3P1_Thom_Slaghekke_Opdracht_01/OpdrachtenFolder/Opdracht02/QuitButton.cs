using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class QuitButton : Button
    {
        public QuitButton(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle) : base(pPosition, pTexture, pRectangle)
        {
        
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
