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
        public EnemyState _currentEnemyState = EnemyState.Patrolling;
        public Enemy(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Player pPlayer, float pSpeed) : base(pPosition, pTexture, pRectangle)
        {
            _player = pPlayer;
            _speed = pSpeed;

            targetRectangle = new Rectangle(_rectangle.X * 2, _rectangle.Y * 2, _rectangle.Width, _rectangle.Height);
        }

        public override void UpdateObject(GameTime pGameTime)
        {
            EnemyMovement(pGameTime);
            UpdateRectangle(pGameTime);
            OnCollision();
        }
        
        private void EnemyMovement(GameTime pGameTime)
        {
            ChangeState(pGameTime);
            
        }
        public override void UpdateRectangle(GameTime pGameTime)
        {
            base.UpdateRectangle(pGameTime);
        }
        private void ChangeState(GameTime pGameTime)
        {
            switch (_currentEnemyState)
            {
                case EnemyState.Patrolling:
                    Patrol();
                    break;
                case EnemyState.Idling:
                    Idle();
                    break;
                case EnemyState.Chasing:
                    Chase(pGameTime);
                    break;
                case EnemyState.Evading:
                    Evade();
                    break;
                case EnemyState.Rest:
                    Rest();
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
        private void Rest()
        {

        }
        private void OnCollision()
        {
            if (_rectangle.Intersects(_player._rectangle))
            {
                Console.WriteLine("KILLPLAYER");
            }
        }

        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
           // base.DrawObject(pSpriteBatch);
            DrawRectangle(pSpriteBatch);
        }
        private void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_texture, _rectangle, Color.Red);
        }
    }
}
