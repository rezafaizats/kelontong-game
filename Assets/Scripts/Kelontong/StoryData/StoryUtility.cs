using Arr.EventsSystem;
using Kelontong.Events.Story;

namespace Kelontong.StoryData
{
    public static class StoryUtility
    {
        public static T GetVariable<T>(string varName)
        {
            var result = GlobalEvents.Query<StoryValueQueryResult, StoryValueQuery>(new StoryValueQuery(varName));
            return result.As<T>();
        }

        public static void SetVariable(string varName, object value)
        {
            GlobalEvents.Fire(new SetStoryVariableEvent(varName, value));
        }
    }
}