using System.Security.Cryptography;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameLoop
    {
        private SceneLoader _sceneLoader;
        private UIService _uiService;
        private readonly Score _score;
        private readonly LevelGenerator _levelGenerator;

        public GameLoop(SceneLoader sceneLoader , UIService uiService , Score score , LevelGenerator levelGenerator)
        {
            _uiService = uiService;
            _score = score;
            _levelGenerator = levelGenerator;
            _sceneLoader = sceneLoader;
        }

        public void StartGame()
        {
            GamePause.Paused = false;
            _score.ClearCurrentScore();
            _sceneLoader.LoadScene(Scenes.Game,InitGameScene);
        }
        
        public void Lose()
        {
            ClearLevel();
            _uiService.OpenLoseInterface(_score.GetMax(), _score.GetCurrent());
            _score.SaveScore();
        }

        public void LoadStart()
        {
            _sceneLoader.LoadScene(Scenes.Menu , () => _uiService.OpenMainMenu(_score.GetMax()));
        }
        public void GoToMenu()
        {
            ClearLevel();
            _sceneLoader.LoadScene(Scenes.Menu , () => _uiService.OpenMainMenu(_score.GetMax()));
        }

        private void ClearLevel()
        {
            GamePause.Paused = true;
            _levelGenerator.StopGeneration();
            _levelGenerator.Clear();
        }

        private void InitGameScene()
        {
            _uiService.LoadGameInterface(_score);
            _levelGenerator.InitPlayer(Lose);
            _levelGenerator.StartGeneration();
        }
    }
}