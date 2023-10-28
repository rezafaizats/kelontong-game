namespace Kelontong.Events.Story
{
    public struct StoryValueQuery
    {
        public string name;

        public StoryValueQuery(string name)
        {
            this.name = name;
        }
    }

    public class StoryValueQueryResult
    {
        public readonly bool found;
        private object result;

        public StoryValueQueryResult(bool found, object result)
        {
            this.found = found;
            this.result = result;
        }

        public T As<T>() => (T) result;

        public bool TryAs<T>(out T value)
        {
            value = default;
            if (result is not T t) return false;
            value = t;
            return true;
        }
    }
}