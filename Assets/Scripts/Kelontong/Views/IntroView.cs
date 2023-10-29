using System;
using System.Collections;
using System.Text.RegularExpressions;
using Arr.EventsSystem;
using Arr.ViewModuleSystem;
using Kelontong.Events.Story;
using Kelontong.StoryData;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kelontong.Views
{
    public class IntroView : View
    {
        [SerializeField] private MMF_Player dialogueFeedback;

        [SerializeField] private Button continueButton;
        [SerializeField] private TextMeshProUGUI lineText;
        [SerializeField] private float letterPause = 0.04f;

        private string targetText;
        private Coroutine typingCoroutine;

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

        private void SkipTyping()
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
            lineText.text = targetText;
        }

        public void DisplayLine(StoryLine line)
        {
            targetText = line;
            
            if (typingCoroutine != null) StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(TypeSentence());
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

            typingCoroutine = null;
        }
    }
}