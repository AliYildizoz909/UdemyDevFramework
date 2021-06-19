using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DevFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> Parameters { get; set; }

        public override string ToString()
        {
            var json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
    }
}
