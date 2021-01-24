using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
        public FilePolicySource PolicySource { get; set; } = new FilePolicySource();
        /// <summary>
        /// The method is now open to extension of different types of policy, but closed against modification
        /// </summary>
        public void Rate()
        {
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy");

            // load policy - open file policy.json
            string policyJson = PolicySource.GetPolicyFromSource();

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());

            var factory = new RaterFactory();
            var rater = factory.Create(policy, this);
            rater.Rate(policy);
            /// This one will check for null values as well
            ///  var rater = factory.CreateWithReflection(policy, this);
            /// ? dont have to be checked as factory wont return null value it will return UnknowPolicyType
            ///  rater?.Rate(policy);  // rate method will not be called if rater is null

            Logger.Log("Rating completed.");
        }
    }
}
