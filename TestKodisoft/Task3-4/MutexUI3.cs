using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_4
{
    public partial class MutexUI
    {
        private Queue<Task> Tasks = new Queue<Task>();

        public MutexUI()
        {
            _releaser = new Releaser(_semaphore);
            _releaserTask = Task.FromResult(_releaser);

            Tasks.Enqueue(Task.Factory.StartNew(() => { }));
        }

        public Task Lock()
        {
            lock (Tasks)
            {
                Tasks.Enqueue(new Task(() => { }));
                return Tasks.Peek();
            }
        }

        public void Release()
        {
            lock (Tasks)
            {
                if (Tasks.Count > 0)
                {
                    Tasks.Dequeue();
                    if (Tasks.Peek().IsCompleted == false)
                        Tasks.Peek().Start();
                }
            }
        }
    }
}
