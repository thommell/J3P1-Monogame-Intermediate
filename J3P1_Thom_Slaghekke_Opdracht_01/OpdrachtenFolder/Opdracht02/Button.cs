using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Button : GameObject
    {
        public Button(Texture2D pTexture, Rectangle pRectangle, Vector2 pPosition) : base(pPosition, pTexture, pRectangle)
        {

        }
        public virtual void OnClick()
        {

        }
    }
}
