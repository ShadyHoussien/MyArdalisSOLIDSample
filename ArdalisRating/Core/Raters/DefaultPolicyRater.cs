using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class DefaultPolicyRater : IPolicyRater
    {
        public decimal Rating { get; set; }

        private readonly ILogger _logger;
        public DefaultPolicyRater(ILogger logger)
        {
            _logger = logger;
        }

        public decimal CalculateRating()
        {
            _logger.Log("Unknown policy type");

            return Rating;
        }
    }
}
