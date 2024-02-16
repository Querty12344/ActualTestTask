using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.GamePlay
{
    public class EnemyHealth:MonoBehaviour,IHealth
    {
        [SerializeField] private Effect _deathEffect;
        [SerializeField] private int _health;
        private Action<Vector3> _onDeath;
        private Score _score;
        
        public void Construct(Score score, Action<Vector3> onDeath = null)
        {
            _onDeath = onDeath;
            _score = score;
        }
        public void GetDamage()
        {
            _health--;
            if (_health <= 0)
            {
                _onDeath?.Invoke(transform.position);
                Instantiate(_deathEffect , transform.position , quaternion.identity);
                _score.AddEnemyScore();
                Destroy(gameObject);
            }
        }
    }
}