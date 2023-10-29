using System;
using System.Collections.Generic;

namespace Kelontong.StoryData
{
    public class StoryLine
    {
        private const string SPEAKER = "speaker";
        
        public string Text => text;
        
        private string text;
        private List<string> tags;

        public StoryLine(string text, List<string> tags)
        {
            this.text = text;
            this.tags = tags;
        }

        public bool TryGetSpeaker(out string speaker)
        {
            speaker = String.Empty;
            
            foreach (var tag in tags)
            {
                if (!tag.StartsWith(SPEAKER)) continue;
                speaker = tag.Remove(0, tag.IndexOf(' ')).Trim();
                return true;
            }

            return false;
        }
        
        public static implicit operator string(StoryLine line) => line.text;
    }
}