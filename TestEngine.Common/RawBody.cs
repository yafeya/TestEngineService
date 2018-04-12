using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaaS.Common
{
    public class RawTypes
    {
        public const string StringType = "string";
        public const string BufferType = "buffer";
        public const string NumberType = "number";
    }

    public class RawArg
    {
        public string Type { get; set; } = RawTypes.StringType;
        public string Value { get; set; } = string.Empty;
    }

    public class RawResponse : RawArg
    {
        public bool IsCompleted { get; set; } = false;
        public string ProgressMessage { get; set; } = string.Empty;
    }

    public class RawRequest
    {
        public RawArg[] Args { get; set; }
    }
}
