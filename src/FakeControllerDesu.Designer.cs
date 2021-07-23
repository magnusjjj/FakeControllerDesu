namespace FakeControllerDesu
{
    public partial class FakeControllerDesu
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
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.txtEval = new System.Windows.Forms.TextBox();
            this.EvalButton = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.OpenScriptDirectoryButton = new System.Windows.Forms.Button();
            this.OpenGithubButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogBox.Location = new System.Drawing.Point(12, 12);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(600, 469);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            // 
            // txtEval
            // 
            this.txtEval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEval.Location = new System.Drawing.Point(12, 487);
            this.txtEval.Name = "txtEval";
            this.txtEval.Size = new System.Drawing.Size(600, 20);
            this.txtEval.TabIndex = 1;
            // 
            // EvalButton
            // 
            this.EvalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EvalButton.Location = new System.Drawing.Point(618, 487);
            this.EvalButton.Name = "EvalButton";
            this.EvalButton.Size = new System.Drawing.Size(117, 20);
            this.EvalButton.TabIndex = 2;
            this.EvalButton.Text = "Eval";
            this.EvalButton.UseVisualStyleBackColor = true;
            this.EvalButton.Click += new System.EventHandler(this.EvalButtonClick);
            // 
            // OpenScriptDirectoryButton
            // 
            this.OpenScriptDirectoryButton.Location = new System.Drawing.Point(618, 12);
            this.OpenScriptDirectoryButton.Name = "OpenScriptDirectoryButton";
            this.OpenScriptDirectoryButton.Size = new System.Drawing.Size(117, 23);
            this.OpenScriptDirectoryButton.TabIndex = 3;
            this.OpenScriptDirectoryButton.Text = "Open Script Directory";
            this.OpenScriptDirectoryButton.UseVisualStyleBackColor = true;
            this.OpenScriptDirectoryButton.Click += new System.EventHandler(this.OpenScriptDirectoryButton_Click);
            // 
            // OpenGithubButton
            // 
            this.OpenGithubButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OpenGithubButton.Location = new System.Drawing.Point(618, 41);
            this.OpenGithubButton.Name = "OpenGithubButton";
            this.OpenGithubButton.Size = new System.Drawing.Size(117, 23);
            this.OpenGithubButton.TabIndex = 5;
            this.OpenGithubButton.Text = "Open Github";
            this.OpenGithubButton.UseVisualStyleBackColor = true;
            this.OpenGithubButton.Click += new System.EventHandler(this.OpenGithubButton_Click);
            // 
            // FakeControllerDesu
            // 
            this.ClientSize = new System.Drawing.Size(747, 516);
            this.Controls.Add(this.OpenGithubButton);
            this.Controls.Add(this.OpenScriptDirectoryButton);
            this.Controls.Add(this.EvalButton);
            this.Controls.Add(this.txtEval);
            this.Controls.Add(this.LogBox);
            this.Name = "FakeControllerDesu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.TextBox txtEval;
        private System.Windows.Forms.Button EvalButton;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.Button OpenScriptDirectoryButton;
        private System.Windows.Forms.Button OpenGithubButton;
    }
}