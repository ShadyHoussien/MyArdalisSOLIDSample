using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IPolicyRater
    {
        decimal Rating { get; }
        decimal CalculateRating();
    }
}
