using System;
using Arr.SDS;
using UnityEngine;

namespace Kelontong.Products
{
    [Serializable]
    public class ProductData : IScriptableKey<string>
    {
        public string Key => id;
        public string id;
        public string label;
        public Sprite icon;
    }

    public class ProductDatabase : PairScriptableDatabase<string, ProductData>
    {
        
    }
    
}