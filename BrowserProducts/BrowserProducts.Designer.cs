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
            this.catalogGroupBox = new System.Windows.Forms.GroupBox();
            this.productsListView = new System.Windows.Forms.ListView();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.avaliableLabel = new System.Windows.Forms.Label();
            this.avaliableCheckBox = new System.Windows.Forms.CheckBox();
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
            this.filterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // catalogGroupBox
            // 
            this.catalogGroupBox.Controls.Add(this.productsListView);
            this.catalogGroupBox.Location = new System.Drawing.Point(24, 88);
            this.catalogGroupBox.Name = "catalogGroupBox";
            this.catalogGroupBox.Size = new System.Drawing.Size(810, 630);
            this.catalogGroupBox.TabIndex = 0;
            this.catalogGroupBox.TabStop = false;
            this.catalogGroupBox.Text = "Catalog";
            // 
            // productsListView
            // 
            this.productsListView.HideSelection = false;
            this.productsListView.Location = new System.Drawing.Point(6, 19);
            this.productsListView.Name = "productsListView";
            this.productsListView.Size = new System.Drawing.Size(775, 593);
            this.productsListView.TabIndex = 0;
            this.productsListView.UseCompatibleStateImageBehavior = false;
            this.productsListView.View = System.Windows.Forms.View.List;
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.avaliableLabel);
            this.filterGroupBox.Controls.Add(this.avaliableCheckBox);
            this.filterGroupBox.Controls.Add(this.label1);
            this.filterGroupBox.Controls.Add(this.textBox2);
            this.filterGroupBox.Controls.Add(this.textBox1);
            this.filterGroupBox.Controls.Add(this.priceLabel);
            this.filterGroupBox.Controls.Add(this.subCatComboBox);
            this.filterGroupBox.Controls.Add(this.catComboBox);
            this.filterGroupBox.Controls.Add(this.subCatLabel);
            this.filterGroupBox.Controls.Add(this.catLabel);
            this.filterGroupBox.Location = new System.Drawing.Point(850, 88);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(295, 387);
            this.filterGroupBox.TabIndex = 1;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filters";
            // 
            // avaliableLabel
            // 
            this.avaliableLabel.AutoSize = true;
            this.avaliableLabel.Location = new System.Drawing.Point(15, 36);
            this.avaliableLabel.Name = "avaliableLabel";
            this.avaliableLabel.Size = new System.Drawing.Size(95, 13);
            this.avaliableLabel.TabIndex = 9;
            this.avaliableLabel.Text = "Avaliable Products";
            // 
            // avaliableCheckBox
            // 
            this.avaliableCheckBox.AutoSize = true;
            this.avaliableCheckBox.Location = new System.Drawing.Point(202, 36);
            this.avaliableCheckBox.Name = "avaliableCheckBox";
            this.avaliableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.avaliableCheckBox.TabIndex = 8;
            this.avaliableCheckBox.UseVisualStyleBackColor = true;
            this.avaliableCheckBox.CheckedChanged += new System.EventHandler(this.avaliableCheckBox_CheckedChanged);
            this.avaliableCheckBox.CheckStateChanged += new System.EventHandler(this.avaliableCheckBox_CheckStateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(215, 341);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(61, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 341);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(62, 20);
            this.textBox1.TabIndex = 5;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(20, 344);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price";
            // 
            // subCatComboBox
            // 
            this.subCatComboBox.FormattingEnabled = true;
            this.subCatComboBox.Location = new System.Drawing.Point(156, 115);
            this.subCatComboBox.Name = "subCatComboBox";
            this.subCatComboBox.Size = new System.Drawing.Size(120, 21);
            this.subCatComboBox.TabIndex = 3;
            this.subCatComboBox.SelectedIndexChanged += new System.EventHandler(this.subCatComboBox_SelectedIndexChanged);
            // 
            // catComboBox
            // 
            this.catComboBox.FormattingEnabled = true;
            this.catComboBox.Location = new System.Drawing.Point(156, 78);
            this.catComboBox.Name = "catComboBox";
            this.catComboBox.Size = new System.Drawing.Size(121, 21);
            this.catComboBox.TabIndex = 2;
            this.catComboBox.SelectedIndexChanged += new System.EventHandler(this.catComboBox_SelectedIndexChanged);
            // 
            // subCatLabel
            // 
            this.subCatLabel.AutoSize = true;
            this.subCatLabel.Location = new System.Drawing.Point(15, 115);
            this.subCatLabel.Name = "subCatLabel";
            this.subCatLabel.Size = new System.Drawing.Size(67, 13);
            this.subCatLabel.TabIndex = 1;
            this.subCatLabel.Text = "Subcategory";
            // 
            // catLabel
            // 
            this.catLabel.AutoSize = true;
            this.catLabel.Location = new System.Drawing.Point(15, 78);
            this.catLabel.Name = "catLabel";
            this.catLabel.Size = new System.Drawing.Size(49, 13);
            this.catLabel.TabIndex = 0;
            this.catLabel.Text = "Category";
            // 
            // fraRadioButton
            // 
            this.fraRadioButton.AutoSize = true;
            this.fraRadioButton.Location = new System.Drawing.Point(1043, 24);
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
            this.engRadioButton.Location = new System.Drawing.Point(951, 26);
            this.engRadioButton.Name = "engRadioButton";
            this.engRadioButton.Size = new System.Drawing.Size(59, 17);
            this.engRadioButton.TabIndex = 4;
            this.engRadioButton.TabStop = true;
            this.engRadioButton.Text = "English";
            this.engRadioButton.UseVisualStyleBackColor = true;
            this.engRadioButton.CheckedChanged += new System.EventHandler(this.engRadioButton_CheckedChanged);
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(865, 28);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 3;
            this.languageLabel.Text = "Language";
            // 
            // browserProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 740);
            this.Controls.Add(this.fraRadioButton);
            this.Controls.Add(this.engRadioButton);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.catalogGroupBox);
            this.Name = "browserProducts";
            this.Text = "Products Catalog";
            this.Load += new System.EventHandler(this.browserProducts_Load);
            this.catalogGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.ListView productsListView;
        private System.Windows.Forms.Label avaliableLabel;
        private System.Windows.Forms.CheckBox avaliableCheckBox;
    }
}

