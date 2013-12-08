using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISTask
{
    public class IISTaskFactory
    {
        public static Task StartNew(Action act)
        {
            IISNotifier notif = new IISNotifier();
            return Task.Factory.StartNew(() => {
                act.Invoke();
                notif.Finished();
            });
        }

        public static Task StartNew(Action act, TaskCreationOptions options)
        {
            IISNotifier notif = new IISNotifier();
            return Task.Factory.StartNew(() =>
            {
                act.Invoke();
                notif.Finished();
            }, options);
        }
    }
}
