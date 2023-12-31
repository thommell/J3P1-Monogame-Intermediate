﻿using J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht03;
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
    public class Button : GameObject
    {
        //Button
        protected CurrentButtonState _currentButtonState;
        protected LevelState _levelState;
        protected Point _mousePosition;
        protected Color _buttonColor;
        protected MouseState _mouseState;
        protected ButtonState _previousMouseClick = Mouse.GetState().LeftButton;
        protected Game1 _game;

        //Text
        protected SpriteFont _font;
        protected string _buttonText;
        protected Vector2 _textDimensions;
        public Button(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, SpriteFont pFont) : base(pPosition, pTexture, pRectangle)
        {
            _font = pFont;
        }
        /// <summary>
        /// Constructor for a button with a font.
        /// </summary>
        /// <param name="pPosition"></param>
        /// <param name="pTexture"></param>
        /// <param name="pRectangle"></param>
        /// <param name="pFont"></param>
        public Button(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, SpriteFont pFont, Game1 pGame) : base(pPosition, pTexture, pRectangle)
        {
            _game = pGame;
            _font = pFont;
        }
        /// <summary>
        /// Update object button on each frame.
        /// </summary>
        /// <param name="pGameTime"></param>
        public override void UpdateObject(GameTime pGameTime)
        {
            UpdateRectangle();
            _mouseState = Mouse.GetState();
            _mousePosition = new Point(_mouseState.X, _mouseState.Y);
            switch (_currentButtonState)
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
            _previousMouseClick = _mouseState.LeftButton;
        }   
        /// <summary>
        /// Updates the rectangle of the button.
        /// </summary>
        private void UpdateRectangle()
        {
            _rectangle = new Rectangle((int)position.X, (int)position.Y, _texture.Width, _texture.Height);
        }
        /// <summary>
        /// Handle normal state of button.
        /// </summary>
        protected virtual void StateNormal()
        {
            _buttonColor = Color.White;
            if (_rectangle.Contains(_mousePosition))
            {
                _buttonColor = Color.Red;
                _currentButtonState = CurrentButtonState.Hovered;
            }
        }
        /// <summary>
        /// Handle hovered state of button.
        /// </summary>
        protected virtual void StateHovered()
        {
            if (!_rectangle.Contains(_mousePosition))
            {
                _currentButtonState = CurrentButtonState.Normal;
            }
            if (_mouseState.LeftButton == ButtonState.Pressed && _previousMouseClick == ButtonState.Released)
            {
                _buttonColor = Color.Red;
                _currentButtonState = CurrentButtonState.Pressed;
            }
        }
        /// <summary>
        /// Handle pressed state of button.
        /// </summary>
        protected virtual void StatePressed()
        {
            if (_rectangle.Contains(_mousePosition) && _mouseState.LeftButton == ButtonState.Pressed)
            {
                _buttonColor = Color.Blue;
                _currentButtonState = CurrentButtonState.Hovered;
                OnClick();
            }
            else
            {
                _buttonColor = Color.White;
                _currentButtonState = CurrentButtonState.Normal;
            }
        }
        protected virtual void OnClick()
        {

        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            DrawColors(pSpriteBatch);
        }
        /// <summary>
        /// Draws the colors (that can change) of every button.
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        public void DrawColors(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_texture, position, null, _buttonColor, 0f, Vector2.Zero, new Vector2(1, 1), SpriteEffects.None, 0f);
        }
    }
}
