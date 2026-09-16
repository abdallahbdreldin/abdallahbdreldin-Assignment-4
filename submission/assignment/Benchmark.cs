using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class StringConcatenationBenchmark
{
    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";

        for (int i = 0; i < Iterations; i++)
        {
            result += i;
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        var builder = new StringBuilder();

        for (int i = 0; i < Iterations; i++)
        {
            builder.Append(i);
        }

        return builder.ToString();
    }
}