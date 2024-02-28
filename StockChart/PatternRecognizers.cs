using System.Collections.Generic;

namespace StockChart
{
    internal class BullishRecognizer : Recognizer
    {
        public BullishRecognizer() : base("Bullish", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsBullish;
        }
    }

    internal class BearishRecognizer : Recognizer
    {
        public BearishRecognizer() : base("Bearish", 1) {}
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsBearish;
        }
    }

    internal class NeutralRecognizer : Recognizer
    {
        public NeutralRecognizer() : base("Neutral", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsNeutral;
        }
    }

    internal class MarubozuRecognizer : Recognizer
    {
        public MarubozuRecognizer() : base("Marubozu", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsMarubozu;
        }
    }

    internal class DojiRecognizer : Recognizer
    {
        public DojiRecognizer() : base("Doji", 1) {}
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsDoji;
        }
    }

    internal class DragonflyDojiRecognizer : Recognizer
    {
        public DragonflyDojiRecognizer() : base("Dragonfly Doji", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsDragonflyDoji;
        }
    }

    internal class GravestoneDojiRecognizer : Recognizer
    {
        public GravestoneDojiRecognizer() : base("Gravestone Doji", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsGravestoneDoji;
        }
    }

    internal class HammerRecognizer : Recognizer
    {
        public HammerRecognizer() : base("Hammer", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsHammer;
        }
    }

    internal class BullishHammerRecognizer : Recognizer
    {
        public BullishHammerRecognizer() : base("Bullish Hammer", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsBullishHammer;
        }
    }

    internal class BearishHammerRecognizer : Recognizer
    {
        public BearishHammerRecognizer() : base("Bearish Hammer", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsBearishHammer;
        }
    }

    internal class InvertedHammerRecognizer : Recognizer
    {
        public InvertedHammerRecognizer() : base("Inverted Hammer", 1) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            return sublistCandlesticks[0].IsInvertedHammer;
        }
    }

    internal class BullishEngulfingRecognizer : Recognizer
    {
        public BullishEngulfingRecognizer() : base("Bullish Engulfing", 2) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            if (sublistCandlesticks.Count != 2)
            {
                return false; // Not enough candlesticks for the pattern
            }

            SmartCandlestick firstCandlestick = sublistCandlesticks[0];
            SmartCandlestick secondCandlestick = sublistCandlesticks[1];

            // Check if the body of the second candlestick engulfs the body of the first
            bool isBodyEngulfed = secondCandlestick.Open < firstCandlestick.Close &&
                                  secondCandlestick.Close > firstCandlestick.Open;

            return firstCandlestick.IsBearish && secondCandlestick.IsBullish && isBodyEngulfed;
        }
    }

    internal class BearishEngulfingRecognizer : Recognizer
    {
        public BearishEngulfingRecognizer() : base("Bearish Engulfing", 2) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            if (sublistCandlesticks.Count != 2)
            {
                return false; // Not enough candlesticks for the pattern
            }

            SmartCandlestick firstCandlestick = sublistCandlesticks[0];
            SmartCandlestick secondCandlestick = sublistCandlesticks[1];

            // Check if the body of the second candlestick engulfs the body of the first
            bool isBodyEngulfed = secondCandlestick.Open > firstCandlestick.Close &&
                                  secondCandlestick.Close < firstCandlestick.Open;

            return firstCandlestick.IsBullish && secondCandlestick.IsBearish && isBodyEngulfed;
        }
    }

    internal class BullishHaramiRecognizer : Recognizer
    {
        public BullishHaramiRecognizer() : base("Bullish Harami", 2) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            if (sublistCandlesticks.Count != 2)
            {
                return false; // Not enough candlesticks for the pattern
            }

            SmartCandlestick firstCandlestick = sublistCandlesticks[0];
            SmartCandlestick secondCandlestick = sublistCandlesticks[1];

            // Check if the body of the second candlestick is within the first
            bool isBodyContained = secondCandlestick.Open > firstCandlestick.Close &&
                                   secondCandlestick.Close < firstCandlestick.Open;

            return firstCandlestick.IsBearish && secondCandlestick.IsBullish && isBodyContained;
        }
    }

    internal class BearishHaramiRecognizer : Recognizer
    {
        public BearishHaramiRecognizer() : base("Bearish Harami", 2) { }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            if (sublistCandlesticks.Count != 2)
            {
                return false; // Not enough candlesticks for the pattern
            }

            SmartCandlestick firstCandlestick = sublistCandlesticks[0];
            SmartCandlestick secondCandlestick = sublistCandlesticks[1];

            // Check if the body of the second candlestick is within the first
            bool isBodyContained = secondCandlestick.Open < firstCandlestick.Close &&
                                   secondCandlestick.Close > firstCandlestick.Open;

            return firstCandlestick.IsBullish && secondCandlestick.IsBearish && isBodyContained;
        }
    }

    internal class PeakRecognizer : Recognizer
    {
        public PeakRecognizer() : base("Peak", 3) { }

        protected override int GetResultIndex(int currentIndex)
        {
            return currentIndex - 1; // Adjust to point to the middle candlestick
        }

        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            if (sublistCandlesticks.Count != 3)
            {
                return false; // Not enough candlesticks for the pattern
            }

            SmartCandlestick leftCandlestick = sublistCandlesticks[0];
            SmartCandlestick middleCandlestick = sublistCandlesticks[1];
            SmartCandlestick rightCandlestick = sublistCandlesticks[2];

            // Check if the middle candlestick's high is higher than the left and right ones
            return middleCandlestick.High > leftCandlestick.High &&
                   middleCandlestick.High > rightCandlestick.High;
        }
    }

    internal class ValleyRecognizer : Recognizer
    {
        public ValleyRecognizer() : base("Valley", 3) { }
        protected override int GetResultIndex(int currentIndex)
        {
            return currentIndex - 1; // Adjust to point to the middle candlestick
        }
        protected override bool RecognizePattern(List<SmartCandlestick> sublistCandlesticks)
        {
            if (sublistCandlesticks.Count != 3)
            {
                return false; // Not enough candlesticks for the pattern
            }

            SmartCandlestick leftCandlestick = sublistCandlesticks[0];
            SmartCandlestick middleCandlestick = sublistCandlesticks[1];
            SmartCandlestick rightCandlestick = sublistCandlesticks[2];

            // Check if the middle candlestick's high is higher than the left and right ones
            return middleCandlestick.Low < leftCandlestick.Low &&
                   middleCandlestick.Low < rightCandlestick.Low;
        }
    }
}
