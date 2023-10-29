
using Kelontong.Products;
using UnityEngine;

namespace Kelontong.World
{
    public class DisplayProductElement : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public void DisplayItem(string id) {
            var productData = ProductDatabase.Get(id);
            spriteRenderer.sprite = productData.icon;
        }
    }
}