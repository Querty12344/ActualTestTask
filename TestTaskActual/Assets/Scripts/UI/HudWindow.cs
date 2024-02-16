using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class HudWindow:UIWindow
    {
        [SerializeField] private TMP_Text _currentScore;
        private Score _score;

        public void Construct(Score score) => _score = score;

        private void Update()
        {
            _currentScore.text = _score.GetCurrent().ToString();
        }
    }
}