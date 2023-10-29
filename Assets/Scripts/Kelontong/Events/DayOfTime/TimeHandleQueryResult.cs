using Kelontong.Modules;

namespace Kelontong.Events
{
    public class TimeHandleQueryResult
    {
        public IDayOfTimeHandle handle;

        public TimeHandleQueryResult(IDayOfTimeHandle handle)
        {
            this.handle = handle;
        }
    }
}