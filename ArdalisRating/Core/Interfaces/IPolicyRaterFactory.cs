using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IPolicyRaterFactory
    {
        IPolicyRater Create(Policy policy);
    }
}
