using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//NAVI
namespace ScamModelTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {

            var randomSeed = new Random().Next();
            var mlContext = new MLContext(seed: 42);  //sometimes gives AUC error??

            Console.WriteLine($"Working Directory: {Environment.CurrentDirectory}");

            // Load Data
            var data = mlContext.Data.LoadFromTextFile<TransactionData>(
                "RandomForestDataSpread.csv",
                hasHeader: true,
                separatorChar: ',');

            // Clean and shuffle
            var cleanData = data; //trusting my data
            var shuffledData = mlContext.Data.ShuffleRows(cleanData);
            var split = mlContext.Data.TrainTestSplit(shuffledData);  //testFraction: 0.2

            // Pipeline
            var dataPipeline = mlContext.Transforms.Categorical.OneHotEncoding("CustomerLocationVector", nameof(TransactionData.CustomerLocation))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("RecipientLocationVector", nameof(TransactionData.RecipientLocation)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("TransactionTypeVector", nameof(TransactionData.TransactionType)))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("CurrencyTypeVector", nameof(TransactionData.CurrencyType)))
                .Append(mlContext.Transforms.Concatenate("Features",
                    nameof(TransactionData.TransactionAmount),
                    nameof(TransactionData.AverageTransactionAmount),
                    "CustomerLocationVector",
                    "RecipientLocationVector",
                    "TransactionTypeVector",
                    "CurrencyTypeVector"));

            var trainer = mlContext.BinaryClassification.Trainers.FastForest(new FastForestBinaryTrainer.Options
            {

                LabelColumnName = nameof(TransactionData.RiskLabel),
                FeatureColumnName = "Features",
                NumberOfTrees = 100,   //200
                NumberOfLeaves = 20,   //20
                MinimumExampleCountPerLeaf = 10,  //10
                FeatureFraction = 0.7
            });


            var trainingPipeline = dataPipeline
                .Append(trainer)
                .Append(mlContext.BinaryClassification.Calibrators.Platt(
                    labelColumnName: nameof(TransactionData.RiskLabel),
                       scoreColumnName: "Score"));


            // Train model
            Console.WriteLine("Training model...");
            var model = trainingPipeline.Fit(split.TrainSet);
            mlContext.Model.Save(model, split.TrainSet.Schema, "ScamRandomForest.zip");  //save it
            Console.WriteLine("Model saved to ScamRandomForest.zip\n");

            var preview = model.Transform(data).Preview();

            var metrics = mlContext.BinaryClassification.Evaluate(
                            model.Transform(split.TestSet),
                            labelColumnName: nameof(TransactionData.RiskLabel));
            /*mlContext.BinaryClassification.EvaluateNonCalibrated(model.Transform(split.TestSet),
                    labelColumnName: nameof(TransactionData.RiskLabel));*/

            Console.WriteLine($"{metrics.ToString()} {preview}");

            var allData = mlContext.Data.CreateEnumerable<TransactionData>(data, false).ToList();
            Console.WriteLine($"Fraud: {allData.Count(x => x.RiskLabel)}");
            Console.WriteLine($"Not Fraud: {allData.Count(x => !x.RiskLabel)}");

            //Console.WriteLine("END");


            // Evaluate Test Set
            Console.WriteLine("--- Test Set Results ---");
            var predictions = model.Transform(split.TestSet);
            var predictedEnumerable = mlContext.Data.CreateEnumerable<Prediction>(predictions, reuseRowObject: false);

            foreach (var p in predictedEnumerable)
            {
                Console.WriteLine($"Actual: {p.Label,-5} | Pred: {p.PredictedLabel,-5} | Prob: {p.Probability:P2}");
            }

            // Predict Single New Transaction
            var predictionEngine = mlContext.Model.CreatePredictionEngine<TransactionData, Prediction>(model);
            var newTransaction = new TransactionData
            {
                TransactionAmount = 20,
                AverageTransactionAmount = 500,
                CustomerLocation = "New York",
                TransactionType = "subscription",
                CurrencyType = "USD",
                RecipientLocation = "New York"
            };

            var result = predictionEngine.Predict(newTransaction);
            float finalProb = 1 / (1 + MathF.Exp(-result.Score));
            float finalMargin = Math.Abs(finalProb - 0.5f) * 2;

            Console.WriteLine("\n--- Sample Transaction Prediction ---");
            Console.WriteLine($"Predicted Risk: {result.PredictedLabel}");
            //Console.WriteLine($"Probability:    {finalProb:P2}");
            Console.WriteLine($"Confidence:     {finalMargin:F2}");

            if (result.Score > 0.6)
            {
                Console.WriteLine("Scam");
            }
            else if (result.Score < 0.4)
            {
                Console.WriteLine("Safe");
            }
            else
            {
                Console.WriteLine("Flag");
            }

            Console.WriteLine("=== MODEL METRICS ===");
            Console.WriteLine($"Accuracy:  {metrics.Accuracy:P2}");
            Console.WriteLine($"AUC:       {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1 Score:  {metrics.F1Score:P2}");
            Console.WriteLine($"Precision: {metrics.PositivePrecision:P2}");
            Console.WriteLine($"Recall:    {metrics.PositiveRecall:P2}");

            var cm = metrics.ConfusionMatrix;

            Console.WriteLine("=== CONFUSION MATRIX ===");
            Console.WriteLine($"TP: {cm.Counts[1][1]}");
            Console.WriteLine($"FP: {cm.Counts[0][1]}");
            Console.WriteLine($"FN: {cm.Counts[1][0]}");
            Console.WriteLine($"TN: {cm.Counts[0][0]}");

            var probs = predictedEnumerable.Select(p => p.Probability).ToList();

            Console.WriteLine($"Avg Prob: {probs.Average()}");
            Console.WriteLine($"Min Prob: {probs.Min()}");
            Console.WriteLine($"Max Prob: {probs.Max()}");
        }
    }

    public class TransactionData
    {
        [LoadColumn(0)]
        public float TransactionAmount;

        [LoadColumn(1)]
        public float AverageTransactionAmount;

        [LoadColumn(2)]
        public string CustomerLocation;          // categorical -> encode numeric

        [LoadColumn(3)]
        public string RecipientLocation;         //edit: not ignoring 

        [LoadColumn(4)]
        public string TransactionType;          // categorical -> encode numeric

        [LoadColumn(5)]
        public string CurrencyType;             // categorical -> encode numeric

        /*[LoadColumn(6)]
        public string Timestamp;*/      //ignored, too complicated and overfitting

        [LoadColumn(6)]
        public bool RiskLabel;
    }

    public class Prediction
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedLabel { get; set; }

        //added
        [ColumnName("Probability")]
        public float Probability { get; set; }

        [ColumnName("Score")]
        public float Score { get; set; }

        [ColumnName("RiskLabel")]
        public bool Label { get; set; }
    }
}