using System;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMover:MonoBehaviour
    {
        [SerializeField] private float _upSpeed;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private float _xPos;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetXPos(float x)
        {
            _xPos = x;
        }

        private void FixedUpdate()
        {
            if (!GamePause.Paused)
            {
                Vector2 nextPos = new Vector2(_xPos , transform.position.y + _upSpeed);
                _rigidbody2D.MovePosition(nextPos);
            }
        }
    }
}