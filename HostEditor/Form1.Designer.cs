namespace HostEditor
{
    partial class HostEditor
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
            this.GvHost = new System.Windows.Forms.DataGridView();
            this.BtnGoster = new System.Windows.Forms.Button();
            this.hostBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GvHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // GvHost
            // 
            this.GvHost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvHost.Location = new System.Drawing.Point(296, 23);
            this.GvHost.Name = "GvHost";
            this.GvHost.Size = new System.Drawing.Size(535, 197);
            this.GvHost.TabIndex = 0;
            // 
            // BtnGoster
            // 
            this.BtnGoster.Location = new System.Drawing.Point(45, 23);
            this.BtnGoster.Name = "BtnGoster";
            this.BtnGoster.Size = new System.Drawing.Size(198, 51);
            this.BtnGoster.TabIndex = 1;
            this.BtnGoster.Text = "Göster";
            this.BtnGoster.UseVisualStyleBackColor = true;
            this.BtnGoster.Click += new System.EventHandler(this.BtnGoster_Click);
            // 
            // hostBindingSource
            // 
            this.hostBindingSource.DataMember = "Host";
            // 
            // HostEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 232);
            this.Controls.Add(this.BtnGoster);
            this.Controls.Add(this.GvHost);
            this.Name = "HostEditor";
            this.Text = "Host Editör";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GvHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GvHost;
        private System.Windows.Forms.Button BtnGoster;
        //private HostEditor.HostEditorDataSet hostEditorDataSet;
        private System.Windows.Forms.BindingSource hostBindingSource;
        //private HostEditor.HostEditorDataSetTableAdapters.HostTableAdapter hostTableAdapter;
    }
}

