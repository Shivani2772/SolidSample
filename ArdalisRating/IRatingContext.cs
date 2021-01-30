namespace ArdalisRating
{
    public interface IRatingContext : ILogger
    {
        //loading data from different sources
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);
        // deserializing using different formats 
        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);
        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
        RatingEngine Engine { get; set; }
        // Logger property only exists to support some backward compatibility
        // in this case the Rater class requires a logger to be provided when its created
        // ConsoleLogger Logger { get; set; }

    }
}