using CrystalWind.Test.MlNet.ConsoleApp.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrystalWind.Test.MlNet.ConsoleApp.Common
{
    public static class FileHelper
    {

        public static string DataPath { get; private set; } = @"Datas\datas.csv";

        public static string[] FeatureNames { get; private set; } = new[] {nameof(DataInfo.Input1), nameof(DataInfo.Input2) };

        public static string LabelName { get; private set; } = nameof(DataInfo.Result);
    }
}
