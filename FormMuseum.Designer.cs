namespace ProjectMuseum
{
    partial class FormMuseum
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMuseum));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.textmuseumname = new System.Windows.Forms.TextBox();
            this.textmuseumstreet = new System.Windows.Forms.TextBox();
            this.combomuseumcity = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.textnumberbranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelet = new System.Windows.Forms.Button();
            this.textBoxSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.reflectionImage1 = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridMuseum = new System.Windows.Forms.DataGridView();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.masdatestablishment = new System.Windows.Forms.MaskedTextBox();
            this.textstarthoursework = new System.Windows.Forms.MaskedTextBox();
            this.textendhoursework = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMuseum)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // textmuseumname
            // 
            this.textmuseumname.Location = new System.Drawing.Point(140, 19);
            this.textmuseumname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textmuseumname.Name = "textmuseumname";
            this.textmuseumname.Size = new System.Drawing.Size(147, 27);
            this.textmuseumname.TabIndex = 0;
            // 
            // textmuseumstreet
            // 
            this.textmuseumstreet.Location = new System.Drawing.Point(511, 68);
            this.textmuseumstreet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textmuseumstreet.Name = "textmuseumstreet";
            this.textmuseumstreet.Size = new System.Drawing.Size(147, 27);
            this.textmuseumstreet.TabIndex = 4;
            // 
            // combomuseumcity
            // 
            this.combomuseumcity.DisplayMember = "Text";
            this.combomuseumcity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combomuseumcity.ForeColor = System.Drawing.Color.Black;
            this.combomuseumcity.FormattingEnabled = true;
            this.combomuseumcity.ItemHeight = 22;
            this.combomuseumcity.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7,
            this.comboItem8});
            this.combomuseumcity.Location = new System.Drawing.Point(140, 68);
            this.combomuseumcity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combomuseumcity.Name = "combomuseumcity";
            this.combomuseumcity.Size = new System.Drawing.Size(147, 28);
            this.combomuseumcity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combomuseumcity.TabIndex = 3;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "تهران";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "قم";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "مشهد";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "یزد";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "اراک";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "قزوین";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "کرمان";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "کرج";
            // 
            // textnumberbranch
            // 
            this.textnumberbranch.Location = new System.Drawing.Point(511, 19);
            this.textnumberbranch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textnumberbranch.Name = "textnumberbranch";
            this.textnumberbranch.Size = new System.Drawing.Size(147, 27);
            this.textnumberbranch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "MusumeName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "BranchNumber:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "DateEstablishment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "MuseumCity:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "MusumStreet:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(746, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "StarthourseWork:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(746, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "EndhourseWork:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(664, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "*";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(148, 2);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 66);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelet
            // 
            this.btnDelet.Image = ((System.Drawing.Image)(resources.GetObject("btnDelet.Image")));
            this.btnDelet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelet.Location = new System.Drawing.Point(274, 2);
            this.btnDelet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.Size = new System.Drawing.Size(110, 66);
            this.btnDelet.TabIndex = 2;
            this.btnDelet.Text = "Delete";
            this.btnDelet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelet.UseVisualStyleBackColor = true;
            this.btnDelet.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxSearch.Border.Class = "TextBoxBorder";
            this.textBoxSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxSearch.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxSearch.ForeColor = System.Drawing.Color.Black;
            this.textBoxSearch.Location = new System.Drawing.Point(469, 19);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.PreventEnterBeep = true;
            this.textBoxSearch.Size = new System.Drawing.Size(243, 27);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.WatermarkText = "Enter BranchNumber . . . ";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.Location = new System.Drawing.Point(1015, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 66);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.reflectionImage1);
            this.groupPanel2.Controls.Add(this.btnSave);
            this.groupPanel2.Controls.Add(this.btnExit);
            this.groupPanel2.Controls.Add(this.textBoxSearch);
            this.groupPanel2.Controls.Add(this.btnDelet);
            this.groupPanel2.Controls.Add(this.btnEdit);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(11, 177);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1141, 95);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            // 
            // reflectionImage1
            // 
            // 
            // 
            // 
            this.reflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reflectionImage1.Image = ((System.Drawing.Image)(resources.GetObject("reflectionImage1.Image")));
            this.reflectionImage1.Location = new System.Drawing.Point(684, 19);
            this.reflectionImage1.Name = "reflectionImage1";
            this.reflectionImage1.Size = new System.Drawing.Size(28, 27);
            this.reflectionImage1.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(22, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 66);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // dataGridMuseum
            // 
            this.dataGridMuseum.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.dataGridMuseum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMuseum.Location = new System.Drawing.Point(11, 277);
            this.dataGridMuseum.Name = "dataGridMuseum";
            this.dataGridMuseum.RowHeadersWidth = 51;
            this.dataGridMuseum.RowTemplate.Height = 24;
            this.dataGridMuseum.Size = new System.Drawing.Size(1141, 271);
            this.dataGridMuseum.TabIndex = 7;
            this.dataGridMuseum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGridMuseum_MouseUp);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.OfficeMobile2014;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(117)))), ((int)(((byte)(104))))));
            // 
            // masdatestablishment
            // 
            this.masdatestablishment.Location = new System.Drawing.Point(186, 129);
            this.masdatestablishment.Mask = "0000/00/00";
            this.masdatestablishment.Name = "masdatestablishment";
            this.masdatestablishment.Size = new System.Drawing.Size(169, 27);
            this.masdatestablishment.TabIndex = 18;
            this.masdatestablishment.ValidatingType = typeof(System.DateTime);
            // 
            // textstarthoursework
            // 
            this.textstarthoursework.Location = new System.Drawing.Point(892, 19);
            this.textstarthoursework.Mask = "00:00:00";
            this.textstarthoursework.Name = "textstarthoursework";
            this.textstarthoursework.Size = new System.Drawing.Size(147, 27);
            this.textstarthoursework.TabIndex = 19;
            this.textstarthoursework.ValidatingType = typeof(System.DateTime);
            // 
            // textendhoursework
            // 
            this.textendhoursework.Location = new System.Drawing.Point(892, 68);
            this.textendhoursework.Mask = "00:00:00";
            this.textendhoursework.Name = "textendhoursework";
            this.textendhoursework.Size = new System.Drawing.Size(147, 27);
            this.textendhoursework.TabIndex = 20;
            this.textendhoursework.ValidatingType = typeof(System.DateTime);
            // 
            // FormMuseum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 549);
            this.Controls.Add(this.textendhoursework);
            this.Controls.Add(this.textstarthoursework);
            this.Controls.Add(this.masdatestablishment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridMuseum);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textmuseumname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textmuseumstreet);
            this.Controls.Add(this.textnumberbranch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combomuseumcity);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormMuseum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMuseum";
            this.Load += new System.EventHandler(this.FormMuseum_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMuseum_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMuseum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Button btnExit;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxSearch;
        private System.Windows.Forms.Button btnDelet;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textnumberbranch;
        private DevComponents.DotNetBar.Controls.ComboBoxEx combomuseumcity;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private System.Windows.Forms.TextBox textmuseumstreet;
        private System.Windows.Forms.TextBox textmuseumname;
        private System.Windows.Forms.Button btnSave;
        private DevComponents.DotNetBar.Controls.ReflectionImage reflectionImage1;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.MaskedTextBox textstarthoursework;
        private System.Windows.Forms.MaskedTextBox textendhoursework;
        public System.Windows.Forms.MaskedTextBox masdatestablishment;
        public System.Windows.Forms.DataGridView dataGridMuseum;
    }
}