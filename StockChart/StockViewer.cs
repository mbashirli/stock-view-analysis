using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockChart
{
    public partial class StockViewer : Form
    {

        List<SmartCandlestick> candlesticks = new List<SmartCandlestick>();
        List<SmartCandlestick> completeData = new List<SmartCandlestick>();
        List<Recognizer> Recognizers = new List<Recognizer>();
        public DateTime startDate;
        public DateTime endDate;

        public StockViewer()
        {
            // Call the base class constructor for initializing components.
            InitializeComponent();
            LoadPatterns();

            // Configure the "Prices" series for the main stock chart.
            Graph.Series["Prices"].XValueMember = "Date"; // Set X-values to the "Date" property.
            Graph.Series["Prices"].YValuesPerPoint = 4; // Expect 4 Y-values per data point.
            Graph.Series["Prices"].YValueMembers = "High,Low,Open,Close"; // Specify Y-values from "High", "Low", "Open", and "Close" properties.

            // Customize the appearance of the main chart's grid lines.
            Graph.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0; // Remove X-axis grid lines.
            Graph.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0; // Remove Y-axis grid lines.

            // Set the X-axis value type to Date for the "Prices" series.
            Graph.Series["Prices"].XValueType = ChartValueType.Date;

            // Set custom properties for the "Prices" series to specify colors for price movements.
            Graph.Series["Prices"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";

            // Customize the appearance of the second chart area's grid lines.
            Graph.ChartAreas["ChartArea2"].AxisX.MajorGrid.LineWidth = 0; // Remove X-axis grid lines.
            Graph.ChartAreas["ChartArea2"].AxisY.MajorGrid.LineWidth = 0; // Remove Y-axis grid lines.

            // Configure the "Volume" series for displaying trading volume.
            Graph.Series["Volume"].XValueMember = "Date"; // Set X-values to the "Date" property.
            Graph.Series["Volume"].XValueType = ChartValueType.Date; // Set X-value type to Date.
            Graph.Series["Volume"].YValuesPerPoint = 1; // Expect 1 Y-value per data point.
            Graph.Series["Volume"].YValueMembers = "Volume"; // Specify Y-values from the "Volume" property.

            // Bind the data to the chart.
            Graph.DataBind();
        }

        // Method to update and display candlesticks based on the selected date range.
        public void UpdateAndDisplayCandlesticks()
        {
            // Set the date pickers to the current start and end dates.
            startDateTimePicker.Value = startDate;
            endDateTimePicker.Value = endDate;

            // Check if the current data source is a list of SmartCandlestick objects.
            if (Graph.DataSource is List<SmartCandlestick> dataSource)
            {
                // Copy the data from the data source to a complete data list.
                completeData = new List<SmartCandlestick>(dataSource);

                // Use the FilterCandlesticksByDateRange method to filter the data.
                candlesticks = FilterCandlesticksByDateRange(completeData, startDate, endDate);

                // Set the filtered list as the new data source and bind it to the graph.
                Graph.DataSource = candlesticks;
                Graph.DataBind();
            }
        }


        private void LoadPatterns()
        {
            // Populate the Recognizers list with various candlestick pattern recognizers.
            // Each recognizer corresponds to a specific candlestick pattern.
            Recognizers.Add(new BullishRecognizer());
            Recognizers.Add(new BearishRecognizer());
            Recognizers.Add(new NeutralRecognizer());
            Recognizers.Add(new MarubozuRecognizer());
            Recognizers.Add(new DojiRecognizer());
            Recognizers.Add(new DragonflyDojiRecognizer());
            Recognizers.Add(new GravestoneDojiRecognizer());
            Recognizers.Add(new HammerRecognizer());
            Recognizers.Add(new BullishHammerRecognizer());
            Recognizers.Add(new BearishHammerRecognizer());
            Recognizers.Add(new InvertedHammerRecognizer());
            Recognizers.Add(new BullishEngulfingRecognizer());
            Recognizers.Add(new BearishEngulfingRecognizer());
            Recognizers.Add(new BullishHaramiRecognizer());
            Recognizers.Add(new BearishHaramiRecognizer());
            Recognizers.Add(new PeakRecognizer());
            Recognizers.Add(new ValleyRecognizer());

            // Clear existing items in the comboBox.
            patternBox.Items.Clear();

            // Set the comboBox's data source to the list of pattern recognizers.
            patternBox.DataSource = Recognizers;

            // Define which property of Recognizer objects will be displayed in the comboBox.
            patternBox.DisplayMember = "PatternName";
            
            // Reset the selected index in the comboBox, indicating no selection initially
            patternBox.SelectedIndex = -1;
        }

        // Event handler for when the selected item in the comboBox changes.
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCandlesticks();
            // Graph.Annotations.Clear(); // Removes any existing annotations from the graph.

            // Retrieve the selected pattern recognizer from the comboBox.
            Recognizer patternRecognizer = patternBox.SelectedItem as Recognizer;

            if (patternRecognizer != null)
            {
                // Recognize patterns in the current list of candlesticks.
                List<int> indexes = patternRecognizer.RecognizePatterns(candlesticks);

                // Iterate over each index where a pattern is recognized.
                foreach (int index in indexes)
                {
                    // Create a new annotation for the detected pattern.
                    RectangleAnnotation annotation = new RectangleAnnotation
                    {
                        Text = patternRecognizer.PatternName, // Set annotation text to the pattern's name.
                        AnchorDataPoint = Graph.Series["Prices"].Points[index] // Anchor annotation to the corresponding chart point.
                    };
                    Graph.Annotations.Add(annotation); // Add the annotation to the graph.
                }
            }
        }

        // Loads candlestick data into a local variable from the graph's data source.
        private void LoadCandlesticks()
        {
            // Attempts to cast the Graph's data source to a list of smartCandlestick objects.
            List<SmartCandlestick> dataSource = Graph.DataSource as List<SmartCandlestick>;

            // If the cast is successful, the local candlesticks collection is updated with the data from the graph's data source.
            if (dataSource != null)
            {
                candlesticks = dataSource;
            }
        }

        // Event handler for the Update button.
        private void UpdateButton(object sender, EventArgs e)
        {
            // Clear existing annotations and reset the pattern selection.
            Graph.Annotations.Clear();
            patternBox.SelectedIndex = -1;

            // Update the date range based on the values from the date pickers.
            startDate = startDateTimePicker.Value;
            endDate = endDateTimePicker.Value;

            // Filter the candlestick data based on the new date range.
            candlesticks = FilterCandlesticksByDateRange(completeData, startDate, endDate);

            // Update and refresh the chart with the new data.
            Graph.DataSource = candlesticks;
            Graph.DataBind();
        }

        // Method to filter candlesticks based on a specified date range.
        private List<SmartCandlestick> FilterCandlesticksByDateRange(List<SmartCandlestick> allCandlesticks, DateTime startDate, DateTime endDate)
        {
            // Initialize a new list to hold filtered records.
            var filteredRecords = new List<SmartCandlestick>();

            // Iterate through all candlesticks and add those within the date range to the filtered list.
            foreach (var record in allCandlesticks)
            {
                if (record.Date >= startDate && record.Date <= endDate)
                {
                    filteredRecords.Add(record);
                }
            }

            // Reverse the order of the filtered list if required.
            filteredRecords.Reverse();
            return filteredRecords;
        }

        private void ClearAnnotationsButton_Click(object sender, EventArgs e)
        {
            patternBox.SelectedIndex = -1;
            Graph.Annotations.Clear();
        }
    }
}
