using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        protected float _restTime = 0f;

        private int index = 0;
        protected float _durationToChange = 0.5f;

        public EnemyState _currentEnemyState = EnemyState.Idling;

        private GraphicsDevice _device;
        private List<Waypoint> _waypoints;
        public Enemy(Vector2 pPosition, Texture2D pTexture, Rectangle pRectangle, Player pPlayer, GraphicsDevice pDevice, float pSpeed, int pSize, List<Waypoint> pListOfWaypoints) : base(pPosition, pTexture, pRectangle)
        {
            _device = pDevice;
            _player = pPlayer;
            _speed = pSpeed;
            _chasingSize = pSize;
            _waypoints = pListOfWaypoints;

            _hitboxColor = new Texture2D(_device, 1, 1);
            _hitboxColor.SetData(new Color[] { Color.White });
        }
        /// <summary>
        /// Updates the object.
        /// </summary>
        /// <param name="pGameTime"></param>
        public override void UpdateObject(GameTime pGameTime)
        {
            CheckState(pGameTime);
            UpdateRectangle(pGameTime);
            Console.WriteLine(_currentEnemyState);
        }
        /// <summary>
        /// Updates all the rectangles from the object.
        /// </summary>
        /// <param name="pGameTime"></param>
        public override void UpdateRectangle(GameTime pGameTime)
        {
            base.UpdateRectangle(pGameTime);
            UpdateChasingRectangle();
        }
        /// <summary>
        /// Update the targets' rectangle with the target position.
        /// </summary>
        private void UpdateChasingRectangle()
        {
            int chasingRectangleWidth = _rectangle.Width * _chasingSize;
            int chasingRectangleHeight = _rectangle.Height * _chasingSize;
            int chasingRectangleX = _rectangle.X - (chasingRectangleWidth - _rectangle.Width) / 2;
            int chasingRectangleY = _rectangle.Y - (chasingRectangleHeight - _rectangle.Height) / 2;

            _targetRectangle = new Rectangle(chasingRectangleX, chasingRectangleY, chasingRectangleWidth, chasingRectangleHeight);
        }
        /// <summary>
        /// Switches through the states.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void CheckState(GameTime pGameTime)
        {
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
                    Evade(pGameTime);
                    break;
                case EnemyState.Resting:
                    Rest(pGameTime);
                    break;
            }
        }
        /// <summary>
        /// if enemystate is Patrol, this method will run.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void Patrol(GameTime pGameTime)
        {
            OnCollision(pGameTime);
            MoveToWaypoint(pGameTime);
            LoseStamina(pGameTime);
        }
        /// <summary>
        /// if enemystate is Idle, this method will run.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void Idle(GameTime pGameTime)
        {
            _durationToChange -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            if (_durationToChange <= 0)
            {
                _durationToChange = 0.5f;
                _currentEnemyState = EnemyState.Patrolling;
            }
        }
        /// <summary>
        /// if enemystate is Chase, this method will run.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void Chase(GameTime pGameTime)
        {
            OnCollision(pGameTime);
            MoveToPlayer(pGameTime);
        }
        /// <summary>
        /// if enemystate is Evade, this method will run.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void Evade(GameTime pGameTime)
        {
            OnCollision(pGameTime);
            MoveAwayFromPlayer(pGameTime);
        }
        /// <summary>
        /// if enemystate is Rest, this method will run.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void Rest(GameTime pGameTime)
        {
            EnemyResting(pGameTime);
        }
        /// <summary>
        /// Enemy will take its time to rest.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void EnemyResting(GameTime pGameTime)
        {
            _restTime += (float)pGameTime.ElapsedGameTime.TotalSeconds;
            if (_restTime >= 2f)
            {
                _currentEnemyState = EnemyState.Patrolling;
                _restTime = 0;
            }
        }
        /// <summary>
        /// Enemy moves towards the next waypoint(s).
        /// </summary>
        /// <param name="pGameTime"></param>
        private void MoveToWaypoint(GameTime pGameTime)
        { 
            for (int i = 0; i < _waypoints.Count; i++)
            {
                if (Vector2.Distance(position, _waypoints[index].position) <= 3f)
                {
                    index = (index + 1) % _waypoints.Count; // if count exceeds the waypoints itll reset and start over
                }
                Vector2 waypointDirection = Vector2.Normalize(_waypoints[index].position - position);
                position += waypointDirection * (_speed / 2) * (float)pGameTime.ElapsedGameTime.TotalSeconds;
            }
        }
        /// <summary>
        /// Enemy loses stamina.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void LoseStamina(GameTime pGameTime)
        {
            _stamina -= (float)pGameTime.ElapsedGameTime.TotalSeconds;
            if (_stamina < 0)
            {
                _currentEnemyState = EnemyState.Resting;
                _stamina = 4f;
            }
        }
        /// <summary>
        /// Enemy moves to the player.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void MoveToPlayer(GameTime pGameTime)
        {
            _direction = position - _player.position;
            _direction.Normalize();
            position -= _direction * _speed * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
        /// <summary>
        /// Enemy moves away from the player.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void MoveAwayFromPlayer(GameTime pGameTime)
        {
            _direction = position - _player.position;
            _direction.Normalize();
            position += _direction * (_speed * 2) * (float)pGameTime.ElapsedGameTime.TotalSeconds;
        }
        /// <summary>
        /// Handles the collisions for the enemy.
        /// </summary>
        /// <param name="pGameTime"></param>
        private void OnCollision(GameTime pGameTime)
        {
            if (_player._rectangle.Intersects(_targetRectangle) && (_player.items != PlayerItems.WeaponAndShield))
            {
                _currentEnemyState = EnemyState.Chasing;
            }
            if (_player._rectangle.Intersects(_targetRectangle) && (_player.items == PlayerItems.WeaponAndShield))
            {
                _currentEnemyState = EnemyState.Evading;
            }
            if (!_player._rectangle.Intersects(_targetRectangle))
            {
                _currentEnemyState = EnemyState.Patrolling;
            }
            if (_player._rectangle.Intersects(_rectangle))
            {
                _player.KillPlayer();
            }
        }

        public override void DrawObject(SpriteBatch pSpriteBatch)
        {
            base.DrawObject(pSpriteBatch);
            //uncomment this to draw the hitbox targetRectangle
            //DrawRectangle(pSpriteBatch);
        }
        /// <summary>
        /// If enabled (In DrawObject) this will draw the targets rectangle.
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        private void DrawRectangle(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(_hitboxColor, position, _targetRectangle, Color.Red);
        }
    }
}
