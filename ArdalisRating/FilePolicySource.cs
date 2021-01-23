using System.IO;

namespace ArdalisRating {
    /// <summary>
    /// This follows SRP by Presistance behaviour
    /// The format of the extraction of the source can be changed easily in future
    /// </summary>
    public class FilePolicySource
    {
        public string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }

    }

}