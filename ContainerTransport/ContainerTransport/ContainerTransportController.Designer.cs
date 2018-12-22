namespace ContainerTransport
{
    partial class ContainerTransportController
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
            this.BuildShipButton = new System.Windows.Forms.Button();
            this.ShipWidthLabel = new System.Windows.Forms.Label();
            this.ShipLengthLabel = new System.Windows.Forms.Label();
            this.ShipWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ShipLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ShipWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipLengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildShipButton
            // 
            this.BuildShipButton.Location = new System.Drawing.Point(66, 347);
            this.BuildShipButton.Name = "BuildShipButton";
            this.BuildShipButton.Size = new System.Drawing.Size(71, 68);
            this.BuildShipButton.TabIndex = 0;
            this.BuildShipButton.Text = "Build Ship";
            this.BuildShipButton.UseVisualStyleBackColor = true;
            this.BuildShipButton.Click += new System.EventHandler(this.BuildShipButton_Click);
            // 
            // ShipWidthLabel
            // 
            this.ShipWidthLabel.AutoSize = true;
            this.ShipWidthLabel.Location = new System.Drawing.Point(37, 206);
            this.ShipWidthLabel.Name = "ShipWidthLabel";
            this.ShipWidthLabel.Size = new System.Drawing.Size(166, 13);
            this.ShipWidthLabel.TabIndex = 1;
            this.ShipWidthLabel.Text = "Ship Width:                  Containers";
            // 
            // ShipLengthLabel
            // 
            this.ShipLengthLabel.AutoSize = true;
            this.ShipLengthLabel.Location = new System.Drawing.Point(37, 238);
            this.ShipLengthLabel.Name = "ShipLengthLabel";
            this.ShipLengthLabel.Size = new System.Drawing.Size(165, 13);
            this.ShipLengthLabel.TabIndex = 2;
            this.ShipLengthLabel.Text = "Ship Length:                Containers";
            // 
            // ShipWidthNumericUpDown
            // 
            this.ShipWidthNumericUpDown.Location = new System.Drawing.Point(105, 204);
            this.ShipWidthNumericUpDown.Name = "ShipWidthNumericUpDown";
            this.ShipWidthNumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.ShipWidthNumericUpDown.TabIndex = 3;
            // 
            // ShipLengthNumericUpDown
            // 
            this.ShipLengthNumericUpDown.Location = new System.Drawing.Point(105, 236);
            this.ShipLengthNumericUpDown.Name = "ShipLengthNumericUpDown";
            this.ShipLengthNumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.ShipLengthNumericUpDown.TabIndex = 4;
            // 
            // ContainerTransportController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 794);
            this.Controls.Add(this.ShipLengthNumericUpDown);
            this.Controls.Add(this.ShipWidthNumericUpDown);
            this.Controls.Add(this.ShipLengthLabel);
            this.Controls.Add(this.ShipWidthLabel);
            this.Controls.Add(this.BuildShipButton);
            this.Name = "ContainerTransportController";
            this.Text = "Container Transport";
            this.Load += new System.EventHandler(this.ContainerTransportController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShipWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipLengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuildShipButton;
        private System.Windows.Forms.Label ShipWidthLabel;
        private System.Windows.Forms.Label ShipLengthLabel;
        private System.Windows.Forms.NumericUpDown ShipWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown ShipLengthNumericUpDown;
    }
}

