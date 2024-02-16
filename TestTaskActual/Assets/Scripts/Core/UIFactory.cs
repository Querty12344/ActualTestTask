using DefaultNamespace.UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class UIFactory
    {
        private AssetHandler _assetHandler;
        private GameLoop _gameLoop;
        private UIService _uiService;

        public void Construct(AssetHandler assetHandler , UIService uiService , GameLoop gameLoop)
        {
            _uiService = uiService;
            _gameLoop = gameLoop;
            _assetHandler = assetHandler;
        }
        
        public UIWindow CreatePauseWindow()
        {
            UIWindow pause =Object.Instantiate(_assetHandler.Pause);
            pause.GetComponent<UIMediator>().Construct(_uiService , _gameLoop);
            return pause;
        } 

        public UIWindow CreateLoseWindow(int maxScore, int currentScore)
        {
            LoseWindow loseWindow = Object.Instantiate(_assetHandler.Lose);
            loseWindow.Construct(maxScore , currentScore);
            loseWindow.GetComponent<UIMediator>().Construct(_uiService , _gameLoop);
            return loseWindow;
        }

        public UIWindow CreateHud(Score score)
        {
            HudWindow hud = Object.Instantiate(_assetHandler.Hud);
            hud.Construct(score);
            hud.GetComponent<UIMediator>().Construct(_uiService , _gameLoop);
            return hud;
        }

        public UIWindow CreateMainMenu(int maxScore)
        {
            MainMenuWindow mainMenuWindow = Object.Instantiate(_assetHandler.Menu);
            mainMenuWindow.Construct(maxScore);
            mainMenuWindow.GetComponent<UIMediator>().Construct(_uiService , _gameLoop);
            return mainMenuWindow;
        }
        

    }
}