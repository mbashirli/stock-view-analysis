using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Globalization;


/* 
This is the work of Murad Bashirli for the Project 3 of Software System Development  
*/

namespace StockChart
{
    public partial class StockLoaderForm : Form
    {

        FileInfo[] files = null;
        public StockLoaderForm()
        {
            InitializeComponent();

            string stockFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "/Stock Data/";

            try
            {
                DirectoryInfo directory = new DirectoryInfo(stockFilePath);
                if (directory.Exists)
                {
                    files = directory.GetFiles("*.csv");
                }
                else
                {
                    // Handle the case where the folder doesn't exist.
                    // MessageBox.Show("The 'Stock Data' folder does not exist.");
                    files = new FileInfo[0];
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show($"An error occurred: {ex.Message}");
                files = new FileInfo[0];
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

            if (comboBoxTickers.SelectedItem == null)
            {
                MessageBox.Show("Please select an option from the ComboBox.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected start and end date from DateTimePickers
            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            string fileName = comboBoxTickers.SelectedItem.ToString();
            string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "/Stock Data/" + fileName;

            if (File.Exists(filePath))
            {
                // Call a function (LoadStockViewer) to load the stock viewer with the selected data
                LoadStockViewer(filePath, fileName, startDate, endDate);
            }
            else
            {
                // Display a message box indicating that the file was not found
                MessageBox.Show("File not found");
                return;
            }
        }


        // This method loads the StockViewer with data from a CSV file.
        private void LoadStockViewer(string filePath, string fileName, DateTime startDate, DateTime endDate)
        {
            // Read the stock data from the CSV file and store it in a list.
            List<SmartCandlestick> records = ReadCsvFile(filePath);

            // Create an instance of the StockViewer form.
            StockViewer viewer = new StockViewer();
            viewer.Text = fileName;
            viewer.startDate = startDate;
            viewer.endDate = endDate;

            // Set the data source of the StockViewer's graph control to records.
            viewer.Graph.DataSource = records;
            viewer.UpdateAndDisplayCandlesticks();

            viewer.Show();
        }


        // This method reads stock data from a CSV file and returns a list of StockData objects.
        private List<SmartCandlestick> ReadCsvFile(string filePath)
        {
            // Create a list to store the StockData records.
            List<SmartCandlestick> records = new List<SmartCandlestick>();

            // Initialize a flag to skip the header row in the CSV file.
            bool isFirstRecord = true;

            try
            {
                // Open and read the CSV file using a StreamReader.
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    // Read each line of the CSV file.
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Skip the header row if it's the first record.
                        if (isFirstRecord)
                        {
                            isFirstRecord = false;
                            continue;
                        }

                        // Split the line into an array of parts using a comma as the delimiter.
                        string[] parts = line.Split(',');

                        // Create a StockData object and populate its properties from the CSV data.

                        String Ticker = Convert.ToString(parts[0]);
                        String Period = Convert.ToString(parts[1]);
                        DateTime Date = DateTime.ParseExact((parts[2] + parts[3]).Trim('"'), "MMM d yyyy", CultureInfo.InvariantCulture);
                        Double Open = Math.Round(Double.Parse(parts[4]), 2);
                        Double High = Math.Round(Double.Parse(parts[5]), 2);
                        Double Low = Math.Round(Double.Parse(parts[6]), 2);
                        Double Close = Math.Round(Double.Parse(parts[7]), 2);
                        Double Volume = long.Parse(parts[8]);

                        var record = new SmartCandlestick(Ticker, Period, Date, Open, High, Low, Close, Volume);
                        
                        // Add the StockData object to the records list.
                        records.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during file reading and display an error message.
                MessageBox.Show("Error reading CSV file: " + ex.Message);
            }

            // Return the list of StockData records.
            return records;
        }

        // Event handler for when the "Day" radio button is checked.
        private void radioButtonDay_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxTickers.SelectedIndex != -1) // Ensure an item is selected before removing.
            {
                // Remove the selected item from the ComboBox's Items collection.
                comboBoxTickers.SelectedIndex = -1;
            }

            // Clear the ComboBox's Items collection.
            comboBoxTickers.Items.Clear();

            // Populate the ComboBox with items containing "Day" in their names from the 'files' collection.
            AddFilesToComboBoxTickers(files, "Day");
        }

        // Event handler for when the "Week" radio button is checked.
        private void radioButtonWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxTickers.SelectedIndex != -1) // Ensure an item is selected before removing.
            {
                // Remove the selected item from the ComboBox's Items collection.
                comboBoxTickers.SelectedIndex = -1;
            }

            // Clear the ComboBox's Items collection.
            comboBoxTickers.Items.Clear();

            // Populate the ComboBox with items containing "Week" in their names from the 'files' collection.
            AddFilesToComboBoxTickers(files, "Week");
        }

        // Event handler for when the "Month" radio button is checked.
        private void radioButtonMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxTickers.SelectedIndex != -1) // Ensure an item is selected before removing.
            {
                // Remove the selected item from the ComboBox's Items collection.
                comboBoxTickers.SelectedIndex = -1;
            }

            // Clear the ComboBox's Items collection.
            comboBoxTickers.Items.Clear();

            // Populate the ComboBox with items containing "Month" in their names from the 'files' collection.
            AddFilesToComboBoxTickers(files, "Month");
        }

        // Event Handler for the Open File Button
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;

            List<string> FilePaths = new List<string>();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePaths.Clear();
                if (comboBoxTickers.SelectedIndex != -1) // Ensure an item is selected before removing.
                {
                    // Remove the selected item from the ComboBox's Items collection.
                    comboBoxTickers.Items.RemoveAt(comboBoxTickers.SelectedIndex);
                }

                comboBoxTickers.Items.Clear();
                string[] fullPaths = openFileDialog.FileNames;
                
                foreach (string fullPath in fullPaths)
                {
                    FilePaths.Add(fullPath);                                      
                }

                comboBoxTickers.Text = "Selected Files...";
                UncheckAllRadioButtons(groupBox1);

                // Get the selected start and end date from DateTimePickers
                DateTime startDate = dateTimePickerStart.Value;
                DateTime endDate = dateTimePickerEnd.Value;

                // Check if the file exists at the specified filePath
                foreach (string FilePath in FilePaths)
                {

                    if (File.Exists(FilePath))
                    {
                        // Call a function (LoadStockViewer) to load the stock viewer with the selected data
                        string fileName = Path.GetFileName(FilePath);
                        LoadStockViewer(FilePath, fileName, startDate, endDate);
                    }
                    else
                    {
                        // Display a message box indicating that the file was not found
                        MessageBox.Show("File not found");
                        return;
                    }
                }
            }
        }

        private void AddFilesToComboBoxTickers(FileInfo[] files, string fileType)
        {
            // Iterate over each file in the provided array of FileInfo objects.
            foreach (var file in files)
            {
                // Check if the file's name contains the specified fileType.
                // This helps in filtering files based on a particular type or criteria.
                if (file.Name.Contains(fileType))
                {
                    // If the file matches the criteria, add its name to the comboBox.
                    comboBoxTickers.Items.Add(file.Name);
                }
            }
        }

        private void UncheckAllRadioButtons(GroupBox groupBox)
        {
            // Iterate over each control within the provided groupBox.
            foreach (Control control in groupBox.Controls)
            {
                // Check if the control is a RadioButton.
                if (control is RadioButton)
                {
                    // Cast the control to a RadioButton type.
                    RadioButton radioButton = (RadioButton)control;

                    // Uncheck the RadioButton.
                    radioButton.Checked = false;
                }
            }
        }
    }
}

