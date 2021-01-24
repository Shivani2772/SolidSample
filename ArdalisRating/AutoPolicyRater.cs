using System;

namespace ArdalisRating
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(RatingEngine engine, ConsoleLogger logger)
        : base(engine, logger)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO Policy...");
            _logger.Log("Validating policy...");

            if(string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto ploicy must specify Make");
                return;
            }
            if(policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }
                _engine.Rating = 900m;
            }
        }

    }
}