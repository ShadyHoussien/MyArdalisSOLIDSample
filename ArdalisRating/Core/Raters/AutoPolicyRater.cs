using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : IPolicyRater
    {
        private readonly Policy _policy;
        public decimal Rating { get; set; }

        private readonly ILogger _logger;

        public AutoPolicyRater(ILogger logger , Policy policy)
        {
            _logger = logger;
            _policy = policy;
        }
        public decimal CalculateRating()
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(_policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return 0;
            }
            if (_policy.Make == "BMW")
            {
                if (_policy.Deductible < 500)
                {
                    Rating = 1000m;
                }
                Rating = 900m;
            }
            return Rating;
        }
    }
}
