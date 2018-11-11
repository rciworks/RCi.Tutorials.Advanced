using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RCi.Tutorials.Advanced.Fillers;

namespace RCi.Tutorials.Advanced
{
    public interface IFiller
    {
        void Fill(byte[] array, byte value);
    }

    internal class Program
    {
        private static IEnumerable<IFiller> GetFillers()
        {
            return new IFiller[]
            {
                new FillerFor(),
                new FillerUnsafe(),
                new FillerArrayCopy(),
                new FillerMemset(),
                new FillerInitblk(),
            };
        }

        private static void Main()
        {
            // collect array sizes
            var arraySizes = new List<int>();
            for (var size = 1; size < int.MaxValue && size > 0; size *= 2)
            {
                arraySizes.Add(size);
            }

            // get fillers
            var fillers = GetFillers().ToArray();

            // get random value func
            var getRandomValue = new Func<byte>(() => (byte)new Random(Environment.TickCount).Next());

            // iterations
            const int iterations = 5;

            // precompile
            foreach (var filler in fillers)
            {
                filler.Fill(new byte[1], default);
            }

            // run benchmark
            Benchmark(arraySizes, fillers, getRandomValue, iterations);
        }

        private static void Benchmark(IEnumerable<int> arraySizes, ICollection<IFiller> fillers, Func<byte> getRandomValue, int iterations)
        {
            Console.Clear();

            foreach (var arraySize in arraySizes)
            {
                var array = new byte[arraySize];
                var results = new List<(IFiller filler, TimeSpan elapsed)>();

                foreach (var filler in fillers)
                {
                    // cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    // measure filler
                    var elapsed = TimeSpan.Zero;
                    for (var i = 0; i < iterations; i++)
                    {
                        elapsed += MeasureFill(filler, array, getRandomValue());
                    }

                    // store result
                    results.Add((filler, new TimeSpan(elapsed.Ticks / iterations)));
                }

                // take some result as a reference
                var reference = results.First().elapsed;

                // give user feedback
                Console.WriteLine($"size = {arraySize:##,##0}");
                foreach (var result in results)
                {
                    Console.WriteLine($"{result.filler.GetType().Name,-25}{result.elapsed,-20:g}{result.elapsed / reference,10:##,##0%}");
                }
                Console.WriteLine();
            }
        }

        private static TimeSpan MeasureFill(IFiller filler, byte[] array, byte value)
        {
            // measure
            var elapsed = Measure(() => filler.Fill(array, value));

#if DEBUG
            // validate
            var equalityComparer = EqualityComparer<byte>.Default;
            for (var i = 0; i < array.Length; i++)
            {
                if (!equalityComparer.Equals(array[i], value))
                {
                    throw new Exception("Validation failed.");
                }
            }
#endif

            return elapsed;
        }

        private static TimeSpan Measure(Action action)
        {
            var stopwatch = Stopwatch.StartNew();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
