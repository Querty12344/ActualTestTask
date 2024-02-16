using System;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    
    public class Effect:MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private float _lifeTime;
        [SerializeField] private float _destroyTimer;
        private bool _hasParticleSystem;

        private void Start()
        {
            _hasParticleSystem = _particleSystem != null;
            Destroy(gameObject , _lifeTime);
        }

        private void Update()
        {
            if (!GamePause.Paused)
            {
                _destroyTimer += Time.deltaTime;
                if (_destroyTimer >= _lifeTime)
                {
                    Destroy(gameObject);
                }

                if (_hasParticleSystem && _particleSystem.isPaused)
                {
                    _particleSystem.Play(true);
                }
            }
            else
            {
                if (_hasParticleSystem && !_particleSystem.isPaused)
                {
                    _particleSystem.Pause(true);
                }
            }
        }
    }
}