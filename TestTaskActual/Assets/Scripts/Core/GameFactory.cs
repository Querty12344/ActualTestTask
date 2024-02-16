using System;
using DefaultNamespace.GamePlay;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class GameFactory
    {
        private AssetHandler _assetHandler;
        private int _previousPlaceIndex;
        private Score _score;
        private GameScenePosHandler _posHandler;
        private GenerationSettings _generationSettings;

        public GameFactory(AssetHandler assetHandler, Score score,GenerationSettings generationSettings )
        {
            _generationSettings = generationSettings;
            _score = score;
            _assetHandler = assetHandler;
        }

        public Player CreatePlayer(Action lose)
        {
            InputService inputService = GameObject.FindGameObjectWithTag("Input").GetComponent<InputService>();
            Player player = Object.Instantiate(_assetHandler.Player , _posHandler.PlayerSpawnPos.position , Quaternion.identity);
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            health.Construct(lose, GameObject.FindObjectOfType<HealthIndicator>().Indicators);
            inputService.SetPlayer(player.GetComponent<PlayerMover>() , health);
            Camera.main.GetComponent<CameraFollow>().SetPlayer( health);
            return player;
        }

        public Enemy CreateRandomEnemy()
        {
            int placeIndex = ChooseRandomPlace(_posHandler.EnemySpawnPoses.Length);
            int enemyIndex = Random.Range(0, _assetHandler.Enemies.Length);
            Enemy enemy = Object.Instantiate(_assetHandler.Enemies[enemyIndex], _posHandler.EnemySpawnPoses[placeIndex].position , quaternion.identity);
            enemy.GetComponent<EnemyHealth>().Construct(_score, CreateRandomMedicine);
            return enemy;
        }

        private void CreateRandomMedicine(Vector3 at)
        {
            var chance = Random.Range(0, 100);
            
            if (chance <_generationSettings.BigRewardChance)
            {
                Object.Instantiate(_assetHandler.RestoreHealthBonus , at, quaternion.identity);
                return;
            }

            if (chance <_generationSettings.SmallRewardChance)
            {
                Object.Instantiate(_assetHandler.AddHealthBonus , at, quaternion.identity);
                return;
            }
        }

        private int ChooseRandomPlace(int max)
        {
            int placeIndex = Random.Range(0 , max);
            if (placeIndex == _previousPlaceIndex)
            {
                placeIndex += 1;
                if (placeIndex == max)
                {
                    placeIndex = 0;
                }
            }
            _previousPlaceIndex = placeIndex;
            return placeIndex;
        }

        public void InitOnScene() => _posHandler = GameObject.FindObjectOfType<GameScenePosHandler>();
    }
}