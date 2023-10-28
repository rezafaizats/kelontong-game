using System;
using System.Reflection;

namespace Kelontong.StoryData
{
    public static class StoryEventMetadata
    {
        public static void BindEvents(Action<MethodInfo> forEachMethods)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                    foreach (var method in methods)
                    {
                        if (method.GetCustomAttribute<StoryEventAttribute>() == null) continue;
                        forEachMethods.Invoke(method);
                    }
                }
            }
        }
    }
}