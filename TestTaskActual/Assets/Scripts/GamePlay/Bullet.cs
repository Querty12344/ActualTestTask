using System;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet:MonoBehaviour
    {
        [SerializeField] private bool _enemyBullet;
        [SerializeField] private float _speed;
        [SerializeField] private Effect _collisioneEffect;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _direction;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Init(Vector2 direction)
        {
            if (_enemyBullet)
            {
                transform.up = -direction;
            }
            else
            {
                transform.up = direction;
            }
            _direction = direction;
        }

        private void FixedUpdate()
        {
            if(!GamePause.Paused)
                _rigidbody2D.MovePosition((Vector2)transform.position + _direction*_speed);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_enemyBullet)
            {
                if (other.TryGetComponent<PlayerHealth>(out var h))
                {
                    Hit(h);
                }
                
            }
            else
            {
                if (other.TryGetComponent<EnemyHealth>(out var h))
                {
                    Hit(h);
                }
            }
            
        }

        private void Hit(IHealth health)
        {
            health.GetDamage();
            Instantiate(_collisioneEffect, transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
}