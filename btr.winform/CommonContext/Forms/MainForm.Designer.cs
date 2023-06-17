namespace btr.winform.CommonContext.Forms
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            purchaseToolStripMenuItem = new ToolStripMenuItem();
            purchaseOrderToolStripMenuItem = new ToolStripMenuItem();
            goodsReceiptToolStripMenuItem = new ToolStripMenuItem();
            fakturTagihanToolStripMenuItem = new ToolStripMenuItem();
            returBeliToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            supplierToolStripMenuItem = new ToolStripMenuItem();
            supplierToolStripMenuItem1 = new ToolStripMenuItem();
            salesToolStripMenuItem = new ToolStripMenuItem();
            inventoryToolStripMenuItem = new ToolStripMenuItem();
            financeToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { purchaseToolStripMenuItem, salesToolStripMenuItem, inventoryToolStripMenuItem, financeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 63);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // purchaseToolStripMenuItem
            // 
            purchaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { purchaseOrderToolStripMenuItem, goodsReceiptToolStripMenuItem, fakturTagihanToolStripMenuItem, returBeliToolStripMenuItem, toolStripMenuItem1, supplierToolStripMenuItem });
            purchaseToolStripMenuItem.Image = Properties.Resources.binder_40px;
            purchaseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            purchaseToolStripMenuItem.Size = new Size(67, 59);
            purchaseToolStripMenuItem.Text = "Purchase";
            purchaseToolStripMenuItem.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // purchaseOrderToolStripMenuItem
            // 
            purchaseOrderToolStripMenuItem.Image = Properties.Resources.send_30px;
            purchaseOrderToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            purchaseOrderToolStripMenuItem.Name = "purchaseOrderToolStripMenuItem";
            purchaseOrderToolStripMenuItem.Size = new Size(194, 36);
            purchaseOrderToolStripMenuItem.Text = "Purchase Order...";
            // 
            // goodsReceiptToolStripMenuItem
            // 
            goodsReceiptToolStripMenuItem.Image = Properties.Resources.shipped_30px;
            goodsReceiptToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            goodsReceiptToolStripMenuItem.Name = "goodsReceiptToolStripMenuItem";
            goodsReceiptToolStripMenuItem.Size = new Size(194, 36);
            goodsReceiptToolStripMenuItem.Text = "Goods Receipt...";
            // 
            // fakturTagihanToolStripMenuItem
            // 
            fakturTagihanToolStripMenuItem.Image = Properties.Resources.bill_30px;
            fakturTagihanToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            fakturTagihanToolStripMenuItem.Name = "fakturTagihanToolStripMenuItem";
            fakturTagihanToolStripMenuItem.Size = new Size(194, 36);
            fakturTagihanToolStripMenuItem.Text = "Faktur Tagihan...";
            // 
            // returBeliToolStripMenuItem
            // 
            returBeliToolStripMenuItem.Image = Properties.Resources.archeology_30px;
            returBeliToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            returBeliToolStripMenuItem.Name = "returBeliToolStripMenuItem";
            returBeliToolStripMenuItem.Size = new Size(194, 36);
            returBeliToolStripMenuItem.Text = "Retur Beli...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(191, 6);
            // 
            // supplierToolStripMenuItem
            // 
            supplierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { supplierToolStripMenuItem1 });
            supplierToolStripMenuItem.Name = "supplierToolStripMenuItem";
            supplierToolStripMenuItem.Size = new Size(194, 36);
            supplierToolStripMenuItem.Text = "Master Data";
            // 
            // supplierToolStripMenuItem1
            // 
            supplierToolStripMenuItem1.Name = "supplierToolStripMenuItem1";
            supplierToolStripMenuItem1.Size = new Size(126, 22);
            supplierToolStripMenuItem1.Text = "Supplier...";
            // 
            // salesToolStripMenuItem
            // 
            salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            salesToolStripMenuItem.Size = new Size(45, 59);
            salesToolStripMenuItem.Text = "Sales";
            // 
            // inventoryToolStripMenuItem
            // 
            inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            inventoryToolStripMenuItem.Size = new Size(69, 59);
            inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // financeToolStripMenuItem
            // 
            financeToolStripMenuItem.Name = "financeToolStripMenuItem";
            financeToolStripMenuItem.Size = new Size(60, 59);
            financeToolStripMenuItem.Text = "Finance";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "BTR Sistem";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem purchaseToolStripMenuItem;
        private ToolStripMenuItem purchaseOrderToolStripMenuItem;
        private ToolStripMenuItem goodsReceiptToolStripMenuItem;
        private ToolStripMenuItem fakturTagihanToolStripMenuItem;
        private ToolStripMenuItem returBeliToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem supplierToolStripMenuItem;
        private ToolStripMenuItem supplierToolStripMenuItem1;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem inventoryToolStripMenuItem;
        private ToolStripMenuItem financeToolStripMenuItem;
    }
}