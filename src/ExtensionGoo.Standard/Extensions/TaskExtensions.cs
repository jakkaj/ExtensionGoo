using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionGoo.Standard.Extensions
{
    public static class TaskExtensions
    {
        public static Task WhenAllList<T>(this List<T> list, Func<T, Task> func)
        {
            return Task.WhenAll(list.Select(func).ToList());
        }

        public static async Task<IList<TResult>> WhenAllEnum<T, TResult>(this IEnumerable<T> list, Func<T, Task<TResult>> func)
        {
            return await Task.WhenAll(list.Select(func));
        }
    }
}
