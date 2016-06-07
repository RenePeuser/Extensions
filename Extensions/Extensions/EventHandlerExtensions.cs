using System;

namespace Extensions
{
    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler handler, object sender, EventArgs args)
        {
            handler?.Invoke(sender, args);
        }
    }
}