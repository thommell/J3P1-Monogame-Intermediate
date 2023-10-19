using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht01
{
    public class Shield : Interactable
    {
        Player _player;
        public Shield(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, string pName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pName, pPlayer, pGame)
        {
            _player = pPlayer;
        }
    }
}
