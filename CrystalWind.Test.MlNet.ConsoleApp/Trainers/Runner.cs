using System;
using System.Collections.Generic;
using System.Text;
using CrystalWind.Test.MlNet.ConsoleApp.Common;
using CrystalWind.Test.MlNet.ConsoleApp.DataStructures;
using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Model;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using static Microsoft.ML.TrainCatalogBase;

namespace CrystalWind.Test.MlNet.ConsoleApp.Trainers
{
    public class Runner
    {
        private MLContext _MLContext = new MLContext();


        public void Run()
        {
            var trainTestSet = PrepareData();
            var pipeline = CreatePipeline();
            var model = pipeline.Fit(trainTestSet.TrainSet);

            EvaluateModel(trainTestSet.TestSet, model);

            var predictionEngine = model.CreatePredictionEngine<DataInfo, PredictionDataInfo>(_MLContext);

            var input = new DataInfo
            {
                Input1 = 10,
                Input2 = 20
            };

            var p = predictionEngine.Predict(input);
            Console.WriteLine($"label key:{p.PredictedLabel},PredictedName:{p.PredictedResult}");
        }

        private void EvaluateModel(IDataView dv, TransformerChain<KeyToValueMappingTransformer> model)
        {
            var evls = model.Transform(dv);
            var metrics = _MLContext.MulticlassClassification.Evaluate(evls);

            ConsoleHelper.PrintEvaluateResult(metrics);
        }


        private EstimatorChain<KeyToValueMappingTransformer> CreatePipeline()
        {
            var toFeatures = _MLContext.Transforms.Concatenate(outputColumnName: DefaultColumnNames.Features, inputColumnNames: FileHelper.FeatureNames);
            var toLabel = _MLContext.Transforms.Conversion.MapValueToKey(outputColumnName: DefaultColumnNames.Label, inputColumnName: FileHelper.LabelName);

            var trainer = _MLContext.MulticlassClassification.Trainers.LightGbm();
            var toValueLabel = _MLContext.Transforms.Conversion.MapKeyToValue(outputColumnName: "PredictedResult", inputColumnName: DefaultColumnNames.PredictedLabel);

            var pipeline = toFeatures
                .Append(toLabel)
                .Append(trainer)
                .Append(toValueLabel);
                              
            return pipeline;
        }



        private TrainTestData PrepareData()
        {
            var dv = _MLContext.Data.LoadFromTextFile<DataInfo>(FileHelper.DataPath, separatorChar: ',', hasHeader: true);

            return _MLContext.MulticlassClassification.TrainTestSplit(dv, testFraction: 0.2);
        }
    }
}
