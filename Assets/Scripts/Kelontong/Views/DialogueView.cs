using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Dialogue;
using Kelontong.Events.Story;
using Kelontong.StoryData;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class DialogueView : View, IPreventAction
    {
        [SerializeField] private MMF_Player dialogueFeedback;
        [SerializeField] private Button continueButton;
        [SerializeField] private TextMeshProUGUI lineText, speakerText;
        [SerializeField] private GameObject choiceGroup, speakerGroup;
        [SerializeField] private ChoiceElement[] elements;
        [SerializeField] private float letterPause = 0.1f;
        
        private string targetText;
        private Coroutine typingCoroutine = null;

        public override bool ActiveOnSpawn => false;

        private void Awake()
        {
            continueButton.onClick.AddListener(OnContinue);
            dialogueFeedback.Initialization(gameObject);
        }

        private void OnContinue()
        {
            if (typingCoroutine != null) SkipTyping();
            else GlobalEvents.Fire(new ContinueStoryEvent());
        }

        public void DisplayChoices(StoryChoice[] choices)
        {
            choiceGroup.SetActive(true);

            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i];
                bool active = i < choices.Length;
                element.gameObject.SetActive(active);
                if (!active) continue;
                
                element.Display(i, choices[i]);
            }
        }

        public void HideChoices()
        {
            choiceGroup.SetActive(false);
        }

        public void DisplayLine(StoryLine line)
        {
            bool hasSpeaker = line.TryGetSpeaker(out var speaker);
            speakerGroup.SetActive(hasSpeaker);

            if (hasSpeaker) speakerText.text = $"{speaker}:";

            targetText = line;
            
            if (typingCoroutine != null) StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(TypeSentence());
        }

        public void SkipTyping()
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            lineText.text = targetText;
        }
        
        IEnumerator TypeSentence()
        {
            lineText.text = "";

            // This regex pattern will match any TMP tags.
            string pattern = @"<.*?>";

            string[] parts = Regex.Split(targetText, pattern);

            int currentIndex = 0;
            foreach (string part in parts)
            {
                if (Regex.IsMatch(part, pattern))
                {
                    // If the part is a TMP tag, append it whole without delay.
                    lineText.text += part;
                }
                else
                {
                    // If the part is normal text, reveal it letter by letter.
                    foreach (char letter in part)
                    {
                        lineText.text += letter;
                        currentIndex++;
                        dialogueFeedback.PlayFeedbacks();
                        yield return new WaitForSeconds(letterPause);
                    }
                }
            }
        }
    }
}