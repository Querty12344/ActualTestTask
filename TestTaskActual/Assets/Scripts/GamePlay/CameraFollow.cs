using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.GamePlay
{
    public class CameraFollow:MonoBehaviour
    {
        [SerializeField] private float _yOffset;
        private Transform _player;
        private bool _playerExists;
        private PlayerHealth _playerHealth;

        public void SetPlayer(PlayerHealth playerHealth)
        {
            _playerExists = true;
            _playerHealth = playerHealth;
            _player = _playerHealth.transform;
            _playerHealth.OnDead += PlayerDead;
        }

        private void Update()
        {
            if (_playerExists)
            {
                Vector3 nextPos = transform.position;
                nextPos.y = _player.position.y + _yOffset;
                transform.position = nextPos;
            }
        }

        private void PlayerDead()
        {
            _playerHealth.OnDead -= PlayerDead;
            _playerExists = false;
        }
    }
}