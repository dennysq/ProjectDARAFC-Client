namespace C_Client
{
    partial class PaginaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginaPrincipal));
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuItemCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRegistrarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRegistrarFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemConsultarFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCliente,
            this.facturaToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(546, 24);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuItemCliente
            // 
            this.menuItemCliente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRegistrarCliente});
            this.menuItemCliente.Name = "menuItemCliente";
            this.menuItemCliente.Size = new System.Drawing.Size(56, 20);
            this.menuItemCliente.Text = "Cliente";
            this.menuItemCliente.Click += new System.EventHandler(this.registrarClienteToolStripMenuItem_Click);
            // 
            // MenuItemRegistrarCliente
            // 
            this.MenuItemRegistrarCliente.Name = "MenuItemRegistrarCliente";
            this.MenuItemRegistrarCliente.Size = new System.Drawing.Size(160, 22);
            this.MenuItemRegistrarCliente.Text = "Registrar Cliente";
            this.MenuItemRegistrarCliente.Click += new System.EventHandler(this.MenuItemRegistrarCliente_Click);
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemRegistrarFactura,
            this.MenuItemConsultarFactura});
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.facturaToolStripMenuItem.Text = "Factura";
            // 
            // MenuItemRegistrarFactura
            // 
            this.MenuItemRegistrarFactura.Name = "MenuItemRegistrarFactura";
            this.MenuItemRegistrarFactura.Size = new System.Drawing.Size(167, 22);
            this.MenuItemRegistrarFactura.Text = "Registrar Factura";
            this.MenuItemRegistrarFactura.Click += new System.EventHandler(this.MenuItemRegistrarFactura_Click);
            // 
            // MenuItemConsultarFactura
            // 
            this.MenuItemConsultarFactura.Name = "MenuItemConsultarFactura";
            this.MenuItemConsultarFactura.Size = new System.Drawing.Size(167, 22);
            this.MenuItemConsultarFactura.Text = "Consultar Factura";
            this.MenuItemConsultarFactura.Click += new System.EventHandler(this.MenuItemConsultarFactura_Click);
            // 
            // PaginaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 331);
            this.Controls.Add(this.menuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.MaximizeBox = false;
            this.Name = "PaginaPrincipal";
            this.Text = "Sistema de Facturación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaginaPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.PaginaPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuItemCliente;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRegistrarCliente;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRegistrarFactura;
        private System.Windows.Forms.ToolStripMenuItem MenuItemConsultarFactura;
    }
}