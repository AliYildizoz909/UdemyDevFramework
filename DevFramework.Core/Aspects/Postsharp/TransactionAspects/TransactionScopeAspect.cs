using System;
using System.Transactions;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;

        public TransactionScopeAspect(TransactionScopeOption option,int priority)
        {
            _option = option;
            AttributePriority = priority;
        }
        public TransactionScopeAspect(int priority)
        {
            AspectPriority = priority;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope) args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
