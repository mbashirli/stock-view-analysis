using System;

namespace StockChart
{
    public class Candlestick
    {
        public string Ticker { get; set; }
        public string Period { get; set; }
        public DateTime Date { get; set; }
        public Double Open { get; set; }
        public Double High { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public Double Volume { get; set; }

        public Candlestick(string ticker, string period, DateTime date, double open, double high, double low, double close, double volume)
        {
            Ticker = ticker;
            Period = period;
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

    }
}
