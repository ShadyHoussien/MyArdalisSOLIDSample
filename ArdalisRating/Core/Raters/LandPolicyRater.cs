using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LandPolicyRater : IPolicyRater
    {
        public decimal Rating { get; set; }

        private readonly Policy _policy;

        private readonly ILogger _logger;

        public LandPolicyRater(ILogger logger,Policy policy)
        {
            _logger = logger;
            _policy = policy;
        }

        public decimal CalculateRating()
        {
            _logger.Log("Rating LAND policy...");
            _logger.Log("Validating policy.");
            if (_policy.BondAmount == 0 || _policy.Valuation == 0)
            {
                _logger.Log("Land policy must specify Bond Amount and Valuation.");
                return 0;
            }
            if (_policy.BondAmount < 0.8m * _policy.Valuation)
            {
                _logger.Log("Insufficient bond amount.");
                return 0;
            }
            Rating = _policy.BondAmount * 0.05m;

            return Rating;
        }
    }
}
