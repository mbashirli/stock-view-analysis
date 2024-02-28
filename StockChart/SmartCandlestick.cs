using System;
namespace StockChart
{
    public class SmartCandlestick : Candlestick
    {
        public Double Range { get; private set; }
        public Double BodyRange { get; private set; }   
        public Double TopPrice {  get; private set; }  
        public Double BottomPrice { get; private set; }
        public Double TopTail {  get; private set; }
        public Double BottomTail { get; private set; }
        public Boolean IsBullish { get; private set; }
        public Boolean IsBearish { get; private set; }
        public Boolean IsNeutral { get; private set; }
        public Boolean IsMarubozu { get; private set; }
        public Boolean IsDoji { get; private set; }
        public Boolean IsDragonflyDoji { get; private set; }
        public Boolean IsGravestoneDoji { get; private set; }
        public Boolean IsHammer { get; private set; }
        public Boolean IsBullishHammer { get; private set; }
        public Boolean IsBearishHammer { get; private set; }
        public Boolean IsInvertedHammer { get; private set; }

        public SmartCandlestick(string ticker, string period, DateTime date, double open, double high, double low, double close, double volume)
            : base(ticker, period, date, open, high, low, close, volume)
        {
            calculateProperties();
        }

        // Calculates various candlestick properties and patterns based on the Open, High, Low, and Close prices of a stock.
        private void calculateProperties()
        {
            this.Range = this.High - this.Low;
            this.BodyRange = Math.Abs(this.Close - this.Open);
            this.TopPrice = Math.Max(this.Open, this.Close);
            this.BottomPrice = Math.Min(this.Open, this.Close);
            this.TopTail = this.High - this.TopPrice;
            this.BottomTail = this.BottomPrice - this.Low;

            this.IsBullish = this.Close > this.Open;
            this.IsBearish = this.Close < this.Open;
            this.IsNeutral = this.Close == this.Open;

            const double smallThreshold = 0.1; 

            this.IsMarubozu = this.BodyRange == this.Range;
            this.IsDoji = this.BodyRange <= (this.Range * smallThreshold);
            this.IsDragonflyDoji = this.IsDoji && this.BottomTail > this.TopTail;
            this.IsGravestoneDoji = this.IsDoji && this.TopTail > this.BottomTail;
            this.IsHammer = this.BottomTail >= 2 * this.BodyRange && this.TopTail <= smallThreshold;
            this.IsBullishHammer = this.IsHammer && this.IsBullish;
            this.IsBearishHammer = this.IsHammer && this.IsBearish;
            this.IsInvertedHammer = this.TopTail >= 2 * this.BodyRange && this.BottomTail <= smallThreshold;
        }

    }

}
