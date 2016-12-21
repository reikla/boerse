using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StockExchange.Startup))]
namespace StockExchange
{
    public partial class Startup
    {

        private static readonly Timer _timer = new Timer(OnTimerElapsed);


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            _timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(10));
            


            Debug.WriteLine("Hello");

        }

        private static void OnTimerElapsed(object sender)
        {
            Debug.WriteLine("Hello Timer");
        }


    }
}
