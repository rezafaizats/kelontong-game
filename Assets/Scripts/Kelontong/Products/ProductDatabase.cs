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
        public string productName;
        public string label;
        public Sprite icon;
    }

    [CreateAssetMenu(fileName = "Product Database", menuName = "Product Databse")]
    public class ProductDatabase : PairScriptableDatabase<string, ProductData>
    {
        
    }
    
}