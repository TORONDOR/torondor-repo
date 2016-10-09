using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class ContinueInMain
    {
        //Continue method with parameters Action 
        public static Task ContinueInMainThread(this Task task, Action action)
        {
            return task.ContinueWith(t => action.Invoke(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        //Continue method with parameters Action<Task>
        public static Task ContinueInMainThread(this Task task, Action<Task> action)
        {
            return task.ContinueWith(t => action.Invoke(t), TaskScheduler.FromCurrentSynchronizationContext());
        }

        //Continue method with parameters Func<T>
        public static Task<T> ContinueInMainThreadueUI<T>(this Task<T> task, Func<T> action)
        {
            return task.ContinueWith(t => action.Invoke(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        //Continue method with parameters Func<Task,T>
        public static Task<T> ContinueInMainThread<T>(this Task<T> task, Func<Task, T> action)
        {
            return task.ContinueWith(t => action.Invoke(t), TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
