using UnityEngine;

namespace DefaultNamespace.GamePlay
{
    [CreateAssetMenu(menuName = "EnemySpawnSettings" , fileName = "EnemySpawnSettings")]
    public class GenerationSettings:ScriptableObject
    {
        public float SpawnOffset;
        public int BigRewardChance;
        public int SmallRewardChance;
    }
}