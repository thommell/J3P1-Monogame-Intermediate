using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03
{
    public class Waypoint : GameObject
    {
        public Waypoint(Texture2D pTexture, Vector2 pPosition, Rectangle pRectangle) :base(pPosition, pTexture, pRectangle) 
        {

        }
        public override void UpdateObject(GameTime pGameTime)
        {
            UpdateRectangle(pGameTime);
        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
        }
        public override void UpdateRectangle(GameTime pGameTime)
        {
            base.UpdateRectangle(pGameTime);
        }
    }
}
