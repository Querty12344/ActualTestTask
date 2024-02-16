using UnityEngine;

namespace DefaultNamespace
{
    public class Score
    {
        private const int _enemyScore = 10;
        private const string _scoreSaveKey = "score";
        private int _currentScore;
        public void AddEnemyScore()
        {
            _currentScore += _enemyScore;
        }
        public int GetMax()
        {
            if (PlayerPrefs.HasKey(_scoreSaveKey))
            {
                return PlayerPrefs.GetInt(_scoreSaveKey);
            }
            return 0;
        }
        public int GetCurrent() => _currentScore;

        public void SaveScore()
        {
            if (PlayerPrefs.HasKey(_scoreSaveKey))
            {
                if (PlayerPrefs.GetInt(_scoreSaveKey) < _currentScore)
                {
                    PlayerPrefs.SetInt(_scoreSaveKey , _currentScore);
                }
            }
            else
            {
                PlayerPrefs.SetInt(_scoreSaveKey , _currentScore);
            }
        }
        
        public void ClearCurrentScore() => _currentScore = 0;
    }
}