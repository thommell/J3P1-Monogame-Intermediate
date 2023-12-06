using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public enum CurrentButtonState
    {
        Normal,
        Hovered,
        Pressed
    }
    public class Button : GameObject
    {
        CurrentButtonState _buttonState;
        protected LevelState _levelState;
        public Button(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Vector2 pOrigin) : base(pPosition, pTexture, pRectangle, pOrigin)
        {

        }
        public override void UpdateObject(GameTime pGameTime)
        {
            switch (_buttonState)
            {
                case CurrentButtonState.Normal:
                    StateNormal();
                break;
                case CurrentButtonState.Hovered:
                    StateHovered();
                break;
                case CurrentButtonState.Pressed:
                    StatePressed();
                break;
            }
        }      
        public virtual void StateNormal()
        {

        }
        public virtual void StateHovered()
        {

        }
        public virtual void StatePressed()
        {

        }
    }
}
