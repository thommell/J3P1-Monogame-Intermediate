﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Weapon : Interactable
    {
        Player _player;
        private Game1 _game;
        public Weapon(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, string pName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pName, pPlayer, pGame)
        {
            _player = pPlayer;
            _game = pGame;
        }
        public override void OnCollision()
        {
            // Weapon Collision
            Console.WriteLine("Weapon!");
            _game._gameObjectsLevel1.Remove(this);
            
        }
    }
}
