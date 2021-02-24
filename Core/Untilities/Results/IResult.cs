using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Untilities
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
