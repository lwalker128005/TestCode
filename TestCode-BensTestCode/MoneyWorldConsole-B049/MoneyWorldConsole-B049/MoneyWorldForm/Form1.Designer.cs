namespace MoneyWorldForm
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
            this.lblReceipts = new System.Windows.Forms.Label();
            this.lblMoneyItems = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtWallet = new System.Windows.Forms.TextBox();
            this.lblWallet = new System.Windows.Forms.Label();
            this.lbxReceipts = new System.Windows.Forms.ListBox();
            this.lbxMoneyItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblReceipts
            // 
            this.lblReceipts.AutoSize = true;
            this.lblReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceipts.Location = new System.Drawing.Point(117, 13);
            this.lblReceipts.Name = "lblReceipts";
            this.lblReceipts.Size = new System.Drawing.Size(153, 39);
            this.lblReceipts.TabIndex = 1;
            this.lblReceipts.Text = "Receipts";
            // 
            // lblMoneyItems
            // 
            this.lblMoneyItems.AutoSize = true;
            this.lblMoneyItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneyItems.Location = new System.Drawing.Point(76, 207);
            this.lblMoneyItems.Name = "lblMoneyItems";
            this.lblMoneyItems.Size = new System.Drawing.Size(216, 39);
            this.lblMoneyItems.TabIndex = 3;
            this.lblMoneyItems.Text = "Money Items";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(27, 501);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 44);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // txtWallet
            // 
            this.txtWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWallet.Location = new System.Drawing.Point(28, 445);
            this.txtWallet.Name = "txtWallet";
            this.txtWallet.Size = new System.Drawing.Size(163, 38);
            this.txtWallet.TabIndex = 5;
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWallet.Location = new System.Drawing.Point(42, 402);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(89, 31);
            this.lblWallet.TabIndex = 6;
            this.lblWallet.Text = "Wallet";
            // 
            // lbxReceipts
            // 
            this.lbxReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxReceipts.FormattingEnabled = true;
            this.lbxReceipts.ItemHeight = 24;
            this.lbxReceipts.Location = new System.Drawing.Point(27, 55);
            this.lbxReceipts.Name = "lbxReceipts";
            this.lbxReceipts.Size = new System.Drawing.Size(537, 124);
            this.lbxReceipts.TabIndex = 7;
            this.lbxReceipts.DoubleClick += new System.EventHandler(this.lbxReceipts_DoubleClick);
            // 
            // lbxMoneyItems
            // 
            this.lbxMoneyItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxMoneyItems.FormattingEnabled = true;
            this.lbxMoneyItems.ItemHeight = 24;
            this.lbxMoneyItems.Location = new System.Drawing.Point(27, 261);
            this.lbxMoneyItems.Name = "lbxMoneyItems";
            this.lbxMoneyItems.Size = new System.Drawing.Size(537, 124);
            this.lbxMoneyItems.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 592);
            this.Controls.Add(this.lbxMoneyItems);
            this.Controls.Add(this.lbxReceipts);
            this.Controls.Add(this.lblWallet);
            this.Controls.Add(this.txtWallet);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblMoneyItems);
            this.Controls.Add(this.lblReceipts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReceipts;
        private System.Windows.Forms.Label lblMoneyItems;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtWallet;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.ListBox lbxReceipts;
        private System.Windows.Forms.ListBox lbxMoneyItems;
    }
}

