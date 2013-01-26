using System;
using NNS.Lib.Main;


namespace NoNameShooter
{
#if WINDOWS || XBOX
    static class Program
    {
      
        static void Main(string[] args)
        {
            using (WinGame game = new WinGame())
            {
                game.Run();
            }
        }
    }
#endif
}

