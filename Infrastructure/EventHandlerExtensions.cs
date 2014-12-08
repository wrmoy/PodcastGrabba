using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class EventHandlerExtensions
    {
        public static void SafeInvoke(this EventHandler thisEventHandler, object sender, EventArgs args)
        {
            EventHandler handler = thisEventHandler;
            if (handler != null)
            {
                handler(sender, args);
            }
        }
    }
}
