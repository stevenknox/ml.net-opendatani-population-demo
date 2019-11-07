//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using SampleRegression.Model.DataModels;


namespace SampleRegression.ConsoleApp
{
    class Program
    {
        //Machine Learning model to load and use for predictions
        private const string MODEL_FILEPATH = @"MLModel.zip";

        //Dataset to use for predictions 
        private const string DATA_FILEPATH = @"C:\Users\Steven\Source\PopulationML\northern-ireland-by-single-year-of-age-and-gender-mid-1971-to-mid-2018.csv";

        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();

            // Training code used by ML.NET CLI and AutoML to generate the model
            //ModelBuilder.CreateModel();

            ITransformer mlModel = mlContext.Model.Load(GetAbsolutePath(MODEL_FILEPATH), out DataViewSchema inputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            for (int i = 0; i < 100; i++)
            {
                // Create sample data to do a single prediction with it 
                ModelInput sampleData = CreateSingleDataSample(mlContext, DATA_FILEPATH);

                // Try a single prediction
                ModelOutput predictionResult = predEngine.Predict(sampleData);

                Console.WriteLine($"Predicted population of {string.Format("{0:n0}", predictionResult.Score)} in {sampleData.Mid_Year_Ending} for {sampleData.Gender} aged {sampleData.Age} (actual {string.Format("{0:n0}", sampleData.Population_Estimate)})");

            }

              Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }

        // Method to load single row of data to try a single prediction
        // You can change this code and create your own sample data here (Hardcoded or from any source)
        private static ModelInput CreateSingleDataSample(MLContext mlContext, string dataFilePath)
        {
            // Read dataset to get a single row for trying a prediction          
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Here (ModelInput object) you could provide new test data, hardcoded or from the end-user application, instead of the row from the file.
            var random = new Random();
            var list = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false);
            int index = random.Next(list.Count());
            ModelInput sampleForPrediction = list.ElementAt(index);
            return sampleForPrediction;
        }

        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}
