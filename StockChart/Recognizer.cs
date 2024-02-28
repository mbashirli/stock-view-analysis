using System.Collections.Generic;

namespace StockChart
{
    // Abstract base class for pattern recognizers in stock charts.
    // It defines the common structure and behavior for various candlestick pattern recognizers.
    internal abstract class Recognizer
    {
        public string PatternName { get; set; }
        public int PatternSize { get; set; }

        public Recognizer(string patternName, int patternSize)
        {
            this.PatternName = patternName;
            this.PatternSize = patternSize;
        }

        // Virtual method to get the result index. Can be overridden in derived classes.
        // By default, it returns the current index.
        protected virtual int GetResultIndex(int currentIndex)
        {
            return currentIndex;
        }

        // Main method to recognize patterns in a list of candlesticks.
        // It returns a list of indices where the pattern occurs.
        public List<int> RecognizePatterns(List<SmartCandlestick> candlesticks)
        {
            List<int> result = new List<int>();

            // Offset to handle the pattern size in the loop.
            int offset = PatternSize - 1;

            for (int i = offset; i < candlesticks.Count; i = i + 1)
            {
                // Extracts a sublist of candlesticks based on the pattern size.
                List<SmartCandlestick> sublistCandlesticks = candlesticks.GetRange(i - offset, PatternSize);

                // If the pattern is recognized, add the index to the result list.
                if (RecognizePattern(sublistCandlesticks))
                {
                    result.Add(GetResultIndex(i));
                }
            }

            return result;
        }

        // Abstract method to recognize the specific pattern.
        // Must be implemented in derived classes providing the logic for pattern recognition.
        protected abstract bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks);
    }
}
