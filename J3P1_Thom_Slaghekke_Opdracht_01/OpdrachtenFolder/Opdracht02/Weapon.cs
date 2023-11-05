using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Weapon : Interactable
    {
        private Player _player;
        private Game1 _game1;
        private string _objName;
        public Weapon(Texture2D pTexture, Rectangle pRectangle, Vector2 pPosition, Vector2 pOrigin, string pObjectName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pOrigin, pPlayer, pGame)
        {
            _player = pPlayer;
            _game1 = pGame;
            _objName = pObjectName;
        }
        public override void OnCollision()
        {
            _player.CollidedWith(_objName);
            _game1._gameObjects.Remove(this);
        }
    }
}
