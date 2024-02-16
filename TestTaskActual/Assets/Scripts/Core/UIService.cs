using System.Collections.Generic;
using DefaultNamespace.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIService
    {
        private readonly UIFactory _factory;
        private UIWindow _menu;
        private UIWindow _pause;
        private UIWindow _lose;
        private UIWindow _hud;
        
        public UIService(UIFactory factory)
        {
            _factory = factory;
        }

        public void OpenMainMenu(int maxScore)
        {
            if (_menu == null)
            {
                _menu = _factory.CreateMainMenu(maxScore);
            }
        }
        
        public void LoadGameInterface(Score score)
        {
            _hud = _factory.CreateHud(score);
        }

        public void OpenPause()
        {
            _pause = _factory.CreatePauseWindow();
        }

        public void ClosePause()
        {
            if (_pause != null)
            {
                GameObject.Destroy(_pause.gameObject);
            }
        }

        public void OpenLoseInterface(int max, int current)
        {
            _lose = _factory.CreateLoseWindow(max, current);
        }
    }
}