using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ReconcileTool
{
    partial class ReconcileForm
    {
        private IContainer components = (IContainer)null;

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
            this.btnLoadShoppeData = new Button();
            this.ofdLoadShoppeData = new OpenFileDialog();
            this.btnLoadStockInfo = new Button();
            this.ofdLoadStockData = new OpenFileDialog();
            this.button2 = new Button();
            this.tbxFileName = new TextBox();
            this.tbxNoneMatchNames = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.tbxFindAccount = new TextBox();
            this.label3 = new Label();
            this.SuspendLayout();
            this.btnLoadShoppeData.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.btnLoadShoppeData.Location = new Point(39, 48);
            this.btnLoadShoppeData.Margin = new Padding(4);
            this.btnLoadShoppeData.Name = "btnLoadShoppeData";
            this.btnLoadShoppeData.Size = new Size(471, 54);
            this.btnLoadShoppeData.TabIndex = 0;
            this.btnLoadShoppeData.Text = "載入蝦皮帳單資料";
            this.btnLoadShoppeData.UseVisualStyleBackColor = true;
            this.btnLoadShoppeData.Click += new EventHandler(this.btnLoadShoppeData_Click);
            this.btnLoadStockInfo.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.btnLoadStockInfo.Location = new Point(39, 159);
            this.btnLoadStockInfo.Margin = new Padding(4);
            this.btnLoadStockInfo.Name = "btnLoadStockInfo";
            this.btnLoadStockInfo.Size = new Size(471, 54);
            this.btnLoadStockInfo.TabIndex = 1;
            this.btnLoadStockInfo.Text = "載入進出存銷資料";
            this.btnLoadStockInfo.UseVisualStyleBackColor = true;
            this.btnLoadStockInfo.Click += new EventHandler(this.btnLoadStockInfo_Click);
            this.button2.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.button2.Location = new Point(39, 273);
            this.button2.Margin = new Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new Size(471, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "開始";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new EventHandler(this.btnAnalyze_Click);
            this.tbxFileName.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.tbxFileName.Location = new Point(39, 390);
            this.tbxFileName.Multiline = true;
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new Size(471, 194);
            this.tbxFileName.TabIndex = 3;
            this.tbxNoneMatchNames.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.tbxNoneMatchNames.Location = new Point(560, 101);
            this.tbxNoneMatchNames.Multiline = true;
            this.tbxNoneMatchNames.Name = "tbxNoneMatchNames";
            this.tbxNoneMatchNames.ScrollBars = ScrollBars.Vertical;
            this.tbxNoneMatchNames.Size = new Size(428, 483);
            this.tbxNoneMatchNames.TabIndex = 4;
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label1.Location = new Point(555, 48);
            this.label1.Name = "label1";
            this.label1.Size = new Size(163, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "對應失敗帳號:";
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label2.Location = new Point(36, 357);
            this.label2.Name = "label2";
            this.label2.Size = new Size(115, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "檔案位置:";
            this.tbxFindAccount.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.tbxFindAccount.Location = new Point(1016, 101);
            this.tbxFindAccount.Multiline = true;
            this.tbxFindAccount.Name = "tbxFindAccount";
            this.tbxFindAccount.ScrollBars = ScrollBars.Vertical;
            this.tbxFindAccount.Size = new Size(503, 483);
            this.tbxFindAccount.TabIndex = 7;
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
            this.label3.Location = new Point(1011, 48);
            this.label3.Name = "label3";
            this.label3.Size = new Size(109, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "找到帳號";
            this.AutoScaleDimensions = new SizeF(9f, 18f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(2305, 680);
            this.Controls.Add((Control)this.label3);
            this.Controls.Add((Control)this.tbxFindAccount);
            this.Controls.Add((Control)this.label2);
            this.Controls.Add((Control)this.label1);
            this.Controls.Add((Control)this.tbxNoneMatchNames);
            this.Controls.Add((Control)this.tbxFileName);
            this.Controls.Add((Control)this.button2);
            this.Controls.Add((Control)this.btnLoadStockInfo);
            this.Controls.Add((Control)this.btnLoadShoppeData);
            this.Margin = new Padding(4);
            this.Name = "ReconcileForm";
            this.Text = "蝦皮對帳小程式";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}