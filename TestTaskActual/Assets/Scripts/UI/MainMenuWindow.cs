using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class MainMenuWindow:UIWindow
    {
        [SerializeField] private TMP_Text _maxRecord;

        public void Construct(int maxRecord)
        {
            if (maxRecord == 0)
            {
                _maxRecord.text = "0";
            }
            else
            {
                _maxRecord.text = maxRecord.ToString();
            }
        }
    }
}