using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.OldOpdracht02
{
    public class QuitButton : Button
    {
        public QuitButton(Texture2D pTexture, Rectangle pRectangle, Vector2 pPosition, SpriteFont pFont) : base(pTexture, pRectangle, pPosition, pFont)
        {

        }
        public override void OnClick()
        {
            Environment.Exit(1);
        }
    }
}
