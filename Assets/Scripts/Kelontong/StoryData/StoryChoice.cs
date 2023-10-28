using System.Collections.Generic;

namespace Kelontong.StoryData
{
    public class StoryChoice
    {
        private string text;
        private List<string> tags;

        public string Text => text;

        public StoryChoice(string text, List<string> tags)
        {
            this.text = text;
            this.tags = tags;
        }

        public static implicit operator string(StoryChoice choice) => choice.text;
    }
}