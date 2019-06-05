namespace Term_Project
{
    partial class DisplayForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.freqChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.applyDFT = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.welchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordButton = new System.Windows.Forms.Button();
            this.DFTChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.selection_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.freqChart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DFTChart)).BeginInit();
            this.SuspendLayout();
            // 
            // freqChart
            // 
            chartArea1.Name = "ChartArea1";
            this.freqChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.freqChart.Legends.Add(legend1);
            this.freqChart.Location = new System.Drawing.Point(162, 73);
            this.freqChart.Name = "freqChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Frequency";
            this.freqChart.Series.Add(series1);
            this.freqChart.Size = new System.Drawing.Size(1396, 355);
            this.freqChart.TabIndex = 0;
            this.freqChart.Text = "freqChart";
            this.freqChart.Click += new System.EventHandler(this.freqChart_Click);
            // 
            // applyDFT
            // 
            this.applyDFT.Location = new System.Drawing.Point(1615, 231);
            this.applyDFT.Name = "applyDFT";
            this.applyDFT.Size = new System.Drawing.Size(158, 51);
            this.applyDFT.TabIndex = 1;
            this.applyDFT.Text = "Apply DFT";
            this.applyDFT.UseVisualStyleBackColor = true;
            this.applyDFT.Click += new System.EventHandler(this.applyDFT_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.windowingToolStripMenuItem,
            this.filterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1831, 40);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(173, 38);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click_1);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 36);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(169, 38);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // windowingToolStripMenuItem
            // 
            this.windowingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangularToolStripMenuItem,
            this.triangularToolStripMenuItem,
            this.welchToolStripMenuItem});
            this.windowingToolStripMenuItem.Name = "windowingToolStripMenuItem";
            this.windowingToolStripMenuItem.Size = new System.Drawing.Size(148, 36);
            this.windowingToolStripMenuItem.Text = "Windowing";
            // 
            // rectangularToolStripMenuItem
            // 
            this.rectangularToolStripMenuItem.Name = "rectangularToolStripMenuItem";
            this.rectangularToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.rectangularToolStripMenuItem.Text = "Rectangular";
            this.rectangularToolStripMenuItem.Click += new System.EventHandler(this.rectangularToolStripMenuItem_Click);
            // 
            // triangularToolStripMenuItem
            // 
            this.triangularToolStripMenuItem.Name = "triangularToolStripMenuItem";
            this.triangularToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.triangularToolStripMenuItem.Text = "Triangular";
            this.triangularToolStripMenuItem.Click += new System.EventHandler(this.triangularToolStripMenuItem_Click);
            // 
            // welchToolStripMenuItem
            // 
            this.welchToolStripMenuItem.Name = "welchToolStripMenuItem";
            this.welchToolStripMenuItem.Size = new System.Drawing.Size(239, 38);
            this.welchToolStripMenuItem.Text = "Welch";
            this.welchToolStripMenuItem.Click += new System.EventHandler(this.welchToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(80, 36);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // recordButton
            // 
            this.recordButton.Location = new System.Drawing.Point(1615, 150);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(158, 64);
            this.recordButton.TabIndex = 4;
            this.recordButton.Text = "Record";
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.record_Click);
            // 
            // DFTChart
            // 
            chartArea2.Name = "ChartArea1";
            this.DFTChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.DFTChart.Legends.Add(legend2);
            this.DFTChart.Location = new System.Drawing.Point(162, 443);
            this.DFTChart.Name = "DFTChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Amplitude";
            this.DFTChart.Series.Add(series2);
            this.DFTChart.Size = new System.Drawing.Size(1396, 355);
            this.DFTChart.TabIndex = 5;
            this.DFTChart.Text = "DFTChart";
            this.DFTChart.Click += new System.EventHandler(this.DFTChart_Click);
            // 
            // selection_button
            // 
            this.selection_button.Location = new System.Drawing.Point(12, 231);
            this.selection_button.Name = "selection_button";
            this.selection_button.Size = new System.Drawing.Size(137, 63);
            this.selection_button.TabIndex = 6;
            this.selection_button.Text = "Selection";
            this.selection_button.UseVisualStyleBackColor = true;
            this.selection_button.Click += new System.EventHandler(this.selection_button_Click);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1831, 855);
            this.Controls.Add(this.selection_button);
            this.Controls.Add(this.DFTChart);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.applyDFT);
            this.Controls.Add(this.freqChart);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DisplayForm";
            this.Text = "New Form";
            ((System.ComponentModel.ISupportInitialize)(this.freqChart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DFTChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart freqChart;
        private System.Windows.Forms.Button applyDFT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button recordButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart DFTChart;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Button selection_button;
        private System.Windows.Forms.ToolStripMenuItem windowingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem welchToolStripMenuItem;
    }
}

