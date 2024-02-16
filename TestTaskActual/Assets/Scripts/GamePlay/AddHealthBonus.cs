using System;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    public class AddHealthBonus:MonoBehaviour
    {
        [SerializeField] private int _healthBonus;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerHealth>(out var _playerHealth))
            {
                _playerHealth.AddHealth(2);
                Destroy(gameObject);
            }
        }
    }
}