namespace StockChart
{
    partial class StockViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.patternBox = new System.Windows.Forms.ComboBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ClearAnnotationsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.SuspendLayout();
            // 
            // Graph
            // 
            chartArea5.BackColor = System.Drawing.Color.Transparent;
            chartArea5.Name = "ChartArea1";
            chartArea6.AlignWithChartArea = "ChartArea1";
            chartArea6.BackColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea2";
            this.Graph.ChartAreas.Add(chartArea5);
            this.Graph.ChartAreas.Add(chartArea6);
            this.Graph.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.BackColor = System.Drawing.Color.Transparent;
            legend3.BorderColor = System.Drawing.Color.Black;
            legend3.Name = "Legend1";
            this.Graph.Legends.Add(legend3);
            this.Graph.Location = new System.Drawing.Point(0, 0);
            this.Graph.Name = "Graph";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.Name = "Prices";
            series5.YValuesPerPoint = 4;
            series6.ChartArea = "ChartArea2";
            series6.Color = System.Drawing.Color.LawnGreen;
            series6.IsXValueIndexed = true;
            series6.Legend = "Legend1";
            series6.Name = "Volume";
            series6.ShadowColor = System.Drawing.Color.GreenYellow;
            series6.YValuesPerPoint = 4;
            this.Graph.Series.Add(series5);
            this.Graph.Series.Add(series6);
            this.Graph.Size = new System.Drawing.Size(1443, 654);
            this.Graph.TabIndex = 2;
            this.Graph.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 665);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patterns";
            // 
            // patternBox
            // 
            this.patternBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternBox.FormattingEnabled = true;
            this.patternBox.Location = new System.Drawing.Point(34, 690);
            this.patternBox.Margin = new System.Windows.Forms.Padding(2);
            this.patternBox.Name = "patternBox";
            this.patternBox.Size = new System.Drawing.Size(166, 33);
            this.patternBox.TabIndex = 4;
            this.patternBox.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(217, 692);
            this.startDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(294, 26);
            this.startDateTimePicker.TabIndex = 5;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(550, 692);
            this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(294, 26);
            this.endDateTimePicker.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 669);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Start Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 670);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "End Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 689);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "Update Chart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UpdateButton);
            // 
            // ClearAnnotationsButton
            // 
            this.ClearAnnotationsButton.Location = new System.Drawing.Point(1008, 689);
            this.ClearAnnotationsButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClearAnnotationsButton.Name = "ClearAnnotationsButton";
            this.ClearAnnotationsButton.Size = new System.Drawing.Size(137, 36);
            this.ClearAnnotationsButton.TabIndex = 10;
            this.ClearAnnotationsButton.Text = "Clear";
            this.ClearAnnotationsButton.UseVisualStyleBackColor = true;
            this.ClearAnnotationsButton.Click += new System.EventHandler(this.ClearAnnotationsButton_Click);
            // 
            // StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 747);
            this.Controls.Add(this.ClearAnnotationsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.patternBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Graph);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StockViewer";
            this.Text = "StockViewer";
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox patternBox;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ClearAnnotationsButton;
    }
}