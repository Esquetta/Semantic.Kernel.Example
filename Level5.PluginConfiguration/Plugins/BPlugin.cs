using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level5.PluginConfiguration.Plugins
{
    public class BPlugin
    {
        [KernelFunction("b")]
        [Description("...")]
        [return: Description("...")]
        public void b() => Console.WriteLine("B Plugin");
    }
}
