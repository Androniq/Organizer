using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Organizer.Extensions
{
    public static class ObservableExtensions
    {
        /// <summary>
        /// Performs an operation on existing or future item of the Observable Collection.
        /// </summary>
        /// <typeparam name="T">Collection item type.</typeparam>
        /// <param name="this">The collection.</param>
        /// <param name="predicate">The filter to find the item.</param>
        /// <param name="callback">The callback to perform when an appropriate item is found.</param>
        public static void On<T>(this ObservableCollection<T> @this, Func<T, bool> predicate, Action<T> callback)
        {
            if (@this.Any(predicate))
            {
                callback(@this.First(predicate));
            }
            else
            {
                void Handler(object sender, NotifyCollectionChangedEventArgs args)
                {
                    if (args.NewItems == null) return;
                    var list = args.NewItems.OfType<T>().Where(predicate).ToList();
                    if (!list.Any()) return;
                    @this.CollectionChanged -= Handler;
                    callback(list.First());
                }

                @this.CollectionChanged += Handler;
            }
        }
    }
}
