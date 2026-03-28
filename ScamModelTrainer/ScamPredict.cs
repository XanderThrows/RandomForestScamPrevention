using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace ScamModelTrainer
{
    public class ScamPredict
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public ScamPredict()
        {
            _mlContext = new MLContext(seed: 1);
        }

        public void LoadModel(string modelPath)
        {
            _model = _mlContext.Model.Load(modelPath, out var schema);
        }

        public Prediction Predict(TransactionData transaction)
        {
            if (_model == null)
            {
                throw new InvalidOperationException("Model not loaded. Call LoadModel() first.");
            }
                

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<TransactionData, Prediction>(_model);
            return predictionEngine.Predict(transaction);
        }
    }

    
}
