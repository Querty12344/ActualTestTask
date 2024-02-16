using System;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    public class InputService:MonoBehaviour
    {
        [SerializeField] private ButtonPressedInfo _pressedInfo;
        private bool _playerExists;
        private PlayerMover _playerMover;
        private PlayerHealth _playerHealth;


        public void SetPlayer(PlayerMover playerMover , PlayerHealth playerHealth)
        {
            playerHealth.OnDead += PlayerDead;
            _playerHealth = playerHealth;
            _playerMover = playerMover;
            _playerExists = true;
        }

        private void PlayerDead()
        {
            _playerHealth.OnDead -= PlayerDead;
            _playerExists = false;
        }
        private void Update()
        {
            if(_pressedInfo.Pressed && _playerExists)
                _playerMover.SetXPos(Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition).x);
        }
    }
}