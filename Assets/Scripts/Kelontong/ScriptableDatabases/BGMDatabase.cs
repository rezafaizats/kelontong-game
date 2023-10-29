using Arr.SDS;
using UnityEngine;

namespace Kelontong.ScriptableDatabases
{
    public class BGMData : IScriptableKey<string>
    {
        public string id;
        public AudioClip clip;
        public string Key => id;
    }
    
    [CreateAssetMenu(menuName = "BGM Database")]
    public class BGMDatabase : PairScriptableDatabase<string, BGMData>
    {
        
    }
}