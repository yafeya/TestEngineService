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
        public const string NumberType = "number";
        public const string BufferType = "buffer";
        public const string WaveType = "wave";
    }

    public class RawArg
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = RawTypes.StringType;
        public string Value { get; set; } = string.Empty;

        public void BindTo(RawArg raw)
        {
            Name = raw.Name;
            Type = raw.Type;
            Value = raw.Value;
        }
    }

    public class RawResponse : RawArg
    {
        public bool Succeed { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public string ProgressMessage { get; set; } = string.Empty;

        public void BindTo(RawResponse raw)
        {
            base.BindTo(raw);
            Succeed = raw.Succeed;
            IsCompleted = raw.IsCompleted;
            ProgressMessage = raw.ProgressMessage;
        }
    }

    public class RawRequest
    {
        public RawArg[] Args { get; set; }

        public IDictionary<string, RawArg> ToMap()
        {
            var dic = new Dictionary<string, RawArg>();
            if (Args != null)
            {
                foreach (var arg in Args)
                {
                    if (!string.IsNullOrEmpty(arg.Name) 
                        && dic.ContainsKey(arg.Name))
                    {
                        dic[arg.Name] = arg;
                    }
                }
            }
            return dic;
        }
    }

    public class RawConfigInfo
    {
        public bool NeedArgs { get; set; } = true;
        public bool LengthLimit { get; set; } = true;
        public RawArg[] TemplateArgs { get; set; }
    }
}
