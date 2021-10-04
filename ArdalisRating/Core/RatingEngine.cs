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
        private readonly ILogger _logger;
        private readonly IFileReader _fileReader;
        private readonly IPolicyRaterFactory _policyRaterFactory;

        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger , IFileReader fileReader , IPolicyRaterFactory policyRaterFactory)
        {
            _logger = logger;
            _fileReader = fileReader;
            _policyRaterFactory = policyRaterFactory;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _fileReader.ReadData("policy.json");

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());

            var rater = _policyRaterFactory.Create(policy);

            Rating = rater.CalculateRating();

            _logger.Log("Rating completed.");
        }
    }
}
