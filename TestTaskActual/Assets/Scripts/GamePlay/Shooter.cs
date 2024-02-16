using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    public class Shooter:MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawn;
        [SerializeField] private Vector2 _shootDirection;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private float _shootTimeOffset;

        private void Start()
        {
            StartCoroutine(Shooting());
        }

        private IEnumerator Shooting()
        {
            while (true)
            {
                if (GamePause.Paused)
                {
                    yield return null;
                }
                else
                {
                    Instantiate(_bullet, _bulletSpawn.position, Quaternion.identity).Init(_shootDirection);
                    yield return new WaitForSeconds(_shootTimeOffset);
                }
            }
        }
    }
}