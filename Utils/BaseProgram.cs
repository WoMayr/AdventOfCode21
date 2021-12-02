﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class BaseProgram
    {
        public static void BaseMain<TDay>(Action<TDay> action)
             where TDay : BaseDay
        {
            BaseMain<TDay, Object>((day, _, _) => action(day));
        }
        public static void BaseMain<TDay>(Action<TDay, IServiceProvider> action)
             where TDay : BaseDay
        {
            BaseMain<TDay, Object>((day, serviceProvider, _) => action(day, serviceProvider));
        }
        public static void BaseMain<TDay, TProgram>(Action<TDay, IServiceProvider, ILogger<TProgram>> action)
             where TDay : BaseDay
        {
            var services = Setup.SetupDependencyInjection<TDay>();
            var logger = services.GetRequiredService<ILogger<TProgram>>();

            var day = services.GetRequiredService<TDay>();
            day.Input = File.ReadAllText("input.txt");

            action(day, services, logger);
        }
    }
}
