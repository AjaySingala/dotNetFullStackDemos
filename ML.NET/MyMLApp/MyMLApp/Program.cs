using MyMLApp;
using PredictiveMaintenance;

// Add input data
var sampleData = new SentimentModel.ModelInput()
{
    Col0 = "This restaurant was wonderful."
};

// Load model and predict output of sample data
var result = SentimentModel.Predict(sampleData);

// If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
Console.WriteLine($"Text: {sampleData.Col0}\nSentiment: {sentiment}");

// Predictive Maintenance Demo.
Console.WriteLine();
Console.WriteLine("Predictive Maintenance Demo...");

//Load sample data
var sampleDataPredictiveMaintenance = new PredictiveMaintenanceModel.ModelInput()
{
    Product_ID = @"L47181",
    Type = @"L",
    Air_temperature = 298.2F,
    Process_temperature = 308.7F,
    Rotational_speed = 1408F,
    Torque = 46.3F,
    Tool_wear = 3F,
};

//Load model and predict output
var resultPredictiveMaintenance = PredictiveMaintenanceModel.Predict(sampleDataPredictiveMaintenance);
// If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
var sentimentPredictiveMaintenance = resultPredictiveMaintenance.PredictedLabel == 1 ? "Positive" : "Negative";
Console.WriteLine($"Text: {sampleDataPredictiveMaintenance.Product_ID}\nSentiment: {sentimentPredictiveMaintenance}");
