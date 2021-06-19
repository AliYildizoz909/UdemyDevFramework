using System;
using System.Collections.Generic;
using System.Text;
using log4net.Core;
using Newtonsoft.Json;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    //[Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object MessageObject
        {
            get
            {
                string val = _loggingEvent.MessageObject.ToString();
                var i1 = val.IndexOf('{');
                val = val.Remove(0, i1 - 1);
                val= val.Remove(val.Length-1);

                var json = JsonConvert.DeserializeObject<LogDetail>(val);
                return json;
            }
        }
    }
}
