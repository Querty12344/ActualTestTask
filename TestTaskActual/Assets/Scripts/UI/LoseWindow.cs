using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class LoseWindow:UIWindow
    {
        [SerializeField] private TMP_Text _maxScore;
        [SerializeField] private TMP_Text _current;
        [SerializeField] private GameObject _newRecordIndicator;

        public void Construct(int maxScore , int current )
        {
            if (current > maxScore)
            {
                _maxScore.text = current.ToString();
                _current.text = current.ToString();
                _newRecordIndicator.SetActive(true);
            }
            else
            {
                _maxScore.text = maxScore.ToString();
                _current.text = current.ToString();
                _newRecordIndicator.SetActive(false);
            }
        }
    }
}