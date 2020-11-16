namespace BrowserProducts
{
    partial class browserProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.catalogGroupBox = new System.Windows.Forms.GroupBox();
            this.productsDataGridView = new System.Windows.Forms.DataGridView();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.subCatComboBox = new System.Windows.Forms.ComboBox();
            this.catComboBox = new System.Windows.Forms.ComboBox();
            this.subCatLabel = new System.Windows.Forms.Label();
            this.catLabel = new System.Windows.Forms.Label();
            this.fraRadioButton = new System.Windows.Forms.RadioButton();
            this.engRadioButton = new System.Windows.Forms.RadioButton();
            this.languageLabel = new System.Windows.Forms.Label();
            this.catalogGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).BeginInit();
            this.filterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // catalogGroupBox
            // 
            this.catalogGroupBox.Controls.Add(this.productsDataGridView);
            this.catalogGroupBox.Location = new System.Drawing.Point(12, 12);
            this.catalogGroupBox.Name = "catalogGroupBox";
            this.catalogGroupBox.Size = new System.Drawing.Size(511, 476);
            this.catalogGroupBox.TabIndex = 0;
            this.catalogGroupBox.TabStop = false;
            this.catalogGroupBox.Text = "Catalog";
            // 
            // productsDataGridView
            // 
            this.productsDataGridView.AllowUserToAddRows = false;
            this.productsDataGridView.AllowUserToDeleteRows = false;
            this.productsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.productsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.productsDataGridView.Name = "productsDataGridView";
            this.productsDataGridView.ReadOnly = true;
            this.productsDataGridView.RowHeadersWidth = 50;
            this.productsDataGridView.Size = new System.Drawing.Size(505, 457);
            this.productsDataGridView.TabIndex = 0;
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.label1);
            this.filterGroupBox.Controls.Add(this.textBox2);
            this.filterGroupBox.Controls.Add(this.textBox1);
            this.filterGroupBox.Controls.Add(this.priceLabel);
            this.filterGroupBox.Controls.Add(this.subCatComboBox);
            this.filterGroupBox.Controls.Add(this.catComboBox);
            this.filterGroupBox.Controls.Add(this.subCatLabel);
            this.filterGroupBox.Controls.Add(this.catLabel);
            this.filterGroupBox.Location = new System.Drawing.Point(570, 100);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(295, 387);
            this.filterGroupBox.TabIndex = 1;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filters";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(215, 63);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(61, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 5;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(15, 62);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price";
            // 
            // subCatComboBox
            // 
            this.subCatComboBox.FormattingEnabled = true;
            this.subCatComboBox.Location = new System.Drawing.Point(156, 137);
            this.subCatComboBox.Name = "subCatComboBox";
            this.subCatComboBox.Size = new System.Drawing.Size(120, 21);
            this.subCatComboBox.TabIndex = 3;
            // 
            // catComboBox
            // 
            this.catComboBox.FormattingEnabled = true;
            this.catComboBox.Location = new System.Drawing.Point(156, 100);
            this.catComboBox.Name = "catComboBox";
            this.catComboBox.Size = new System.Drawing.Size(121, 21);
            this.catComboBox.TabIndex = 2;
            // 
            // subCatLabel
            // 
            this.subCatLabel.AutoSize = true;
            this.subCatLabel.Location = new System.Drawing.Point(15, 141);
            this.subCatLabel.Name = "subCatLabel";
            this.subCatLabel.Size = new System.Drawing.Size(67, 13);
            this.subCatLabel.TabIndex = 1;
            this.subCatLabel.Text = "Subcategory";
            // 
            // catLabel
            // 
            this.catLabel.AutoSize = true;
            this.catLabel.Location = new System.Drawing.Point(15, 100);
            this.catLabel.Name = "catLabel";
            this.catLabel.Size = new System.Drawing.Size(49, 13);
            this.catLabel.TabIndex = 0;
            this.catLabel.Text = "Category";
            // 
            // fraRadioButton
            // 
            this.fraRadioButton.AutoSize = true;
            this.fraRadioButton.Location = new System.Drawing.Point(763, 36);
            this.fraRadioButton.Name = "fraRadioButton";
            this.fraRadioButton.Size = new System.Drawing.Size(65, 17);
            this.fraRadioButton.TabIndex = 5;
            this.fraRadioButton.TabStop = true;
            this.fraRadioButton.Text = "Francais";
            this.fraRadioButton.UseVisualStyleBackColor = true;
            this.fraRadioButton.CheckedChanged += new System.EventHandler(this.fraRadioButton_CheckedChanged);
            // 
            // engRadioButton
            // 
            this.engRadioButton.AutoSize = true;
            this.engRadioButton.Location = new System.Drawing.Point(671, 38);
            this.engRadioButton.Name = "engRadioButton";
            this.engRadioButton.Size = new System.Drawing.Size(59, 17);
            this.engRadioButton.TabIndex = 4;
            this.engRadioButton.TabStop = true;
            this.engRadioButton.Text = "English";
            this.engRadioButton.UseVisualStyleBackColor = true;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(585, 40);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 3;
            this.languageLabel.Text = "Language";
            // 
            // browserProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 500);
            this.Controls.Add(this.fraRadioButton);
            this.Controls.Add(this.engRadioButton);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.catalogGroupBox);
            this.Name = "browserProducts";
            this.Text = "Products Catalog";
            this.Load += new System.EventHandler(this.browserProducts_Load);
            this.catalogGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productsDataGridView)).EndInit();
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox catalogGroupBox;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.ComboBox subCatComboBox;
        private System.Windows.Forms.ComboBox catComboBox;
        private System.Windows.Forms.Label subCatLabel;
        private System.Windows.Forms.Label catLabel;
        private System.Windows.Forms.RadioButton fraRadioButton;
        private System.Windows.Forms.RadioButton engRadioButton;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.DataGridView productsDataGridView;
    }
}

