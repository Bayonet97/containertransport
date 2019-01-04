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
            this.PlaceContainerButton = new System.Windows.Forms.Button();
            this.ShipBuilderBox = new System.Windows.Forms.GroupBox();
            this.ContainerPlacerBox = new System.Windows.Forms.GroupBox();
            this.UnorderedContainersListbox = new System.Windows.Forms.ListBox();
            this.NewContainerGroupBox = new System.Windows.Forms.GroupBox();
            this.AddResultLabel = new System.Windows.Forms.Label();
            this.ContainerTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ContainerTypeLabel = new System.Windows.Forms.Label();
            this.WeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WeightLimitLabel = new System.Windows.Forms.Label();
            this.AddContainerButton = new System.Windows.Forms.Button();
            this.ContentWeightLabel = new System.Windows.Forms.Label();
            this.ShipMaxWeightLabel = new System.Windows.Forms.Label();
            this.ShipMaxWeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ShipWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipLengthNumericUpDown)).BeginInit();
            this.ShipBuilderBox.SuspendLayout();
            this.ContainerPlacerBox.SuspendLayout();
            this.NewContainerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipMaxWeightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildShipButton
            // 
            this.BuildShipButton.Location = new System.Drawing.Point(6, 131);
            this.BuildShipButton.Name = "BuildShipButton";
            this.BuildShipButton.Size = new System.Drawing.Size(71, 48);
            this.BuildShipButton.TabIndex = 0;
            this.BuildShipButton.Text = "Build Ship";
            this.BuildShipButton.UseVisualStyleBackColor = true;
            this.BuildShipButton.Click += new System.EventHandler(this.BuildShipButton_Click);
            // 
            // ShipWidthLabel
            // 
            this.ShipWidthLabel.AutoSize = true;
            this.ShipWidthLabel.Location = new System.Drawing.Point(6, 34);
            this.ShipWidthLabel.Name = "ShipWidthLabel";
            this.ShipWidthLabel.Size = new System.Drawing.Size(166, 13);
            this.ShipWidthLabel.TabIndex = 1;
            this.ShipWidthLabel.Text = "Ship Width:                  Containers";
            // 
            // ShipLengthLabel
            // 
            this.ShipLengthLabel.AutoSize = true;
            this.ShipLengthLabel.Location = new System.Drawing.Point(6, 66);
            this.ShipLengthLabel.Name = "ShipLengthLabel";
            this.ShipLengthLabel.Size = new System.Drawing.Size(165, 13);
            this.ShipLengthLabel.TabIndex = 2;
            this.ShipLengthLabel.Text = "Ship Length:                Containers";
            // 
            // ShipWidthNumericUpDown
            // 
            this.ShipWidthNumericUpDown.Location = new System.Drawing.Point(74, 32);
            this.ShipWidthNumericUpDown.Name = "ShipWidthNumericUpDown";
            this.ShipWidthNumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.ShipWidthNumericUpDown.TabIndex = 3;
            // 
            // ShipLengthNumericUpDown
            // 
            this.ShipLengthNumericUpDown.Location = new System.Drawing.Point(76, 65);
            this.ShipLengthNumericUpDown.Name = "ShipLengthNumericUpDown";
            this.ShipLengthNumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.ShipLengthNumericUpDown.TabIndex = 4;
            // 
            // PlaceContainerButton
            // 
            this.PlaceContainerButton.Location = new System.Drawing.Point(198, 350);
            this.PlaceContainerButton.Name = "PlaceContainerButton";
            this.PlaceContainerButton.Size = new System.Drawing.Size(102, 24);
            this.PlaceContainerButton.TabIndex = 5;
            this.PlaceContainerButton.Text = "Place Containers";
            this.PlaceContainerButton.UseVisualStyleBackColor = true;
            this.PlaceContainerButton.Click += new System.EventHandler(this.PlaceContainerButton_Click);
            // 
            // ShipBuilderBox
            // 
            this.ShipBuilderBox.Controls.Add(this.ShipMaxWeightNumericUpDown);
            this.ShipBuilderBox.Controls.Add(this.ShipMaxWeightLabel);
            this.ShipBuilderBox.Controls.Add(this.ShipWidthNumericUpDown);
            this.ShipBuilderBox.Controls.Add(this.BuildShipButton);
            this.ShipBuilderBox.Controls.Add(this.ShipWidthLabel);
            this.ShipBuilderBox.Controls.Add(this.ShipLengthNumericUpDown);
            this.ShipBuilderBox.Controls.Add(this.ShipLengthLabel);
            this.ShipBuilderBox.Location = new System.Drawing.Point(15, 58);
            this.ShipBuilderBox.Name = "ShipBuilderBox";
            this.ShipBuilderBox.Size = new System.Drawing.Size(265, 185);
            this.ShipBuilderBox.TabIndex = 6;
            this.ShipBuilderBox.TabStop = false;
            this.ShipBuilderBox.Text = "Ship Builder";
            // 
            // ContainerPlacerBox
            // 
            this.ContainerPlacerBox.Controls.Add(this.UnorderedContainersListbox);
            this.ContainerPlacerBox.Controls.Add(this.NewContainerGroupBox);
            this.ContainerPlacerBox.Controls.Add(this.PlaceContainerButton);
            this.ContainerPlacerBox.Location = new System.Drawing.Point(15, 249);
            this.ContainerPlacerBox.Name = "ContainerPlacerBox";
            this.ContainerPlacerBox.Size = new System.Drawing.Size(306, 380);
            this.ContainerPlacerBox.TabIndex = 7;
            this.ContainerPlacerBox.TabStop = false;
            this.ContainerPlacerBox.Text = "Container Placer";
            this.ContainerPlacerBox.Visible = false;
            // 
            // UnorderedContainersListbox
            // 
            this.UnorderedContainersListbox.FormattingEnabled = true;
            this.UnorderedContainersListbox.Location = new System.Drawing.Point(9, 148);
            this.UnorderedContainersListbox.Name = "UnorderedContainersListbox";
            this.UnorderedContainersListbox.Size = new System.Drawing.Size(291, 186);
            this.UnorderedContainersListbox.TabIndex = 10;
            // 
            // NewContainerGroupBox
            // 
            this.NewContainerGroupBox.Controls.Add(this.AddResultLabel);
            this.NewContainerGroupBox.Controls.Add(this.ContainerTypeComboBox);
            this.NewContainerGroupBox.Controls.Add(this.ContainerTypeLabel);
            this.NewContainerGroupBox.Controls.Add(this.WeightNumericUpDown);
            this.NewContainerGroupBox.Controls.Add(this.WeightLimitLabel);
            this.NewContainerGroupBox.Controls.Add(this.AddContainerButton);
            this.NewContainerGroupBox.Controls.Add(this.ContentWeightLabel);
            this.NewContainerGroupBox.Location = new System.Drawing.Point(9, 33);
            this.NewContainerGroupBox.Name = "NewContainerGroupBox";
            this.NewContainerGroupBox.Size = new System.Drawing.Size(297, 109);
            this.NewContainerGroupBox.TabIndex = 9;
            this.NewContainerGroupBox.TabStop = false;
            this.NewContainerGroupBox.Text = "New Container";
            // 
            // AddResultLabel
            // 
            this.AddResultLabel.AutoSize = true;
            this.AddResultLabel.Location = new System.Drawing.Point(4, 84);
            this.AddResultLabel.Name = "AddResultLabel";
            this.AddResultLabel.Size = new System.Drawing.Size(0, 13);
            this.AddResultLabel.TabIndex = 11;
            // 
            // ContainerTypeComboBox
            // 
            this.ContainerTypeComboBox.FormattingEnabled = true;
            this.ContainerTypeComboBox.Items.AddRange(new object[] {
            "Normal",
            "Valuable",
            "Cooled",
            "Valuable and Cooled"});
            this.ContainerTypeComboBox.Location = new System.Drawing.Point(102, 50);
            this.ContainerTypeComboBox.Name = "ContainerTypeComboBox";
            this.ContainerTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.ContainerTypeComboBox.TabIndex = 10;
            // 
            // ContainerTypeLabel
            // 
            this.ContainerTypeLabel.AutoSize = true;
            this.ContainerTypeLabel.Location = new System.Drawing.Point(6, 53);
            this.ContainerTypeLabel.Name = "ContainerTypeLabel";
            this.ContainerTypeLabel.Size = new System.Drawing.Size(82, 13);
            this.ContainerTypeLabel.TabIndex = 9;
            this.ContainerTypeLabel.Text = "Container Type:";
            // 
            // WeightNumericUpDown
            // 
            this.WeightNumericUpDown.Location = new System.Drawing.Point(102, 19);
            this.WeightNumericUpDown.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.WeightNumericUpDown.Name = "WeightNumericUpDown";
            this.WeightNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.WeightNumericUpDown.TabIndex = 5;
            // 
            // WeightLimitLabel
            // 
            this.WeightLimitLabel.AutoSize = true;
            this.WeightLimitLabel.Location = new System.Drawing.Point(153, 16);
            this.WeightLimitLabel.Name = "WeightLimitLabel";
            this.WeightLimitLabel.Size = new System.Drawing.Size(143, 26);
            this.WeightLimitLabel.TabIndex = 8;
            this.WeightLimitLabel.Text = "Container weighs 4000kg.\r\nTotal can\'t exceed 30000kg!";
            // 
            // AddContainerButton
            // 
            this.AddContainerButton.Location = new System.Drawing.Point(189, 78);
            this.AddContainerButton.Name = "AddContainerButton";
            this.AddContainerButton.Size = new System.Drawing.Size(102, 25);
            this.AddContainerButton.TabIndex = 6;
            this.AddContainerButton.Text = "Add Container";
            this.AddContainerButton.UseVisualStyleBackColor = true;
            this.AddContainerButton.Click += new System.EventHandler(this.AddContainerButton_Click);
            // 
            // ContentWeightLabel
            // 
            this.ContentWeightLabel.AutoSize = true;
            this.ContentWeightLabel.Location = new System.Drawing.Point(4, 21);
            this.ContentWeightLabel.Name = "ContentWeightLabel";
            this.ContentWeightLabel.Size = new System.Drawing.Size(100, 13);
            this.ContentWeightLabel.TabIndex = 7;
            this.ContentWeightLabel.Text = "Weight of contents:";
            // 
            // ShipMaxWeightLabel
            // 
            this.ShipMaxWeightLabel.AutoSize = true;
            this.ShipMaxWeightLabel.Location = new System.Drawing.Point(6, 100);
            this.ShipMaxWeightLabel.Name = "ShipMaxWeightLabel";
            this.ShipMaxWeightLabel.Size = new System.Drawing.Size(199, 13);
            this.ShipMaxWeightLabel.TabIndex = 5;
            this.ShipMaxWeightLabel.Text = "Max Weight:                             Kilograms";
            // 
            // ShipMaxWeightNumericUpDown
            // 
            this.ShipMaxWeightNumericUpDown.Location = new System.Drawing.Point(74, 98);
            this.ShipMaxWeightNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.ShipMaxWeightNumericUpDown.Name = "ShipMaxWeightNumericUpDown";
            this.ShipMaxWeightNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.ShipMaxWeightNumericUpDown.TabIndex = 6;
            // 
            // ContainerTransportController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 794);
            this.Controls.Add(this.ShipBuilderBox);
            this.Controls.Add(this.ContainerPlacerBox);
            this.Name = "ContainerTransportController";
            this.Text = "Container Transport";
            this.Load += new System.EventHandler(this.ContainerTransportController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShipWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipLengthNumericUpDown)).EndInit();
            this.ShipBuilderBox.ResumeLayout(false);
            this.ShipBuilderBox.PerformLayout();
            this.ContainerPlacerBox.ResumeLayout(false);
            this.NewContainerGroupBox.ResumeLayout(false);
            this.NewContainerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipMaxWeightNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildShipButton;
        private System.Windows.Forms.Label ShipWidthLabel;
        private System.Windows.Forms.Label ShipLengthLabel;
        private System.Windows.Forms.NumericUpDown ShipWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown ShipLengthNumericUpDown;
        private System.Windows.Forms.Button PlaceContainerButton;
        private System.Windows.Forms.GroupBox ShipBuilderBox;
        private System.Windows.Forms.GroupBox ContainerPlacerBox;
        private System.Windows.Forms.Button AddContainerButton;
        private System.Windows.Forms.Label WeightLimitLabel;
        private System.Windows.Forms.Label ContentWeightLabel;
        private System.Windows.Forms.NumericUpDown WeightNumericUpDown;
        private System.Windows.Forms.GroupBox NewContainerGroupBox;
        private System.Windows.Forms.Label ContainerTypeLabel;
        private System.Windows.Forms.ComboBox ContainerTypeComboBox;
        private System.Windows.Forms.ListBox UnorderedContainersListbox;
        private System.Windows.Forms.Label AddResultLabel;
        private System.Windows.Forms.NumericUpDown ShipMaxWeightNumericUpDown;
        private System.Windows.Forms.Label ShipMaxWeightLabel;
    }
}

