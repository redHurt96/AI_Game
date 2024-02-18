using System.Linq;
using System.Reflection;
using System.Text;

namespace _Project.Game.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetFieldsDescription(this object target) =>
            new StringBuilder()
                .AppendJoin("\n", 
                    target
                        .GetType()
                        .GetFields(BindingFlags.Public | BindingFlags.Instance)
                        .Where(x => !x.IsInitOnly)
                        .Select(x => $"{x.Name} - {x.GetValue(target)}"))
                .ToString();
    }
}