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
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine()
        {
            Context.Engine = this;
        }
        /// <summary>
        /// The method is now open to extension of different types of policy, but closed against modification
        /// </summary>
        public void Rate()
        {
            Context.Log("Starting rate.");
            Context.Log("Loading policy");

            // load policy - open file policy.json
            string policyJson = Context.LoadPolicyFromFile();

            var policy = Context.GetPolicyFromJsonString(policyJson);

            // var factory = new RaterFactory();
            var rater = Context.CreateRaterForPolicy(policy, Context);
            rater.Rate(policy);
            /// This one will check for null values as well
            ///  var rater = factory.CreateWithReflection(policy, this);
            /// ? dont have to be checked as factory wont return null value it will return UnknowPolicyType
            ///  rater?.Rate(policy);  // rate method will not be called if rater is null

            Context.Log("Rating completed.");
        }
    }
}
