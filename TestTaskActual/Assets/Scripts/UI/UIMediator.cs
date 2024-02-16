using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace.UI
{
    public class UIMediator:MonoBehaviour
    {
        private UIService _uiService;
        private GameLoop _loop;

        public void Construct(UIService uiService , GameLoop loop)
        {
            _loop = loop;
            _uiService = uiService;
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Pause()
        {
            GamePause.Paused = !GamePause.Paused;
            if (GamePause.Paused)
            {
                _uiService.OpenPause();
            }
            else
            {
                _uiService.ClosePause();
            }
        }
        
        public void StartGame() => _loop.StartGame();

        public void GoToMenu() => _loop.GoToMenu();
    }
}