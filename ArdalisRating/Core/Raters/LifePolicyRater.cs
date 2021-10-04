using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LifePolicyRater : IPolicyRater
    {
        private readonly Policy _policy;
        public decimal Rating { get; set; }

        private readonly ILogger _logger;
        public LifePolicyRater(ILogger logger, Policy policy)
        {
            _logger = logger;
            _policy = policy;
        }
        public decimal CalculateRating()
        {
            _logger.Log("Rating LIFE ..");
            _logger.Log("Validating ");
            if (_policy.DateOfBirth == DateTime.MinValue)
            {
                _logger.Log("Life policy must include Date of Birth.");
                return 0;
            }
            if (_policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logger.Log("Centenarians are not eligible for coverage.");
                return 0;
            }
            if (_policy.Amount == 0)
            {
                _logger.Log("Life policy must include an Amount.");
                return 0;
            }
            int age = DateTime.Today.Year - _policy.DateOfBirth.Year;
            if (_policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < _policy.DateOfBirth.Day ||
                DateTime.Today.Month < _policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = _policy.Amount * age / 200;
            if (_policy.IsSmoker)
            {
                Rating = baseRate * 2;
                return Rating;
            }
            Rating = baseRate;

            return Rating;
        }
    }
}
