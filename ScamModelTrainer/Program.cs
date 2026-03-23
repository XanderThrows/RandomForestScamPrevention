using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScamModelTrainer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var mlContext = new MLContext();

            // Load Dataset
            var data = mlContext.Data.LoadFromTextFile<TransactionData>(
            "RandomForestDataSpread.csv",
            hasHeader: true,
            separatorChar: ','
            );

            //view data
            var preview = data.Preview();
            Console.WriteLine(preview);


            //clean data

            //define features

            //train RF using clean data and features

            // After training
            // featureSelector.PrintFeatureImportance(model, features);

        }
    }

    public class TransactionData
    {
        [LoadColumn(0)]
        public float TransactionAmount;         

        [LoadColumn(1)]
        public float AverageTransactionAmount;  

        [LoadColumn(2)]
        public float CustomerLocation;          // categorical -> encode numeric

        [LoadColumn(3)]
        public float RecipientLocation;         //edit: ignoring to avoid overfitting

        [LoadColumn(4)]
        public float TransactionType;          // categorical -> encode numeric

        [LoadColumn(5)]
        public float CurrencyType;             // categorical -> encode numeric

        [LoadColumn(6)]
        public float HourOfDay;                

        [LoadColumn(7)]
        public float RiskLabel;                // 0 = safe, 1 = scam
    }

    //picking important things
    public class FeatureSelector
    {
        private readonly MLContext _mlContext;

        public FeatureSelector(MLContext mlContext)
        {
            _mlContext = mlContext;
        }

        //returns filtered data with only valid labels
        public IDataView FilterMissingLabels(IDataView data)
        {
            var filteredData = _mlContext.Data.FilterRowsByMissingValues(data, nameof(TransactionData.RiskLabel));
            return filteredData;
        }

        //get feature importance after training
        public void PrintFeatureImportance(ITransformer model, string[] featureNames)
        {
            if (model.LastTransformer is Microsoft.ML.Trainers.FastForest.FastForestBinaryModelParameters treeModel)
            {
                var importances = treeModel.GetFeatureWeights();
                for (int i = 0; i < featureNames.Length; i++)
                    Console.WriteLine($"{featureNames[i]} importance: {importances[i]}");
            }
            else
            {
                Console.WriteLine("Model does not support feature importance extraction.");
            }
        }
    }

    //converting categoral data
    public class Preprocessor
    {
        private readonly MLContext _mlContext;

        public Preprocessor(MLContext mlContext)
        {
            _mlContext = mlContext;
        }

        public IDataView ConvertCategorical(IDataView data)
        {
            //grouped encoding
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("CustomerRegion")
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("TransactionType"))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("CurrencyType"));

            return pipeline.Fit(data).Transform(data);
        }

        public IDataView FilterMissingLabels(IDataView data)
        {
            return _mlContext.Data.FilterRowsByMissingValues(data, nameof(TransactionData.RiskLabel));
        }
    }

}
