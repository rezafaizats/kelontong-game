using System;
using System.Collections.Generic;
using Arr.SDS;
using UnityEngine;

namespace Kelontong.ScriptableDatabases
{
    [Serializable]
    public class InkData : IScriptableKey<string>
    {
        public string id;
        public TextAsset inkFile;
        public string Key => id;
    }
    
    [CreateAssetMenu(menuName = "Ink Database")]
    public class InkDatabase : PairScriptableDatabase<string, InkData>
    {
    }
}