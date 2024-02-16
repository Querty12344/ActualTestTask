using DefaultNamespace.GamePlay;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrap:MonoBehaviour , ICoroutineRunner
    {
        [SerializeField] private AssetHandler _assetHandler;
        [SerializeField] private GenerationSettings _generationSettings;
        private ServiceLocator _serviceLocator;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            _serviceLocator = new ServiceLocator();
            _serviceLocator.InitServices(this ,_assetHandler , _generationSettings );
            _serviceLocator.GameLoop.LoadStart();
        }
    }
}