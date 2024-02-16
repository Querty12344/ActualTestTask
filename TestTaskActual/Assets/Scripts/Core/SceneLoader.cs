using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneLoader
    {
        private const string _gameSceneName = "Game";
        private const string _menuSceneName = "Menu";
        private ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        public void LoadScene(Scenes scene , Action OnLoad = null)
        {
            string sceneName = "";
            switch (scene)
            {
                case Scenes.Menu:
                    sceneName = _menuSceneName;
                    break;
                case Scenes.Game:
                    sceneName = _gameSceneName;
                    break;
            }
            _coroutineRunner.StartCoroutine(LoadSceneByName(sceneName , OnLoad));
        }
        
        
        private IEnumerator LoadSceneByName(string name,Action onLoad = null)
        {
            
            AsyncOperation loading;
            loading = SceneManager.LoadSceneAsync(name);
            while (true)
            {
                if (!loading.isDone) yield return null;
                else
                {
                    break;
                }
            }
            onLoad?.Invoke();
            
        }
    }
}