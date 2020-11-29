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
            this.currentPageTotalPagesLabel = new System.Windows.Forms.Label();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.totalProductsFoundLabel = new System.Windows.Forms.Label();
            this.productsForPageLabel = new System.Windows.Forms.Label();
            this.productsForPageCombobox = new System.Windows.Forms.ComboBox();
            this.productsListView = new System.Windows.Forms.ListView();
            this.categoriesGroupBox = new System.Windows.Forms.GroupBox();
            this.subCatComboBox = new System.Windows.Forms.ComboBox();
            this.catComboBox = new System.Windows.Forms.ComboBox();
            this.subCatLabel = new System.Windows.Forms.Label();
            this.catLabel = new System.Windows.Forms.Label();
            this.avaliableLabel = new System.Windows.Forms.Label();
            this.avaliableCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maxPriceTextBox = new System.Windows.Forms.TextBox();
            this.minPriceTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.fraRadioButton = new System.Windows.Forms.RadioButton();
            this.engRadioButton = new System.Windows.Forms.RadioButton();
            this.languageLabel = new System.Windows.Forms.Label();
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.resetFilterButton = new System.Windows.Forms.Button();
            this.applyFilterButton = new System.Windows.Forms.Button();
            this.productLineComboBox = new System.Windows.Forms.ComboBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.produtctLineLabel = new System.Windows.Forms.Label();
            this.styleLabel = new System.Windows.Forms.Label();
            this.orderByGroupBox = new System.Windows.Forms.GroupBox();
            this.sellEndDateRadioButton = new System.Windows.Forms.RadioButton();
            this.lowPriceRadioButton = new System.Windows.Forms.RadioButton();
            this.orderByNameRadioButton = new System.Windows.Forms.RadioButton();
            this.searchGroupBox = new System.Windows.Forms.GroupBox();
            this.modelNamelRadioButton = new System.Windows.Forms.RadioButton();
            this.productNameRadioButton = new System.Windows.Forms.RadioButton();
            this.searchProductTextBox = new System.Windows.Forms.TextBox();
            this.searchProductButton = new System.Windows.Forms.Button();
            this.catalogGroupBox.SuspendLayout();
            this.categoriesGroupBox.SuspendLayout();
            this.filterGroupBox.SuspendLayout();
            this.orderByGroupBox.SuspendLayout();
            this.searchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // catalogGroupBox
            // 
            this.catalogGroupBox.Controls.Add(this.currentPageTotalPagesLabel);
            this.catalogGroupBox.Controls.Add(this.nextPageButton);
            this.catalogGroupBox.Controls.Add(this.previousPageButton);
            this.catalogGroupBox.Controls.Add(this.totalProductsFoundLabel);
            this.catalogGroupBox.Controls.Add(this.productsForPageLabel);
            this.catalogGroupBox.Controls.Add(this.productsForPageCombobox);
            this.catalogGroupBox.Controls.Add(this.productsListView);
            this.catalogGroupBox.Location = new System.Drawing.Point(24, 88);
            this.catalogGroupBox.Name = "catalogGroupBox";
            this.catalogGroupBox.Size = new System.Drawing.Size(907, 576);
            this.catalogGroupBox.TabIndex = 3;
            this.catalogGroupBox.TabStop = false;
            this.catalogGroupBox.Text = "Catalog";
            // 
            // currentPageTotalPagesLabel
            // 
            this.currentPageTotalPagesLabel.AutoSize = true;
            this.currentPageTotalPagesLabel.Location = new System.Drawing.Point(446, 520);
            this.currentPageTotalPagesLabel.Name = "currentPageTotalPagesLabel";
            this.currentPageTotalPagesLabel.Size = new System.Drawing.Size(0, 13);
            this.currentPageTotalPagesLabel.TabIndex = 6;
            // 
            // nextPageButton
            // 
            this.nextPageButton.Location = new System.Drawing.Point(557, 500);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(285, 53);
            this.nextPageButton.TabIndex = 3;
            this.nextPageButton.Text = "Next >";
            this.nextPageButton.UseVisualStyleBackColor = true;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // previousPageButton
            // 
            this.previousPageButton.Location = new System.Drawing.Point(58, 500);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(285, 53);
            this.previousPageButton.TabIndex = 2;
            this.previousPageButton.Text = "< Prev";
            this.previousPageButton.UseVisualStyleBackColor = true;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // totalProductsFoundLabel
            // 
            this.totalProductsFoundLabel.AutoSize = true;
            this.totalProductsFoundLabel.Location = new System.Drawing.Point(471, 28);
            this.totalProductsFoundLabel.Name = "totalProductsFoundLabel";
            this.totalProductsFoundLabel.Size = new System.Drawing.Size(0, 13);
            this.totalProductsFoundLabel.TabIndex = 3;
            // 
            // productsForPageLabel
            // 
            this.productsForPageLabel.AutoSize = true;
            this.productsForPageLabel.Location = new System.Drawing.Point(654, 23);
            this.productsForPageLabel.Name = "productsForPageLabel";
            this.productsForPageLabel.Size = new System.Drawing.Size(126, 13);
            this.productsForPageLabel.TabIndex = 2;
            this.productsForPageLabel.Text = "Shown products for page";
            // 
            // productsForPageCombobox
            // 
            this.productsForPageCombobox.FormattingEnabled = true;
            this.productsForPageCombobox.Items.AddRange(new object[] {
            "10",
            "20",
            "50"});
            this.productsForPageCombobox.Location = new System.Drawing.Point(786, 20);
            this.productsForPageCombobox.Name = "productsForPageCombobox";
            this.productsForPageCombobox.Size = new System.Drawing.Size(94, 21);
            this.productsForPageCombobox.TabIndex = 1;
            this.productsForPageCombobox.SelectedIndexChanged += new System.EventHandler(this.productsForPageCombobox_SelectedIndexChanged);
            // 
            // productsListView
            // 
            this.productsListView.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productsListView.HideSelection = false;
            this.productsListView.Location = new System.Drawing.Point(15, 55);
            this.productsListView.MultiSelect = false;
            this.productsListView.Name = "productsListView";
            this.productsListView.Size = new System.Drawing.Size(868, 424);
            this.productsListView.TabIndex = 0;
            this.productsListView.UseCompatibleStateImageBehavior = false;
            this.productsListView.View = System.Windows.Forms.View.List;
            this.productsListView.DoubleClick += new System.EventHandler(this.productsListView_DoubleClick);
            // 
            // categoriesGroupBox
            // 
            this.categoriesGroupBox.Controls.Add(this.subCatComboBox);
            this.categoriesGroupBox.Controls.Add(this.catComboBox);
            this.categoriesGroupBox.Controls.Add(this.subCatLabel);
            this.categoriesGroupBox.Controls.Add(this.catLabel);
            this.categoriesGroupBox.Controls.Add(this.avaliableLabel);
            this.categoriesGroupBox.Controls.Add(this.avaliableCheckBox);
            this.categoriesGroupBox.Location = new System.Drawing.Point(950, 88);
            this.categoriesGroupBox.Name = "categoriesGroupBox";
            this.categoriesGroupBox.Size = new System.Drawing.Size(295, 161);
            this.categoriesGroupBox.TabIndex = 1;
            this.categoriesGroupBox.TabStop = false;
            this.categoriesGroupBox.Text = "Categories";
            // 
            // subCatComboBox
            // 
            this.subCatComboBox.FormattingEnabled = true;
            this.subCatComboBox.Location = new System.Drawing.Point(162, 77);
            this.subCatComboBox.Name = "subCatComboBox";
            this.subCatComboBox.Size = new System.Drawing.Size(120, 21);
            this.subCatComboBox.TabIndex = 2;
            // 
            // catComboBox
            // 
            this.catComboBox.FormattingEnabled = true;
            this.catComboBox.Location = new System.Drawing.Point(162, 40);
            this.catComboBox.Name = "catComboBox";
            this.catComboBox.Size = new System.Drawing.Size(121, 21);
            this.catComboBox.TabIndex = 1;
            this.catComboBox.SelectedIndexChanged += new System.EventHandler(this.catComboBox_SelectedIndexChanged);
            // 
            // subCatLabel
            // 
            this.subCatLabel.AutoSize = true;
            this.subCatLabel.Location = new System.Drawing.Point(21, 77);
            this.subCatLabel.Name = "subCatLabel";
            this.subCatLabel.Size = new System.Drawing.Size(67, 13);
            this.subCatLabel.TabIndex = 1;
            this.subCatLabel.Text = "Subcategory";
            // 
            // catLabel
            // 
            this.catLabel.AutoSize = true;
            this.catLabel.Location = new System.Drawing.Point(21, 40);
            this.catLabel.Name = "catLabel";
            this.catLabel.Size = new System.Drawing.Size(49, 13);
            this.catLabel.TabIndex = 0;
            this.catLabel.Text = "Category";
            // 
            // avaliableLabel
            // 
            this.avaliableLabel.AutoSize = true;
            this.avaliableLabel.Location = new System.Drawing.Point(21, 114);
            this.avaliableLabel.Name = "avaliableLabel";
            this.avaliableLabel.Size = new System.Drawing.Size(95, 13);
            this.avaliableLabel.TabIndex = 11;
            this.avaliableLabel.Text = "Avaliable Products";
            // 
            // avaliableCheckBox
            // 
            this.avaliableCheckBox.AutoSize = true;
            this.avaliableCheckBox.Location = new System.Drawing.Point(214, 113);
            this.avaliableCheckBox.Name = "avaliableCheckBox";
            this.avaliableCheckBox.Size = new System.Drawing.Size(15, 14);
            this.avaliableCheckBox.TabIndex = 3;
            this.avaliableCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // maxPriceTextBox
            // 
            this.maxPriceTextBox.Location = new System.Drawing.Point(217, 142);
            this.maxPriceTextBox.Name = "maxPriceTextBox";
            this.maxPriceTextBox.Size = new System.Drawing.Size(53, 20);
            this.maxPriceTextBox.TabIndex = 8;
            this.maxPriceTextBox.Leave += new System.EventHandler(this.MaxTextBox_Leave);
            // 
            // minPriceTextBox
            // 
            this.minPriceTextBox.Location = new System.Drawing.Point(135, 142);
            this.minPriceTextBox.Name = "minPriceTextBox";
            this.minPriceTextBox.Size = new System.Drawing.Size(53, 20);
            this.minPriceTextBox.TabIndex = 7;
            this.minPriceTextBox.Leave += new System.EventHandler(this.minPriceTextBox_Leave);
            this.minPriceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.minPriceTextBox_Validating);
            this.minPriceTextBox.Validated += new System.EventHandler(this.minPriceTextBox_Validated);
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(36, 145);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price";
            // 
            // fraRadioButton
            // 
            this.fraRadioButton.AutoSize = true;
            this.fraRadioButton.Location = new System.Drawing.Point(1164, 44);
            this.fraRadioButton.Name = "fraRadioButton";
            this.fraRadioButton.Size = new System.Drawing.Size(65, 17);
            this.fraRadioButton.TabIndex = 5;
            this.fraRadioButton.Text = "Francais";
            this.fraRadioButton.UseVisualStyleBackColor = true;
            this.fraRadioButton.CheckedChanged += new System.EventHandler(this.fraRadioButton_CheckedChanged);
            // 
            // engRadioButton
            // 
            this.engRadioButton.AutoSize = true;
            this.engRadioButton.Checked = true;
            this.engRadioButton.Location = new System.Drawing.Point(1070, 44);
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
            this.languageLabel.Location = new System.Drawing.Point(985, 47);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 3;
            this.languageLabel.Text = "Language";
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.colorComboBox);
            this.filterGroupBox.Controls.Add(this.colorLabel);
            this.filterGroupBox.Controls.Add(this.resetFilterButton);
            this.filterGroupBox.Controls.Add(this.applyFilterButton);
            this.filterGroupBox.Controls.Add(this.productLineComboBox);
            this.filterGroupBox.Controls.Add(this.styleComboBox);
            this.filterGroupBox.Controls.Add(this.produtctLineLabel);
            this.filterGroupBox.Controls.Add(this.styleLabel);
            this.filterGroupBox.Controls.Add(this.label1);
            this.filterGroupBox.Controls.Add(this.maxPriceTextBox);
            this.filterGroupBox.Controls.Add(this.minPriceTextBox);
            this.filterGroupBox.Controls.Add(this.priceLabel);
            this.filterGroupBox.Location = new System.Drawing.Point(953, 262);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(292, 242);
            this.filterGroupBox.TabIndex = 2;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Filters";
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(135, 30);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(135, 21);
            this.colorComboBox.TabIndex = 4;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(36, 35);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 20;
            this.colorLabel.Text = "Color";
            // 
            // resetFilterButton
            // 
            this.resetFilterButton.Location = new System.Drawing.Point(175, 187);
            this.resetFilterButton.Name = "resetFilterButton";
            this.resetFilterButton.Size = new System.Drawing.Size(84, 37);
            this.resetFilterButton.TabIndex = 14;
            this.resetFilterButton.Text = "Reset filters";
            this.resetFilterButton.UseVisualStyleBackColor = true;
            this.resetFilterButton.Click += new System.EventHandler(this.resetFilterButton_Click);
            // 
            // applyFilterButton
            // 
            this.applyFilterButton.Location = new System.Drawing.Point(37, 186);
            this.applyFilterButton.Name = "applyFilterButton";
            this.applyFilterButton.Size = new System.Drawing.Size(84, 37);
            this.applyFilterButton.TabIndex = 9;
            this.applyFilterButton.Text = "Apply";
            this.applyFilterButton.UseVisualStyleBackColor = true;
            this.applyFilterButton.Click += new System.EventHandler(this.applyFilterButton_Click);
            // 
            // productLineComboBox
            // 
            this.productLineComboBox.FormattingEnabled = true;
            this.productLineComboBox.Location = new System.Drawing.Point(135, 101);
            this.productLineComboBox.Name = "productLineComboBox";
            this.productLineComboBox.Size = new System.Drawing.Size(135, 21);
            this.productLineComboBox.TabIndex = 6;
            // 
            // styleComboBox
            // 
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(135, 65);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(135, 21);
            this.styleComboBox.TabIndex = 5;
            // 
            // produtctLineLabel
            // 
            this.produtctLineLabel.AutoSize = true;
            this.produtctLineLabel.Location = new System.Drawing.Point(36, 109);
            this.produtctLineLabel.Name = "produtctLineLabel";
            this.produtctLineLabel.Size = new System.Drawing.Size(67, 13);
            this.produtctLineLabel.TabIndex = 14;
            this.produtctLineLabel.Text = "Product Line";
            // 
            // styleLabel
            // 
            this.styleLabel.AutoSize = true;
            this.styleLabel.Location = new System.Drawing.Point(36, 73);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(30, 13);
            this.styleLabel.TabIndex = 13;
            this.styleLabel.Text = "Style";
            // 
            // orderByGroupBox
            // 
            this.orderByGroupBox.Controls.Add(this.sellEndDateRadioButton);
            this.orderByGroupBox.Controls.Add(this.lowPriceRadioButton);
            this.orderByGroupBox.Controls.Add(this.orderByNameRadioButton);
            this.orderByGroupBox.Location = new System.Drawing.Point(960, 520);
            this.orderByGroupBox.Name = "orderByGroupBox";
            this.orderByGroupBox.Size = new System.Drawing.Size(285, 144);
            this.orderByGroupBox.TabIndex = 10;
            this.orderByGroupBox.TabStop = false;
            this.orderByGroupBox.Text = "Order by";
            // 
            // sellEndDateRadioButton
            // 
            this.sellEndDateRadioButton.AutoSize = true;
            this.sellEndDateRadioButton.Location = new System.Drawing.Point(97, 111);
            this.sellEndDateRadioButton.Name = "sellEndDateRadioButton";
            this.sellEndDateRadioButton.Size = new System.Drawing.Size(139, 17);
            this.sellEndDateRadioButton.TabIndex = 13;
            this.sellEndDateRadioButton.Text = "Sell end date ascending";
            this.sellEndDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // lowPriceRadioButton
            // 
            this.lowPriceRadioButton.AutoSize = true;
            this.lowPriceRadioButton.Location = new System.Drawing.Point(97, 68);
            this.lowPriceRadioButton.Name = "lowPriceRadioButton";
            this.lowPriceRadioButton.Size = new System.Drawing.Size(136, 17);
            this.lowPriceRadioButton.TabIndex = 12;
            this.lowPriceRadioButton.Text = "Low Price ... High Price";
            this.lowPriceRadioButton.UseVisualStyleBackColor = true;
            // 
            // orderByNameRadioButton
            // 
            this.orderByNameRadioButton.AutoSize = true;
            this.orderByNameRadioButton.Checked = true;
            this.orderByNameRadioButton.Location = new System.Drawing.Point(97, 30);
            this.orderByNameRadioButton.Name = "orderByNameRadioButton";
            this.orderByNameRadioButton.Size = new System.Drawing.Size(73, 17);
            this.orderByNameRadioButton.TabIndex = 11;
            this.orderByNameRadioButton.TabStop = true;
            this.orderByNameRadioButton.Text = "Name A-Z";
            this.orderByNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchGroupBox
            // 
            this.searchGroupBox.Controls.Add(this.modelNamelRadioButton);
            this.searchGroupBox.Controls.Add(this.productNameRadioButton);
            this.searchGroupBox.Controls.Add(this.searchProductTextBox);
            this.searchGroupBox.Controls.Add(this.searchProductButton);
            this.searchGroupBox.Location = new System.Drawing.Point(24, 19);
            this.searchGroupBox.Name = "searchGroupBox";
            this.searchGroupBox.Size = new System.Drawing.Size(907, 63);
            this.searchGroupBox.TabIndex = 4;
            this.searchGroupBox.TabStop = false;
            this.searchGroupBox.Text = "Search";
            // 
            // modelNamelRadioButton
            // 
            this.modelNamelRadioButton.AutoSize = true;
            this.modelNamelRadioButton.Checked = true;
            this.modelNamelRadioButton.Location = new System.Drawing.Point(179, 29);
            this.modelNamelRadioButton.Name = "modelNamelRadioButton";
            this.modelNamelRadioButton.Size = new System.Drawing.Size(85, 17);
            this.modelNamelRadioButton.TabIndex = 2;
            this.modelNamelRadioButton.TabStop = true;
            this.modelNamelRadioButton.Text = "Model Name";
            this.modelNamelRadioButton.UseVisualStyleBackColor = true;
            // 
            // productNameRadioButton
            // 
            this.productNameRadioButton.AutoSize = true;
            this.productNameRadioButton.Location = new System.Drawing.Point(23, 30);
            this.productNameRadioButton.Name = "productNameRadioButton";
            this.productNameRadioButton.Size = new System.Drawing.Size(93, 17);
            this.productNameRadioButton.TabIndex = 1;
            this.productNameRadioButton.Text = "Product Name";
            this.productNameRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchProductTextBox
            // 
            this.searchProductTextBox.Location = new System.Drawing.Point(366, 25);
            this.searchProductTextBox.Name = "searchProductTextBox";
            this.searchProductTextBox.Size = new System.Drawing.Size(206, 20);
            this.searchProductTextBox.TabIndex = 3;
            this.searchProductTextBox.TextChanged += new System.EventHandler(this.searchProductTextBox_TextChanged);
            // 
            // searchProductButton
            // 
            this.searchProductButton.Location = new System.Drawing.Point(657, 19);
            this.searchProductButton.Name = "searchProductButton";
            this.searchProductButton.Size = new System.Drawing.Size(185, 38);
            this.searchProductButton.TabIndex = 4;
            this.searchProductButton.Text = "Search it";
            this.searchProductButton.UseVisualStyleBackColor = true;
            this.searchProductButton.Click += new System.EventHandler(this.searchProductButton_Click);
            // 
            // browserProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 689);
            this.Controls.Add(this.searchGroupBox);
            this.Controls.Add(this.orderByGroupBox);
            this.Controls.Add(this.filterGroupBox);
            this.Controls.Add(this.fraRadioButton);
            this.Controls.Add(this.engRadioButton);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.categoriesGroupBox);
            this.Controls.Add(this.catalogGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "browserProducts";
            this.Text = "Products Catalog";
            this.Load += new System.EventHandler(this.browserProducts_Load);
            this.catalogGroupBox.ResumeLayout(false);
            this.catalogGroupBox.PerformLayout();
            this.categoriesGroupBox.ResumeLayout(false);
            this.categoriesGroupBox.PerformLayout();
            this.filterGroupBox.ResumeLayout(false);
            this.filterGroupBox.PerformLayout();
            this.orderByGroupBox.ResumeLayout(false);
            this.orderByGroupBox.PerformLayout();
            this.searchGroupBox.ResumeLayout(false);
            this.searchGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox catalogGroupBox;
        private System.Windows.Forms.GroupBox categoriesGroupBox;
        private System.Windows.Forms.ComboBox subCatComboBox;
        private System.Windows.Forms.ComboBox catComboBox;
        private System.Windows.Forms.Label subCatLabel;
        private System.Windows.Forms.Label catLabel;
        private System.Windows.Forms.RadioButton fraRadioButton;
        private System.Windows.Forms.RadioButton engRadioButton;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox maxPriceTextBox;
        private System.Windows.Forms.TextBox minPriceTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.ListView productsListView;
        private System.Windows.Forms.Label currentPageTotalPagesLabel;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Label totalProductsFoundLabel;
        private System.Windows.Forms.Label productsForPageLabel;
        private System.Windows.Forms.ComboBox productsForPageCombobox;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.Button resetFilterButton;
        private System.Windows.Forms.Button applyFilterButton;
        private System.Windows.Forms.ComboBox productLineComboBox;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label produtctLineLabel;
        private System.Windows.Forms.Label styleLabel;
        private System.Windows.Forms.Label avaliableLabel;
        private System.Windows.Forms.CheckBox avaliableCheckBox;
        private System.Windows.Forms.GroupBox orderByGroupBox;
        private System.Windows.Forms.RadioButton sellEndDateRadioButton;
        private System.Windows.Forms.RadioButton lowPriceRadioButton;
        private System.Windows.Forms.RadioButton orderByNameRadioButton;
        private System.Windows.Forms.GroupBox searchGroupBox;
        private System.Windows.Forms.RadioButton modelNamelRadioButton;
        private System.Windows.Forms.RadioButton productNameRadioButton;
        private System.Windows.Forms.TextBox searchProductTextBox;
        private System.Windows.Forms.Button searchProductButton;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label colorLabel;
    }
}

