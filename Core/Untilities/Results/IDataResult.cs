using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Untilities
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
