using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level5.PluginConfiguration.Plugins
{
    public class CPlugin
    {
        [KernelFunction("C")]
        [Description("...")]
        [return: Description("...")]
        public void c() => Console.WriteLine("C Plugin");
    }
}
