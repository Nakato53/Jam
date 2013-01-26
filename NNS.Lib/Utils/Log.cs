using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NNS.Lib.Entities.Screens;

namespace NNS.Lib.Utils
{
    public class Log : IDisposable
    {
        public Log()
        {
            Events.register("ScreenManager::changeScreen", (Action<Object>)this.WriteInConsole);
        }


        public void WriteInConsole(Object message)
        {
            Console.WriteLine("Log => " + message.ToString());
        }

        public void Dispose()
       {
           Events.unregister(this);;
        }

    }
}
