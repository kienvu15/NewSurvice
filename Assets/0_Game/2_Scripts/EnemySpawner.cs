using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<GameObject> enemyPrefabs;
        public List<string> enemyName;
        public List<int> enemyCount;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    public List<Wave> waves;

}
