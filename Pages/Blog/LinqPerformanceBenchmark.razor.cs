using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PersonalSite.Services.Interfaces;

namespace PersonalSite.Pages.Blog;

public partial class LinqPerformanceBenchmark
{
    private Models.Blog _blog = new();
    [Inject] private IJSRuntime JsRuntime { get; set; }
    [Inject] private IBlogsService BlogsService { get; set; }

    private const string BenchmarkSetupTargetFrameworks = @"[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]";

    private const string Variables = @"[Params(100, 10_000)] public static int Size;
private IEnumerable<int> _enumerable = 
    Enumerable.Range(1, Size).ToArray();";

    private const string Benchmarks = @"[Benchmark]
public int Min() => _enumerable.Min();

[Benchmark]
public int Max() => _enumerable.Max();

[Benchmark]
public double Avg() => _enumerable.Average();

[Benchmark]
public int Sum() => _enumerable.Sum();";

    private const string Results =
        @"| Method |      Job |  Runtime |  Size |         Mean |      Error |       StdDev | Allocated |
|------- |--------- |--------- |------ |-------------:|-----------:|-------------:|----------:|
|    Min | .NET 6.0 | .NET 6.0 |   100 |    493.87 ns |   8.228 ns |     7.294 ns |      32 B |
|    Max | .NET 6.0 | .NET 6.0 |   100 |    439.19 ns |   1.248 ns |     1.042 ns |      32 B |
|    Avg | .NET 6.0 | .NET 6.0 |   100 |    446.66 ns |   8.472 ns |     7.924 ns |      32 B |
|    Sum | .NET 6.0 | .NET 6.0 |   100 |    440.52 ns |   1.868 ns |     1.459 ns |      32 B |
|    Min | .NET 7.0 | .NET 7.0 |   100 |     23.50 ns |   0.144 ns |     0.112 ns |         - |
|    Max | .NET 7.0 | .NET 7.0 |   100 |     23.22 ns |   0.234 ns |     0.208 ns |         - |
|    Avg | .NET 7.0 | .NET 7.0 |   100 |     31.67 ns |   0.112 ns |     0.104 ns |         - |
|    Sum | .NET 7.0 | .NET 7.0 |   100 |     64.64 ns |   0.248 ns |     0.194 ns |         - |
|    Min | .NET 6.0 | .NET 6.0 | 10000 | 46,778.08 ns | 373.619 ns |   349.484 ns |      32 B |
|    Max | .NET 6.0 | .NET 6.0 | 10000 | 41,827.49 ns | 834.093 ns | 1,393.582 ns |      32 B |
|    Avg | .NET 6.0 | .NET 6.0 | 10000 | 41,238.20 ns |  85.832 ns |    71.674 ns |      32 B |
|    Sum | .NET 6.0 | .NET 6.0 | 10000 | 41,372.08 ns | 405.243 ns |   338.396 ns |      32 B |
|    Min | .NET 7.0 | .NET 7.0 | 10000 |  2,826.39 ns |   4.624 ns |     3.861 ns |         - |
|    Max | .NET 7.0 | .NET 7.0 | 10000 |  2,819.23 ns |  10.306 ns |     8.606 ns |         - |
|    Avg | .NET 7.0 | .NET 7.0 | 10000 |  5,087.29 ns |   4.312 ns |     3.601 ns |         - |
|    Sum | .NET 7.0 | .NET 7.0 | 10000 |  5,202.96 ns |  66.402 ns |    55.448 ns |         - |";

    private const string ListResults =
        @"| Method |      Job |  Runtime |  Size |         Mean |        Error |       StdDev | Allocated |
|------- |--------- |--------- |------ |-------------:|-------------:|-------------:|----------:|
|    Min | .NET 6.0 | .NET 6.0 |   100 |    809.61 ns |     6.535 ns |     5.102 ns |      40 B |
|    Max | .NET 6.0 | .NET 6.0 |   100 |    771.45 ns |    14.765 ns |    13.089 ns |      40 B |
|    Avg | .NET 6.0 | .NET 6.0 |   100 |    810.62 ns |     3.743 ns |     3.125 ns |      40 B |
|    Sum | .NET 6.0 | .NET 6.0 |   100 |    765.13 ns |    10.967 ns |     9.158 ns |      40 B |
|    Min | .NET 7.0 | .NET 7.0 |   100 |     24.91 ns |     0.050 ns |     0.042 ns |         - |
|    Max | .NET 7.0 | .NET 7.0 |   100 |     24.90 ns |     0.236 ns |     0.185 ns |         - |
|    Avg | .NET 7.0 | .NET 7.0 |   100 |     32.74 ns |     0.288 ns |     0.240 ns |         - |
|    Sum | .NET 7.0 | .NET 7.0 |   100 |     65.66 ns |     0.604 ns |     0.504 ns |         - |
|    Min | .NET 6.0 | .NET 6.0 | 10000 | 77,409.48 ns |   249.835 ns |   221.472 ns |      40 B |
|    Max | .NET 6.0 | .NET 6.0 | 10000 | 72,649.35 ns | 1,414.949 ns | 1,181.546 ns |      40 B |
|    Avg | .NET 6.0 | .NET 6.0 | 10000 | 72,741.68 ns |   790.426 ns |   700.692 ns |      40 B |
|    Sum | .NET 6.0 | .NET 6.0 | 10000 | 72,177.65 ns |   233.077 ns |   206.617 ns |      42 B |
|    Min | .NET 7.0 | .NET 7.0 | 10000 |  2,938.34 ns |    33.148 ns |    29.385 ns |         - |
|    Max | .NET 7.0 | .NET 7.0 | 10000 |  2,940.24 ns |    29.592 ns |    26.233 ns |         - |
|    Avg | .NET 7.0 | .NET 7.0 | 10000 |  5,092.73 ns |    14.894 ns |    13.932 ns |         - |
|    Sum | .NET 7.0 | .NET 7.0 | 10000 |  5,154.94 ns |     2.382 ns |     1.989 ns |         - |";

    private const string DotNet6MinCode = @"int value;
using (IEnumerator<int> e = source.GetEnumerator())
{
    if (!e.MoveNext())
    {
        ThrowHelper.ThrowNoElementsException();
    }

    value = e.Current;
    while (e.MoveNext())
    {
        int x = e.Current;
        if (x < value)
        {
            value = x;
        }
    }
}

return value;";

    private const string DotNet7MinCode = @"//int index;
if (Vector.IsHardwareAccelerated && span.Length >= Vector<T>.Count * 2)
{
    var mins = new Vector<T>(span);
    index = Vector<T>.Count;
    do
    {
        mins = Vector.Min(mins, new Vector<T>(span.Slice(index)));
        index += Vector<T>.Count;
    }
    while (index + Vector<T>.Count <= span.Length);

    value = mins[0];
    for (int i = 1; i < Vector<T>.Count; i++)
    {
        if (mins[i] < value)
        {
            value = mins[i];
        }
    }
}";

    protected override async Task OnInitializedAsync()
    {
        _blog = await BlogsService.GetBlog(1);
        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JsRuntime.InvokeVoidAsync("highlightCode");
    }
}