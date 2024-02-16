using DefaultNamespace.GamePlay;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class ServiceLocator
    {
        public GameLoop GameLoop;
        private UIFactory _uiFactory;
        private UIService _uiService;
        private SceneLoader _sceneLoader;
        private Score _score;
        private GameFactory _gameFactory;
        private LevelGenerator _levelGenerator;


        public void InitServices(ICoroutineRunner coroutineRunner , AssetHandler assetHandler, GenerationSettings generationSettings)
        {
            _sceneLoader = new SceneLoader(coroutineRunner);
            _score = new Score();
            _gameFactory = new GameFactory(assetHandler, _score , generationSettings);
            _uiFactory = new UIFactory();
            _uiService = new UIService(_uiFactory);
            _levelGenerator = new LevelGenerator(_gameFactory , generationSettings , coroutineRunner);
            GameLoop = new GameLoop(_sceneLoader , _uiService , _score , _levelGenerator);
            _uiFactory.Construct(assetHandler , _uiService , GameLoop);
        }
        
    }
}