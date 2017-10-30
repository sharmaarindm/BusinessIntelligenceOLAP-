namespace asharma_zpecin_A3
{
    partial class Form1
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
            this.ProductsCombo = new System.Windows.Forms.ComboBox();
            this.LinesCombo = new System.Windows.Forms.ComboBox();
            this.ProductscheckBox = new System.Windows.Forms.CheckBox();
            this.LinescheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductsCombo
            // 
            this.ProductsCombo.FormattingEnabled = true;
            this.ProductsCombo.Location = new System.Drawing.Point(481, 76);
            this.ProductsCombo.Name = "ProductsCombo";
            this.ProductsCombo.Size = new System.Drawing.Size(121, 21);
            this.ProductsCombo.TabIndex = 0;
            // 
            // LinesCombo
            // 
            this.LinesCombo.FormattingEnabled = true;
            this.LinesCombo.Location = new System.Drawing.Point(481, 142);
            this.LinesCombo.Name = "LinesCombo";
            this.LinesCombo.Size = new System.Drawing.Size(121, 21);
            this.LinesCombo.TabIndex = 1;
            // 
            // ProductscheckBox
            // 
            this.ProductscheckBox.AutoSize = true;
            this.ProductscheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductscheckBox.Location = new System.Drawing.Point(609, 79);
            this.ProductscheckBox.Name = "ProductscheckBox";
            this.ProductscheckBox.Size = new System.Drawing.Size(124, 24);
            this.ProductscheckBox.TabIndex = 2;
            this.ProductscheckBox.Text = "All Products";
            this.ProductscheckBox.UseVisualStyleBackColor = true;
            // 
            // LinescheckBox
            // 
            this.LinescheckBox.AutoSize = true;
            this.LinescheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinescheckBox.Location = new System.Drawing.Point(609, 142);
            this.LinescheckBox.Name = "LinescheckBox";
            this.LinescheckBox.Size = new System.Drawing.Size(96, 24);
            this.LinescheckBox.TabIndex = 3;
            this.LinescheckBox.Text = "All Lines";
            this.LinescheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(481, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Generate Report:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(481, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select YOYO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(481, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Lines:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(424, 402);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 427);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LinescheckBox);
            this.Controls.Add(this.ProductscheckBox);
            this.Controls.Add(this.LinesCombo);
            this.Controls.Add(this.ProductsCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProductsCombo;
        private System.Windows.Forms.ComboBox LinesCombo;
        private System.Windows.Forms.CheckBox ProductscheckBox;
        private System.Windows.Forms.CheckBox LinescheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

