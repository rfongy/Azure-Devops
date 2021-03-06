﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;

namespace ModernUIApp {
    public class Program {
        public static void Main (string[] args) {
            BuildWebHost (args).Run ();
        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .ConfigureAppConfiguration ((context, builder) => {
                IHostingEnvironment env = context.HostingEnvironment;
                builder.AddEnvironmentVariables ();
            })
            .UseStartup<Startup> ()
            .UseApplicationInsights()
            .Build ();
    }
}