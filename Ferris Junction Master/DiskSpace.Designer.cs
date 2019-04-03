namespace Ferris_Junction_Master
{
    partial class DiskSpace
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TbSpaceUsed = new MetroFramework.Controls.MetroTextBox();
            this.TbSpaceChanging = new MetroFramework.Controls.MetroTextBox();
            this.TbSpaceFree = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // TbSpaceUsed
            // 
            this.TbSpaceUsed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TbSpaceUsed.BackColor = System.Drawing.Color.DodgerBlue;
            // 
            // 
            // 
            this.TbSpaceUsed.CustomButton.Image = null;
            this.TbSpaceUsed.CustomButton.Location = new System.Drawing.Point(165, 1);
            this.TbSpaceUsed.CustomButton.Name = "";
            this.TbSpaceUsed.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.TbSpaceUsed.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TbSpaceUsed.CustomButton.TabIndex = 1;
            this.TbSpaceUsed.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TbSpaceUsed.CustomButton.UseSelectable = true;
            this.TbSpaceUsed.CustomButton.Visible = false;
            this.TbSpaceUsed.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TbSpaceUsed.Lines = new string[] {
        "100 GB"};
            this.TbSpaceUsed.Location = new System.Drawing.Point(0, 0);
            this.TbSpaceUsed.Margin = new System.Windows.Forms.Padding(0);
            this.TbSpaceUsed.MaxLength = 32767;
            this.TbSpaceUsed.Multiline = true;
            this.TbSpaceUsed.Name = "TbSpaceUsed";
            this.TbSpaceUsed.PasswordChar = '\0';
            this.TbSpaceUsed.ReadOnly = true;
            this.TbSpaceUsed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbSpaceUsed.SelectedText = "";
            this.TbSpaceUsed.SelectionLength = 0;
            this.TbSpaceUsed.SelectionStart = 0;
            this.TbSpaceUsed.ShortcutsEnabled = false;
            this.TbSpaceUsed.Size = new System.Drawing.Size(189, 25);
            this.TbSpaceUsed.TabIndex = 0;
            this.TbSpaceUsed.TabStop = false;
            this.TbSpaceUsed.Text = "100 GB";
            this.TbSpaceUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbSpaceUsed.UseCustomBackColor = true;
            this.TbSpaceUsed.UseSelectable = true;
            this.TbSpaceUsed.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TbSpaceUsed.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TbSpaceChanging
            // 
            this.TbSpaceChanging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.TbSpaceChanging.BackColor = System.Drawing.Color.LimeGreen;
            // 
            // 
            // 
            this.TbSpaceChanging.CustomButton.Image = null;
            this.TbSpaceChanging.CustomButton.Location = new System.Drawing.Point(91, 1);
            this.TbSpaceChanging.CustomButton.Name = "";
            this.TbSpaceChanging.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.TbSpaceChanging.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TbSpaceChanging.CustomButton.TabIndex = 1;
            this.TbSpaceChanging.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TbSpaceChanging.CustomButton.UseSelectable = true;
            this.TbSpaceChanging.CustomButton.Visible = false;
            this.TbSpaceChanging.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TbSpaceChanging.Lines = new string[] {
        "20 GB"};
            this.TbSpaceChanging.Location = new System.Drawing.Point(187, 0);
            this.TbSpaceChanging.Margin = new System.Windows.Forms.Padding(0);
            this.TbSpaceChanging.MaxLength = 32767;
            this.TbSpaceChanging.Multiline = true;
            this.TbSpaceChanging.Name = "TbSpaceChanging";
            this.TbSpaceChanging.PasswordChar = '\0';
            this.TbSpaceChanging.ReadOnly = true;
            this.TbSpaceChanging.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbSpaceChanging.SelectedText = "";
            this.TbSpaceChanging.SelectionLength = 0;
            this.TbSpaceChanging.SelectionStart = 0;
            this.TbSpaceChanging.ShortcutsEnabled = false;
            this.TbSpaceChanging.Size = new System.Drawing.Size(183, 25);
            this.TbSpaceChanging.TabIndex = 1;
            this.TbSpaceChanging.TabStop = false;
            this.TbSpaceChanging.Text = "20 GB";
            this.TbSpaceChanging.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbSpaceChanging.UseCustomBackColor = true;
            this.TbSpaceChanging.UseSelectable = true;
            this.TbSpaceChanging.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TbSpaceChanging.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TbSpaceFree
            // 
            this.TbSpaceFree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbSpaceFree.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.TbSpaceFree.CustomButton.Image = null;
            this.TbSpaceFree.CustomButton.Location = new System.Drawing.Point(109, 1);
            this.TbSpaceFree.CustomButton.Name = "";
            this.TbSpaceFree.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.TbSpaceFree.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TbSpaceFree.CustomButton.TabIndex = 1;
            this.TbSpaceFree.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TbSpaceFree.CustomButton.UseSelectable = true;
            this.TbSpaceFree.CustomButton.Visible = false;
            this.TbSpaceFree.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TbSpaceFree.Lines = new string[] {
        "50 GB"};
            this.TbSpaceFree.Location = new System.Drawing.Point(370, 0);
            this.TbSpaceFree.Margin = new System.Windows.Forms.Padding(0);
            this.TbSpaceFree.MaxLength = 32767;
            this.TbSpaceFree.Multiline = true;
            this.TbSpaceFree.Name = "TbSpaceFree";
            this.TbSpaceFree.PasswordChar = '\0';
            this.TbSpaceFree.ReadOnly = true;
            this.TbSpaceFree.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbSpaceFree.SelectedText = "";
            this.TbSpaceFree.SelectionLength = 0;
            this.TbSpaceFree.SelectionStart = 0;
            this.TbSpaceFree.ShortcutsEnabled = false;
            this.TbSpaceFree.Size = new System.Drawing.Size(133, 25);
            this.TbSpaceFree.TabIndex = 2;
            this.TbSpaceFree.TabStop = false;
            this.TbSpaceFree.Text = "50 GB";
            this.TbSpaceFree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbSpaceFree.UseCustomBackColor = true;
            this.TbSpaceFree.UseSelectable = true;
            this.TbSpaceFree.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TbSpaceFree.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DiskSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TbSpaceChanging);
            this.Controls.Add(this.TbSpaceUsed);
            this.Controls.Add(this.TbSpaceFree);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DiskSpace";
            this.Size = new System.Drawing.Size(503, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TbSpaceUsed;
        private MetroFramework.Controls.MetroTextBox TbSpaceChanging;
        private MetroFramework.Controls.MetroTextBox TbSpaceFree;
    }
}
