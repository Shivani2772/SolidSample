using System;

namespace ArdalisRating
{
    public class RaterFactory
    {
        // public Rater Create(Policy policy, RatingEngine engine)
        // {
        //     switch (policy.Type)
        //     {
        //         case PolicyType.Auto:
        //             return new AutoPolicyRater(engine, engine.Logger);

        //         case PolicyType.Life:
        //             return new LifePolicyRater(engine, engine.Logger);

        //         case PolicyType.Land:
        //             return new LandPolicyRater(engine, engine.Logger);

        //         case PolicyType.Flood:
        //         return new FloodPolicyRater(engine, engine.Logger);

        //         default:
        //             return new UnknownPolicyRater(engine, engine.Logger);

        //     }
        // }

        /// <summary>
        /// OCP for the factory as well by using reflection, it eleminated the use of swtich statement
        /// It uses a naming convention to allow us to instantiate the appropriate class instance,
        ///  based on the nae proivded insisde the policy type inside json document
        /// </summary>
        /// <param name="policy"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        public Rater CreateWithReflection(Policy policy, IRatingContext context)
        {
            try {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}.PolicyRater"),
                        new object[] { new RatingUpdater(context.Engine) });
            }
            catch
            {
                /// <summary>
                /// Instead of returning null in the catch block 
                /// we wil return new instance of UnknowType
                /// </summary>
                /// 
                /// return null;
                return new UnknownPolicyRater( new RatingUpdater(context.Engine) );
            }
        }
    }
}