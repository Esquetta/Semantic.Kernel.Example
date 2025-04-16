using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level5.PluginConfiguration.Plugins
{

    public class APlugin
    {

        [KernelFunction("a")]
        [Description("...")]
        [return: Description("...")]
        public void a() => Console.WriteLine("A Plugin");
    }
}
