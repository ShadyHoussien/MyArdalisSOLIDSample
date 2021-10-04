using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class PolicyRaterFactory : IPolicyRaterFactory
    {
        private readonly ILogger _logger;
        public PolicyRaterFactory(ILogger logger)
        {
            _logger = logger;
        }
        public IPolicyRater Create(Policy policy)
        {
            try
            {
                return (IPolicyRater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), new object[] { _logger , policy });
            }
            catch
            {

                return new DefaultPolicyRater(_logger);
            }
        }
    }
}
