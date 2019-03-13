using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.Test.MlNet.ConsoleApp.Common
{
    public static class ConsoleHelper
    {
        internal static void PrintEvaluateResult(MultiClassClassifierMetrics metrics)
        {
            Console.WriteLine($"*************************************************************************************************************");
            Console.WriteLine($"*       Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"*------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"*       MicroAccuracy:    {metrics.AccuracyMicro:0.###}");
            Console.WriteLine($"*       MacroAccuracy:    {metrics.AccuracyMacro:0.###}");
            Console.WriteLine($"*       LogLoss:          {metrics.LogLoss:#.###}");
            Console.WriteLine($"*       LogLossReduction: {metrics.LogLossReduction:#.###}");
            Console.WriteLine($"*************************************************************************************************************");
        }
    }
}
