using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.ML.Data;

namespace CrystalWind.Test.MlNet.ConsoleApp.DataStructures
{
    public class PredictionDataInfo
    {
        

        public UInt32 PredictedLabel { get; set; }

        public string PredictedResult { get; set; }

        public float[] Score { get; set; }
    }
}
