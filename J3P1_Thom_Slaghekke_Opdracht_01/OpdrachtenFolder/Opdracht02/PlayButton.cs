using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class PlayButton : Button
    {
        private Game1 game;
        public PlayButton(Texture2D pTexture, Rectangle pRectangle, Vector2 pPosition, Game1 pGame, SpriteFont pFont) : base(pTexture, pRectangle, pPosition, pFont)
        {
            game = pGame;
        }
        public override void OnClick()
        {
            game.scene = Game1.Scenes.Level1;
        }
    }
}
