using System;
using System.Collections.Generic;

namespace The_Store.OperationMessengers.Base
{
    public class BaseOperationOut
    {
        public bool OperationResultSuccess = false;

        public Exception Error;

        protected Dictionary<string, object> _extendedProperties;

        protected Dictionary<string, List<string>> ValidationErrors;
    }
}
