namespace AsyncAwaitPractica
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNormal = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.rtxtbxResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(50, 76);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(372, 71);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Text = "Correr Normal";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(50, 182);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(372, 71);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Correr Async";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // rtxtbxResults
            // 
            this.rtxtbxResults.Location = new System.Drawing.Point(12, 272);
            this.rtxtbxResults.Name = "rtxtbxResults";
            this.rtxtbxResults.Size = new System.Drawing.Size(678, 151);
            this.rtxtbxResults.TabIndex = 2;
            this.rtxtbxResults.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtxtbxResults);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnNormal);
            this.Name = "Form1";
            this.Text = "Practica 1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnNormal;
        private Button btnAsync;
        private RichTextBox rtxtbxResults;
    }
}