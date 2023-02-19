using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSA.DataStructures.Trees;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX = 10_000_000;
            int ITERATIONS = 11;

            double totalOrderedCreate = 0;
            double totalUnorderedCreate = 0;

            double totalOrderedGet = 0;
            double totalUnorderedGet = 0;

            double totalOrderedRemove = 0;
            double totalUnorderedRemove = 0;

            double totalHeightOrdered = 0;
            double totalHeightUnordered = 0;

            IKeyValueMap<int, int> keyValueMap = null ;

            var dictionaryKeyValueMap = new DictionaryKeyValueMap<int, int>();
            var bstKeyValueMap = new BinarySearchTreeKeyValueMap<int, int>();
            var avlKeyValueMap = new AVLTreeKeyValueMap<int, int>();
            var redblackKeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

            keyValueMap = bstKeyValueMap;

            for (int c = 0; c < ITERATIONS; c++)
            {
                var intKeyValuePairs = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < MAX; i++)
                {
                    intKeyValuePairs.Add(new KeyValuePair<int, int>(i, i + 42));
                }

                keyValueMap.Clear();
                // Ordered
                //totalOrderedCreate += CreateKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);
                //totalHeightOrdered += keyValueMap.Height;
                //totalOrderedGet += QueryKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);
                //totalOrderedRemove += RemoveKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

                // Unordered
                intKeyValuePairs.Shuffle();
                keyValueMap.Clear();
                totalUnorderedCreate += CreateKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);
                //totalHeightUnordered += keyValueMap.Height;
                totalUnorderedGet += QueryKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);
                totalUnorderedRemove += RemoveKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);


            }

            Console.WriteLine(keyValueMap.GetType());

            Console.WriteLine("Order Insert");
            Console.WriteLine(totalOrderedCreate / ITERATIONS);
            Console.WriteLine("Order Height");
            Console.WriteLine(totalHeightOrdered/ ITERATIONS);
            Console.WriteLine("Order Lookup");
            Console.WriteLine(totalOrderedGet / ITERATIONS);
            Console.WriteLine("Order Remove");
            Console.WriteLine(totalOrderedRemove / ITERATIONS);


            Console.WriteLine("Random Insert");
            Console.WriteLine(totalUnorderedCreate / ITERATIONS);
            Console.WriteLine("Random Height");
            Console.WriteLine(totalHeightUnordered / ITERATIONS);
            Console.WriteLine("Random Lookup");
            Console.WriteLine(totalUnorderedGet / ITERATIONS);
            Console.WriteLine("Random Remove");
            Console.WriteLine(totalUnorderedRemove / ITERATIONS);
        }


        public static double CreateKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey,TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs )
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            // do the work

            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Add(kvp.Key, kvp.Value);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            return stopwatch.Elapsed.TotalSeconds;
            

        }


        //TODO
        public static double QueryKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            // do the work

            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Get(kvp.Key);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            return stopwatch.Elapsed.TotalSeconds;


        }


        //TODO
        public static double RemoveKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            // do the work

            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Remove(kvp.Key);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            return stopwatch.Elapsed.TotalSeconds;


        }

    }
}
