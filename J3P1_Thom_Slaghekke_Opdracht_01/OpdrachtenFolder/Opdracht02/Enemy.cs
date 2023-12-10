using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace J3P1_CSharp_Advanced.OpdrachtenFolder.Opdracht02
{
    public class Enemy : GameObject
    {
        protected float _speed;
        protected Vector2 _direction;
        protected Player _player;
        protected Rectangle _targetRectangle;
        protected Texture2D _hitboxColor;
        protected int _chasingSize;
        protected float _stamina = 4f;
        protected float _durationToChange = 0.5f;

        public EnemyState _currentEnemyState = EnemyState.Idling;
        private GraphicsDevice _device;
        public Enemy(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Player pPlayer, GraphicsDevice pDevice, float pSpeed, int pSize) : base(pPosition, pTexture, pRectangle)
        {
            _device = pDevice;
            _player = pPlayer;
            _speed = pSpeed;
            _chasingSize = pSize;

            _hitboxColor = new Texture2D(_device, 1, 1);
            _hitboxColor.SetData(new Color[] { Color.White });
        }
        public override void UpdateObject(GameTime pGameTime)
        {
            // UpdateRectangle
            // CollisionCheck
            //
            CheckState(pGameTime);
            UpdateRectangle(pGameTime);
        }
        
        private void EnemyMovement(GameTime pGameTime)
        {
            Console.WriteLine(_currentEnemyState);
        }
        public override void UpdateRectangle(GameTime pGameTime)
        {
            base.UpdateRectangle(pGameTime);

            int targetWidth = _rectangle.Width * _chasingSize;
            int targetHeight = _rectangle.Height * _chasingSize;
            int targetX = _rectangle.X - (targetWidth - _rectangle.Width) / 2;
            int targetY = _rectangle.Y - (targetHeight - _rectangle.Height) / 2;

            _targetRectangle = new Rectangle(targetX, targetY, targetWidth, targetHeight);
        }
        private void CheckState(GameTime pGameTime)
        {
            Console.WriteLine(_currentEnemyState);
            switch (_currentEnemyState)
            {
                case EnemyState.Patrolling:
                    Patrol(pGameTime);
                    break;
                case EnemyState.Idling:
                    Idle(pGameTime);
                    break;
                case EnemyState.Chasing:
                    Chase(pGameTime);
                    break;
                case EnemyState.Evading:
                    Evade();
                    break;
                case EnemyState.Resting:
                    Rest();
                    break;
            }
        }
        private void Patrol(GameTime pGameTime)
        {
            OnCollision(pGameTime);
            if (_stamina >= 0)
            {

            }
        }
        private void Idle(GameTime pGameTime)
        {
            _durationToChange -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            if (_durationToChange <= 0)
            {
                _durationToChange = 0.5f;
                _currentEnemyState = EnemyState.Patrolling;
            }
        }
        private void Chase(GameTime pGameTime)
        {
            
            //else
            //{
            //    _direction = position - _player.position;
            //    _direction.Normalize();
            //    position -= _direction * _speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
            //}
        }
        private void Evade()
        {

        }
        private void Rest()
        {

        }
        private void OnCollision(GameTime pGameTime)
        {
            if (_player._rectangle.Intersects(_targetRectangle))
            {
                _currentEnemyState = EnemyState.Chasing;
            }
            else
            {
                _currentEnemyState = EnemyState.Patrolling;
            }
            if (_player._rectangle.Intersects(_rectangle))
            {
                EnemyKill();
            }

        }
        private void EnemyKill()
        {
            Console.WriteLine("dead!");
        }
        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            //uncomment this to draw the hitbox targetRectangle
            //DrawRectangle(pSpriteBatch);
        }
        private void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_hitboxColor, position, _targetRectangle, Color.Red);
        }
    }
}
