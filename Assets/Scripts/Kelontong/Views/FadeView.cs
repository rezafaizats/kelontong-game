using Arr.ViewModuleSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class FadeView : View
    {
        [SerializeField] private Image fade;
        
        public void StartFadeIn(float duration)
        {
            var color = fade.color;
            color.a = 1f;
            fade.color = color;
            fade.CrossFadeAlpha(0f, duration, true);
        }

        public void StartFadeOut(float duration)
        {
            var color = fade.color;
            color.a = 0f;
            fade.color = color;
            fade.CrossFadeAlpha(1f, duration, true);
        }
    }
}