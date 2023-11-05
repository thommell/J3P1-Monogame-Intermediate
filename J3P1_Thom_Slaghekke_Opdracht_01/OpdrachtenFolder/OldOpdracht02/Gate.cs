using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.OldOpdracht02
{
    public class Gate : Interactable
    {
        Player _player;
        private Game1 _game;
        public Gate(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, string pName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pName, pPlayer, pGame)
        {
            _player = pPlayer;
            _game = pGame;
        }
        public override void OnCollision()
        {
            Console.WriteLine("GATEEEE");
        }
    }
}
