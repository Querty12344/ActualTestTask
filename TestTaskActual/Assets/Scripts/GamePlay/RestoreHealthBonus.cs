using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    public class RestoreHealthBonus:MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerHealth>(out var _playerHealth))
            {
                _playerHealth.RestoreHealth();
                Destroy(gameObject);
            }
        }

    }
}