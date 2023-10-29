using System;
using Arr.EventsSystem;
using Kelontong.Events.Story;
using Kelontong.StoryData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Dialogue
{
    public class ChoiceElement : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI contentText;

        private int choiceIndex;
        
        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            GlobalEvents.Fire(new ChooseStoryChoiceEvent(choiceIndex));
        }

        public void Display(int index, StoryChoice choice)
        {
            choiceIndex = index;
            contentText.text = choice;
        }
    }
}