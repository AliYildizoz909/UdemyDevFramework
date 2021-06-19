using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
            
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            
            var logEvent = new SerializableLogEvent(loggingEvent);
            
            
            var json = JsonConvert.SerializeObject(logEvent,Newtonsoft.Json.Formatting.Indented);

            writer.WriteLine(json);
        }
    }
}
