using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Level4.Plugins
{
    public class CalculatorPlugin
    {
        [KernelFunction("add")]
        [Description("Its sums two numeric values.")]
        [return: Description("Returns sum of numeric result")]
        public int Add(int number1, int number2) => number1 + number2;
    }
}
