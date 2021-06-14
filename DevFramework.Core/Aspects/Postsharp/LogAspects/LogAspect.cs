using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramework.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType,int priority)
        {
            _loggerType = loggerType;
            AspectPriority = priority;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("Wrong Logger Type");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnable)
            {
                return;
            }

            try
            {
                var logParameters = args.Method.GetParameters().Select((p, i) => new LogParameter
                {
                    Name = p.Name,
                    Type = p.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                });
                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters.ToList()
                };
                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {
            }


        }
    }
}
