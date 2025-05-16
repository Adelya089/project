namespace QueueVisualization
{
    partial class MainForm
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
        private System.Windows.Forms.Button instructionsButton;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            enqueueButton = new Button();
            dequeueButton = new Button();
            clearButton = new Button();
            backButton = new Button();
            forwardButton = new Button();
            saveButton = new Button();
            loadButton = new Button();
            headLabel = new Label();
            tailLabel = new Label();
            queuePanel = new Panel();
            capacityNumericUpDown = new NumericUpDown();
            capacityLabel = new Label();
            headPanel = new Panel();
            headValueLabel = new Label();
            tailPanel = new Panel();
            tailValueLabel = new Label();
            instructionsButton = new Button();
            ((System.ComponentModel.ISupportInitialize)capacityNumericUpDown).BeginInit();
            headPanel.SuspendLayout();
            tailPanel.SuspendLayout();
            SuspendLayout();
            // 
            // enqueueButton
            // 
            enqueueButton.Location = new Point(16, 18);
            enqueueButton.Margin = new Padding(4, 5, 4, 5);
            enqueueButton.Name = "enqueueButton";
            enqueueButton.Size = new Size(100, 35);
            enqueueButton.TabIndex = 0;
            enqueueButton.Text = "Enqueue";
            enqueueButton.UseVisualStyleBackColor = true;
            enqueueButton.Click += EnqueueButton_Click;
            // 
            // dequeueButton
            // 
            dequeueButton.Location = new Point(124, 18);
            dequeueButton.Margin = new Padding(4, 5, 4, 5);
            dequeueButton.Name = "dequeueButton";
            dequeueButton.Size = new Size(100, 35);
            dequeueButton.TabIndex = 1;
            dequeueButton.Text = "Dequeue";
            dequeueButton.UseVisualStyleBackColor = true;
            dequeueButton.Click += DequeueButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(232, 18);
            clearButton.Margin = new Padding(4, 5, 4, 5);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(100, 35);
            clearButton.TabIndex = 2;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(340, 18);
            backButton.Margin = new Padding(4, 5, 4, 5);
            backButton.Name = "backButton";
            backButton.Size = new Size(100, 35);
            backButton.TabIndex = 3;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += BackButton_Click;
            // 
            // forwardButton
            // 
            forwardButton.Location = new Point(448, 18);
            forwardButton.Margin = new Padding(4, 5, 4, 5);
            forwardButton.Name = "forwardButton";
            forwardButton.Size = new Size(100, 35);
            forwardButton.TabIndex = 4;
            forwardButton.Text = "Forward";
            forwardButton.UseVisualStyleBackColor = true;
            forwardButton.Click += ForwardButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(556, 18);
            saveButton.Margin = new Padding(4, 5, 4, 5);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(100, 35);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(664, 18);
            loadButton.Margin = new Padding(4, 5, 4, 5);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(100, 35);
            loadButton.TabIndex = 6;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += LoadButton_Click;
            // 
            // headLabel
            // 
            headLabel.AutoSize = true;
            headLabel.Location = new Point(178, 368);
            headLabel.Margin = new Padding(4, 0, 4, 0);
            headLabel.Name = "headLabel";
            headLabel.Size = new Size(48, 20);
            headLabel.TabIndex = 7;
            headLabel.Text = "Head:";
            // 
            // tailLabel
            // 
            tailLabel.AutoSize = true;
            tailLabel.Location = new Point(22, 368);
            tailLabel.Margin = new Padding(4, 0, 4, 0);
            tailLabel.Name = "tailLabel";
            tailLabel.Size = new Size(34, 20);
            tailLabel.TabIndex = 8;
            tailLabel.Text = "Tail:";
            // 
            // queuePanel
            // 
            queuePanel.BorderStyle = BorderStyle.FixedSingle;
            queuePanel.Location = new Point(53, 123);
            queuePanel.Margin = new Padding(4, 5, 4, 5);
            queuePanel.Name = "queuePanel";
            queuePanel.Size = new Size(927, 107);
            queuePanel.TabIndex = 9;
            // 
            // capacityNumericUpDown
            // 
            capacityNumericUpDown.Location = new Point(896, 23);
            capacityNumericUpDown.Margin = new Padding(4, 5, 4, 5);
            capacityNumericUpDown.Name = "capacityNumericUpDown";
            capacityNumericUpDown.Size = new Size(133, 27);
            capacityNumericUpDown.TabIndex = 10;
            capacityNumericUpDown.Value = new decimal(new int[] { 15, 0, 0, 0 });
            capacityNumericUpDown.ValueChanged += capacityNumericUpDown_ValueChanged;
            // 
            // capacityLabel
            // 
            capacityLabel.AutoSize = true;
            capacityLabel.Location = new Point(824, 26);
            capacityLabel.Margin = new Padding(4, 0, 4, 0);
            capacityLabel.Name = "capacityLabel";
            capacityLabel.Size = new Size(69, 20);
            capacityLabel.TabIndex = 11;
            capacityLabel.Text = "Capacity:";
            // 
            // headPanel
            // 
            headPanel.BorderStyle = BorderStyle.FixedSingle;
            headPanel.Controls.Add(headValueLabel);
            headPanel.Location = new Point(16, 268);
            headPanel.Margin = new Padding(4, 5, 4, 5);
            headPanel.Name = "headPanel";
            headPanel.Size = new Size(133, 76);
            headPanel.TabIndex = 12;
            // 
            // headValueLabel
            // 
            headValueLabel.AutoSize = true;
            headValueLabel.Location = new Point(5, 42);
            headValueLabel.Margin = new Padding(4, 0, 4, 0);
            headValueLabel.Name = "headValueLabel";
            headValueLabel.Size = new Size(17, 20);
            headValueLabel.TabIndex = 8;
            headValueLabel.Text = "0";
            // 
            // tailPanel
            // 
            tailPanel.BorderStyle = BorderStyle.FixedSingle;
            tailPanel.Controls.Add(tailValueLabel);
            tailPanel.Location = new Point(173, 268);
            tailPanel.Margin = new Padding(4, 5, 4, 5);
            tailPanel.Name = "tailPanel";
            tailPanel.Size = new Size(133, 76);
            tailPanel.TabIndex = 13;
            // 
            // tailValueLabel
            // 
            tailValueLabel.AutoSize = true;
            tailValueLabel.Location = new Point(4, 42);
            tailValueLabel.Margin = new Padding(4, 0, 4, 0);
            tailValueLabel.Name = "tailValueLabel";
            tailValueLabel.Size = new Size(17, 20);
            tailValueLabel.TabIndex = 9;
            tailValueLabel.Text = "0";
            // 
            // instructionsButton
            // 
            instructionsButton.Location = new Point(889, 540);
            instructionsButton.Name = "instructionsButton";
            instructionsButton.Size = new Size(116, 49);
            instructionsButton.TabIndex = 0;
            instructionsButton.Text = "Instructions";
            instructionsButton.Click += instructionsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 709);
            Controls.Add(instructionsButton);
            Controls.Add(tailPanel);
            Controls.Add(headPanel);
            Controls.Add(capacityLabel);
            Controls.Add(capacityNumericUpDown);
            Controls.Add(queuePanel);
            Controls.Add(tailLabel);
            Controls.Add(headLabel);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(forwardButton);
            Controls.Add(backButton);
            Controls.Add(clearButton);
            Controls.Add(dequeueButton);
            Controls.Add(enqueueButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            Text = "Queue Visualization";
            ((System.ComponentModel.ISupportInitialize)capacityNumericUpDown).EndInit();
            headPanel.ResumeLayout(false);
            headPanel.PerformLayout();
            tailPanel.ResumeLayout(false);
            tailPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button enqueueButton;
        private System.Windows.Forms.Button dequeueButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Label tailLabel;
        private System.Windows.Forms.Panel queuePanel;
        private System.Windows.Forms.NumericUpDown capacityNumericUpDown;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.Panel headPanel;
        private System.Windows.Forms.Label headValueLabel;
        private System.Windows.Forms.Panel tailPanel;
        private System.Windows.Forms.Label tailValueLabel;
    }
}