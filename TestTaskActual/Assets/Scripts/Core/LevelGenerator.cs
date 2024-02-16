using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.GamePlay;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelGenerator
    {
        private List<Enemy> _pool = new List<Enemy>();
        private Player _player;
        private GameFactory _gameFactory;
        private GenerationSettings _generationSettings;
        private ICoroutineRunner _coroutineRunner;
        private Coroutine _generation;
        private bool _generating;

        public LevelGenerator(GameFactory gameFactory ,GenerationSettings generationSettings,ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _generationSettings = generationSettings;
            _gameFactory = gameFactory;
        }

        public void InitPlayer(Action lose)
        {
            _gameFactory.InitOnScene();
            _player = _gameFactory.CreatePlayer(lose);
        }

        public void StartGeneration()
        {
            _generating = true;
            _generation = _coroutineRunner.StartCoroutine(Generation());
        }

        public void StopGeneration()
        {
            _generating = false;
            _coroutineRunner.StopCoroutine(_generation);
        }

        private IEnumerator Generation()
        {
            while (_generating)
            {
                yield return new WaitForSeconds(_generationSettings.SpawnOffset);
                if (_generating)
                {
                    _pool.Add(_gameFactory.CreateRandomEnemy()); 
                }
            }
        }

        public void Clear()
        {
            if(_player != null)
                _player.GetComponent<PlayerHealth>().Die();
            foreach (var enemy in _pool)
            {
                if (enemy != null)
                {
                    GameObject.Destroy(enemy.gameObject);
                }
            }
             GameObject.FindObjectsOfType<Bullet>().ToList().ForEach(x=> GameObject.Destroy(x.gameObject));
        }
    }
}