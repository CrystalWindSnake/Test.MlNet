using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.ML.Data;

namespace CrystalWind.Test.MlNet.ConsoleApp.DataStructures
{
    public class DataInfo
    {
        [LoadColumn(0)]
        public UInt32 Id { get; set; }

        [LoadColumn(1)]
        public float Input1 { get; set; }

        [LoadColumn(2)]
        public float Input2 { get; set; }

        [LoadColumn(6)]
        public string Result { get; set; }

    }
}
