using System;
using Arr.SDS;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kelontong.ScriptableDatabases
{
    [Serializable]
    public struct CustomerSpawnPoolData : IScriptableKey<int>
    {
        public int day;
        public float specialChancePercent;
        public GameObject[] special;
        public GameObject[] repeating;
        public int Key => day;

        public GameObject GetRandomRepeating()
            => repeating[Random.Range(0, repeating.Length)];
    }
    
    [CreateAssetMenu(menuName = "Customer Spawn Pool Database")]
    public class CustomerSpawnPoolDatabase : PairScriptableDatabase<int, CustomerSpawnPoolData>
    {
        
    }
}