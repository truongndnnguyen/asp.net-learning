using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCustomActivity
{
    public class SampleCustomActivity   : CodeActivity
    {
        [Input("EntityReference input")]
        [Output("EntityReference output")]
        [ReferenceTarget("account")]
        [Default("3B036E3E-94F9-DE11-B508-00155DBA2902", "account")]
        public InOutArgument<EntityReference> AccountReference { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            if (AccountReference.Get(context).Id != new Guid("3B036E3E-94F9-DE11-B508-00155DBA2902"))
                throw new InvalidPluginExecutionException("Unexpected default value");
        }
    }
}
