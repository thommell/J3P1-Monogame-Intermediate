using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class Shield : Interactable
    {
        private Player _player;
        private Game1 _game1;
        private string _objName;
        public Shield(Texture2D pTexture, Rectangle pRectangle, Vector2 pPosition, string pObjectName, Player pPlayer, Game1 pGame) : base(pPosition, pTexture, pRectangle, pPlayer, pGame)
        {
            _player = pPlayer;
            _game1 = pGame;
            _objName = pObjectName;
        }
        public override void OnCollision()
        {
            _player.CollidedWith(_objName);
            _game1._gameObjectsLevel1.Remove(this);
            
        }
    }
}
