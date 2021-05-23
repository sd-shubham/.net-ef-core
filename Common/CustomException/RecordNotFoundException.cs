using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Common.CustomException
{
    [Serializable]
    public class RecordNotFoundException:Exception
    {
        public string Record { get; set; }
        public RecordNotFoundException() { }
        public RecordNotFoundException(string message) : base(message) { }
        public RecordNotFoundException(string message,Exception inner):base(message,inner) { }
        public RecordNotFoundException(string message, string recordName) : this(message) => Record = recordName;
    }
}
