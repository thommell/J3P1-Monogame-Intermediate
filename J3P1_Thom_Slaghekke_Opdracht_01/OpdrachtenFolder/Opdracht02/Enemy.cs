using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Enemy : GameObject
    {
        protected float _speed;
        protected Vector2 _direction;
        protected Player _player;
        protected Rectangle targetRectangle;
        protected Texture2D _hitboxColor;
        protected int _chasingSize;

        protected float[] _targetRectangleNumbers = new float[4];
        public EnemyState _currentEnemyState = EnemyState.Patrolling;
        private GraphicsDevice _device;
        public Enemy(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Player pPlayer, GraphicsDevice pDevice, float pSpeed, int pSize) : base(pPosition, pTexture, pRectangle)
        {
            _device = pDevice;
            _player = pPlayer;
            _speed = pSpeed;
            _chasingSize = pSize;

            _hitboxColor = new Texture2D(_device, 1, 1);
            _hitboxColor.SetData(new Color[] { Color.White });

            //_targetRectangleNumbers[0] = _rectangle.Width * _chasingSize; // You can adjust the scale factor as needed
            //_targetRectangleNumbers[1] = _rectangle.Height * _chasingSize; // You can adjust the scale factor as needed
            //_targetRectangleNumbers[2] = _rectangle.X + (_rectangle.Width - _targetRectangleNumbers[0]) / _chasingSize;
            //_targetRectangleNumbers[3] = _rectangle.Y + (_rectangle.Height - _targetRectangleNumbers[1]) / _chasingSize;
            //targetRectangle = new Rectangle((int)_targetRectangleNumbers[0], (int)_targetRectangleNumbers[1], (int)_targetRectangleNumbers[2], (int)_targetRectangleNumbers[3]);

        }
        public override void UpdateObject(GameTime pGameTime)
        {
            
            EnemyMovement(pGameTime);
            UpdateRectangle(pGameTime);
            OnCollision(pGameTime);
        }
        
        private void EnemyMovement(GameTime pGameTime)
        {
            Console.WriteLine(_currentEnemyState);
        }
        public override void UpdateRectangle(GameTime pGameTime)
        {
            base.UpdateRectangle(pGameTime);
            UpdateChasingRectangle(pGameTime);
        }
        private void UpdateChasingRectangle(GameTime pGameTime)
        {
            int targetWidth = _rectangle.Width * _chasingSize;
            int targetHeight = _rectangle.Height * _chasingSize;

            int targetX = _rectangle.X - (targetWidth - _rectangle.Width) / 2;
            int targetY = _rectangle.Y - (targetHeight - _rectangle.Height) / 2;

            targetRectangle = new Rectangle(targetX, targetY, targetWidth, targetHeight);
            
        }
        private void ChangeState(string pString, GameTime pGameTime)
        {
            switch (pString.ToLower())
            {
                case "patrol":
                    Patrol();
                    break;
                case "idle":
                    Idle();
                    break;
                case "chase":
                    Chase(pGameTime);
                    break;
                case "evade":
                    Evade();
                    break;
            }
        }
        private void Patrol()
        {

        }
        private void Idle()
        {

        }
        private void Chase(GameTime pGameTime)
        {
            _direction = position - _player.position;
            _direction.Normalize();
            position -= _direction * _speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
        private void Evade()
        {

        }
        private void OnCollision(GameTime pGameTime)
        {
            if (_player._rectangle.Intersects(targetRectangle))
            {
                ChangeState("chase", pGameTime);
            }
        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            //uncomment this to draw the hitbox of the chasing mode.
            //DrawRectangle(pSpriteBatch);
        }
        private void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_hitboxColor, position, targetRectangle, Color.Red);
        }
    }
}
