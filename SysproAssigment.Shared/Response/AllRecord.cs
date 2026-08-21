using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Shared.Response
{
    public record AllRecord<T>(List<T> Records, int TotalCount);
}
