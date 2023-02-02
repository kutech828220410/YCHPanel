namespace YCHPanel
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_IPA = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_IPB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_IPC = new System.Windows.Forms.TextBox();
            this.textBox_IPD = new System.Windows.Forms.TextBox();
            this.button_ConnectTest = new System.Windows.Forms.Button();
            this.numericUpDown_V_Line_index = new System.Windows.Forms.NumericUpDown();
            this.button_V_Line_Show = new System.Windows.Forms.Button();
            this.numericUpDown_H_Line_index = new System.Windows.Forms.NumericUpDown();
            this.button_H_Line_Show = new System.Windows.Forms.Button();
            this.button_Drawer_Clear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_Drawer_PointX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_Drawer_PointY = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_Drawer_Width = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Drawer_Height = new System.Windows.Forms.NumericUpDown();
            this.button_Drawer_ShowBox = new System.Windows.Forms.Button();
            this.radioButton_Drawer_紅 = new System.Windows.Forms.RadioButton();
            this.radioButton_Drawer_藍 = new System.Windows.Forms.RadioButton();
            this.radioButton_Drawer_綠 = new System.Windows.Forms.RadioButton();
            this.radioButton_Drawer_黃 = new System.Windows.Forms.RadioButton();
            this.radioButton_Drawer_白 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_V_Line_index)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_H_Line_index)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_PointX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_PointY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_Width)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_Height)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_IPA
            // 
            this.textBox_IPA.Location = new System.Drawing.Point(3, 6);
            this.textBox_IPA.Name = "textBox_IPA";
            this.textBox_IPA.Size = new System.Drawing.Size(54, 22);
            this.textBox_IPA.TabIndex = 0;
            this.textBox_IPA.Text = "192";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_IPD);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBox_IPC);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_IPB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_IPA);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 35);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = ".";
            // 
            // textBox_IPB
            // 
            this.textBox_IPB.Location = new System.Drawing.Point(77, 6);
            this.textBox_IPB.Name = "textBox_IPB";
            this.textBox_IPB.Size = new System.Drawing.Size(54, 22);
            this.textBox_IPB.TabIndex = 3;
            this.textBox_IPB.Text = "168";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = ".";
            // 
            // textBox_IPC
            // 
            this.textBox_IPC.Location = new System.Drawing.Point(151, 6);
            this.textBox_IPC.Name = "textBox_IPC";
            this.textBox_IPC.Size = new System.Drawing.Size(54, 22);
            this.textBox_IPC.TabIndex = 5;
            this.textBox_IPC.Text = "43";
            // 
            // textBox_IPD
            // 
            this.textBox_IPD.Location = new System.Drawing.Point(225, 6);
            this.textBox_IPD.Name = "textBox_IPD";
            this.textBox_IPD.Size = new System.Drawing.Size(54, 22);
            this.textBox_IPD.TabIndex = 7;
            this.textBox_IPD.Text = "180";
            // 
            // button_ConnectTest
            // 
            this.button_ConnectTest.Location = new System.Drawing.Point(307, 12);
            this.button_ConnectTest.Name = "button_ConnectTest";
            this.button_ConnectTest.Size = new System.Drawing.Size(133, 35);
            this.button_ConnectTest.TabIndex = 2;
            this.button_ConnectTest.Text = "ConnectTest";
            this.button_ConnectTest.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_V_Line_index
            // 
            this.numericUpDown_V_Line_index.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_V_Line_index.Location = new System.Drawing.Point(137, 10);
            this.numericUpDown_V_Line_index.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_V_Line_index.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_V_Line_index.Name = "numericUpDown_V_Line_index";
            this.numericUpDown_V_Line_index.Size = new System.Drawing.Size(57, 29);
            this.numericUpDown_V_Line_index.TabIndex = 4;
            this.numericUpDown_V_Line_index.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_V_Line_Show
            // 
            this.button_V_Line_Show.Location = new System.Drawing.Point(214, 7);
            this.button_V_Line_Show.Name = "button_V_Line_Show";
            this.button_V_Line_Show.Size = new System.Drawing.Size(98, 35);
            this.button_V_Line_Show.TabIndex = 5;
            this.button_V_Line_Show.Text = "Show";
            this.button_V_Line_Show.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_H_Line_index
            // 
            this.numericUpDown_H_Line_index.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_H_Line_index.Location = new System.Drawing.Point(137, 49);
            this.numericUpDown_H_Line_index.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_H_Line_index.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_H_Line_index.Name = "numericUpDown_H_Line_index";
            this.numericUpDown_H_Line_index.Size = new System.Drawing.Size(57, 29);
            this.numericUpDown_H_Line_index.TabIndex = 6;
            this.numericUpDown_H_Line_index.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_H_Line_Show
            // 
            this.button_H_Line_Show.Location = new System.Drawing.Point(214, 46);
            this.button_H_Line_Show.Name = "button_H_Line_Show";
            this.button_H_Line_Show.Size = new System.Drawing.Size(98, 35);
            this.button_H_Line_Show.TabIndex = 7;
            this.button_H_Line_Show.Text = "Show";
            this.button_H_Line_Show.UseVisualStyleBackColor = true;
            // 
            // button_Drawer_Clear
            // 
            this.button_Drawer_Clear.Location = new System.Drawing.Point(318, 179);
            this.button_Drawer_Clear.Name = "button_Drawer_Clear";
            this.button_Drawer_Clear.Size = new System.Drawing.Size(98, 35);
            this.button_Drawer_Clear.TabIndex = 8;
            this.button_Drawer_Clear.Text = "Clear";
            this.button_Drawer_Clear.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(5, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Row index        : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(5, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Column index : ";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.radioButton_Drawer_白);
            this.panel2.Controls.Add(this.radioButton_Drawer_黃);
            this.panel2.Controls.Add(this.radioButton_Drawer_綠);
            this.panel2.Controls.Add(this.radioButton_Drawer_藍);
            this.panel2.Controls.Add(this.radioButton_Drawer_紅);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.button_Drawer_Clear);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.numericUpDown_V_Line_index);
            this.panel2.Controls.Add(this.button_V_Line_Show);
            this.panel2.Controls.Add(this.numericUpDown_H_Line_index);
            this.panel2.Controls.Add(this.button_H_Line_Show);
            this.panel2.Location = new System.Drawing.Point(12, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 224);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_Drawer_ShowBox);
            this.panel3.Controls.Add(this.numericUpDown_Drawer_Height);
            this.panel3.Controls.Add(this.numericUpDown_Drawer_Width);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.numericUpDown_Drawer_PointY);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.numericUpDown_Drawer_PointX);
            this.panel3.Location = new System.Drawing.Point(9, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(303, 135);
            this.panel3.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(9, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "座標     : ";
            // 
            // numericUpDown_Drawer_PointX
            // 
            this.numericUpDown_Drawer_PointX.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_Drawer_PointX.Location = new System.Drawing.Point(113, 15);
            this.numericUpDown_Drawer_PointX.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_Drawer_PointX.Name = "numericUpDown_Drawer_PointX";
            this.numericUpDown_Drawer_PointX.Size = new System.Drawing.Size(57, 29);
            this.numericUpDown_Drawer_PointX.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(93, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "(";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(181, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = ",";
            // 
            // numericUpDown_Drawer_PointY
            // 
            this.numericUpDown_Drawer_PointY.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_Drawer_PointY.Location = new System.Drawing.Point(200, 15);
            this.numericUpDown_Drawer_PointY.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_Drawer_PointY.Name = "numericUpDown_Drawer_PointY";
            this.numericUpDown_Drawer_PointY.Size = new System.Drawing.Size(57, 29);
            this.numericUpDown_Drawer_PointY.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(265, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = ")";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(9, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Width  : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(9, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Height : ";
            // 
            // numericUpDown_Drawer_Width
            // 
            this.numericUpDown_Drawer_Width.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_Drawer_Width.Location = new System.Drawing.Point(97, 56);
            this.numericUpDown_Drawer_Width.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_Drawer_Width.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Drawer_Width.Name = "numericUpDown_Drawer_Width";
            this.numericUpDown_Drawer_Width.Size = new System.Drawing.Size(57, 29);
            this.numericUpDown_Drawer_Width.TabIndex = 18;
            this.numericUpDown_Drawer_Width.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_Drawer_Height
            // 
            this.numericUpDown_Drawer_Height.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_Drawer_Height.Location = new System.Drawing.Point(97, 91);
            this.numericUpDown_Drawer_Height.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown_Drawer_Height.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Drawer_Height.Name = "numericUpDown_Drawer_Height";
            this.numericUpDown_Drawer_Height.Size = new System.Drawing.Size(57, 29);
            this.numericUpDown_Drawer_Height.TabIndex = 19;
            this.numericUpDown_Drawer_Height.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_Drawer_ShowBox
            // 
            this.button_Drawer_ShowBox.Location = new System.Drawing.Point(185, 85);
            this.button_Drawer_ShowBox.Name = "button_Drawer_ShowBox";
            this.button_Drawer_ShowBox.Size = new System.Drawing.Size(98, 35);
            this.button_Drawer_ShowBox.TabIndex = 20;
            this.button_Drawer_ShowBox.Text = "Show Box";
            this.button_Drawer_ShowBox.UseVisualStyleBackColor = true;
            // 
            // radioButton_Drawer_紅
            // 
            this.radioButton_Drawer_紅.AutoSize = true;
            this.radioButton_Drawer_紅.Checked = true;
            this.radioButton_Drawer_紅.Location = new System.Drawing.Point(327, 12);
            this.radioButton_Drawer_紅.Name = "radioButton_Drawer_紅";
            this.radioButton_Drawer_紅.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Drawer_紅.TabIndex = 12;
            this.radioButton_Drawer_紅.TabStop = true;
            this.radioButton_Drawer_紅.Text = "紅";
            this.radioButton_Drawer_紅.UseVisualStyleBackColor = true;
            // 
            // radioButton_Drawer_藍
            // 
            this.radioButton_Drawer_藍.AutoSize = true;
            this.radioButton_Drawer_藍.Location = new System.Drawing.Point(327, 33);
            this.radioButton_Drawer_藍.Name = "radioButton_Drawer_藍";
            this.radioButton_Drawer_藍.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Drawer_藍.TabIndex = 13;
            this.radioButton_Drawer_藍.Text = "藍";
            this.radioButton_Drawer_藍.UseVisualStyleBackColor = true;
            // 
            // radioButton_Drawer_綠
            // 
            this.radioButton_Drawer_綠.AutoSize = true;
            this.radioButton_Drawer_綠.Location = new System.Drawing.Point(327, 54);
            this.radioButton_Drawer_綠.Name = "radioButton_Drawer_綠";
            this.radioButton_Drawer_綠.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Drawer_綠.TabIndex = 14;
            this.radioButton_Drawer_綠.Text = "綠";
            this.radioButton_Drawer_綠.UseVisualStyleBackColor = true;
            // 
            // radioButton_Drawer_黃
            // 
            this.radioButton_Drawer_黃.AutoSize = true;
            this.radioButton_Drawer_黃.Location = new System.Drawing.Point(327, 75);
            this.radioButton_Drawer_黃.Name = "radioButton_Drawer_黃";
            this.radioButton_Drawer_黃.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Drawer_黃.TabIndex = 15;
            this.radioButton_Drawer_黃.Text = "黃";
            this.radioButton_Drawer_黃.UseVisualStyleBackColor = true;
            // 
            // radioButton_Drawer_白
            // 
            this.radioButton_Drawer_白.AutoSize = true;
            this.radioButton_Drawer_白.Location = new System.Drawing.Point(327, 96);
            this.radioButton_Drawer_白.Name = "radioButton_Drawer_白";
            this.radioButton_Drawer_白.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Drawer_白.TabIndex = 16;
            this.radioButton_Drawer_白.Text = "白";
            this.radioButton_Drawer_白.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 579);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button_ConnectTest);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_V_Line_index)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_H_Line_index)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_PointX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_PointY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_Width)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Drawer_Height)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_IPA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_IPD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_IPC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_IPB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ConnectTest;
        private System.Windows.Forms.NumericUpDown numericUpDown_V_Line_index;
        private System.Windows.Forms.Button button_V_Line_Show;
        private System.Windows.Forms.NumericUpDown numericUpDown_H_Line_index;
        private System.Windows.Forms.Button button_H_Line_Show;
        private System.Windows.Forms.Button button_Drawer_Clear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_Drawer_ShowBox;
        private System.Windows.Forms.NumericUpDown numericUpDown_Drawer_Height;
        private System.Windows.Forms.NumericUpDown numericUpDown_Drawer_Width;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown_Drawer_PointY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_Drawer_PointX;
        private System.Windows.Forms.RadioButton radioButton_Drawer_白;
        private System.Windows.Forms.RadioButton radioButton_Drawer_黃;
        private System.Windows.Forms.RadioButton radioButton_Drawer_綠;
        private System.Windows.Forms.RadioButton radioButton_Drawer_藍;
        private System.Windows.Forms.RadioButton radioButton_Drawer_紅;
    }
}

