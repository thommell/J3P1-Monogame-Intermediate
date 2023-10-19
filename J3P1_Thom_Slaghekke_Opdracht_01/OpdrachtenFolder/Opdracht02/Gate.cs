using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Gate : Interactable
    {
        Player _player;
        public Gate(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, string pName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pName, pPlayer, pGame)
        {
            _player = pPlayer;
        }
        public override void OnCollision()
        {
            // Scene management.

            // Gate Collision
            Console.WriteLine("Gate!");
        }
    }
}
