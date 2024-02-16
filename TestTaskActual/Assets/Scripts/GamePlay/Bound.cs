using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    public class Bound:MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.gameObject.TryGetComponent<PlayerHealth>(out var p))
                Destroy(other.gameObject);
        }
    }
}