using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    public class PlayerHealth: MonoBehaviour , IHealth
    {
        private List<GameObject> _healthIndicators;
        private int _maxHealth;
        private int _heath;
        private Action _lose;
        private bool _dead;
        public event Action OnDead;

        public void Construct(Action lose , GameObject[] healthIndicators) 
        {
            _lose = lose;
            _healthIndicators = healthIndicators.ToList();
            _maxHealth = _healthIndicators.Count;
            _heath = _maxHealth;
        }
        public void GetDamage()
        {
            _heath--;
            if (_heath > 0)
            {
                UpdateIndicator();
            }
            else
            {
                if (!_dead)
                {
                    Die();
                    _lose.Invoke();
                } 
            }
        }

        public void AddHealth(int bonus)
        {
            _heath += bonus;
            if (_heath > _maxHealth)
            {
                _heath = _maxHealth;
            }
            UpdateIndicator();
        }

        public void RestoreHealth()
        {
            _heath = _maxHealth;
            UpdateIndicator();
        }

        private void UpdateIndicator()
        {
            _healthIndicators.ForEach(x => x.gameObject.SetActive(true));
            for (int i = 0; i < _maxHealth - _heath  ; i++)
            {
                _healthIndicators[_healthIndicators.Count - i - 1].SetActive(false);
            }
        }

        public void Die()
        {
            if (!_dead)
            {
                _dead = true;
                OnDead?.Invoke();   
                Destroy(gameObject);
            }
        }
    }
}