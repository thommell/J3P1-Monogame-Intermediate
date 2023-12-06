using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class PlayButton : Button
    {
        public PlayButton(Vector2 pPositon, Texture2D pTexture, Rectangle pRectangle, Vector2 pOrigin) : base(pPositon, pTexture, pRectangle, pOrigin)
        {

        }
        public override void StateNormal()
        {
            
        }
        public override void StateHovered()
        {
            
        }
        public override void StatePressed()
        {
            if (_levelState != LevelState.Level1)
            {
                _levelState = LevelState.Level1;
            }
        }
    }
}
