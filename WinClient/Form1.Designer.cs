namespace WinClient
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
            lblNick = new Label();
            txtNick = new TextBox();
            btnSignIn = new Button();
            txtMessageHistory = new TextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // lblNick
            // 
            lblNick.AutoSize = true;
            lblNick.Location = new Point(12, 16);
            lblNick.Name = "lblNick";
            lblNick.Size = new Size(31, 15);
            lblNick.TabIndex = 0;
            lblNick.Text = "Nick";
            // 
            // txtNick
            // 
            txtNick.Location = new Point(49, 13);
            txtNick.Name = "txtNick";
            txtNick.Size = new Size(173, 23);
            txtNick.TabIndex = 1;
            // 
            // btnSignIn
            // 
            btnSignIn.Location = new Point(228, 12);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(75, 23);
            btnSignIn.TabIndex = 2;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // txtMessageHistory
            // 
            txtMessageHistory.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMessageHistory.Location = new Point(12, 42);
            txtMessageHistory.Multiline = true;
            txtMessageHistory.Name = "txtMessageHistory";
            txtMessageHistory.ReadOnly = true;
            txtMessageHistory.ScrollBars = ScrollBars.Vertical;
            txtMessageHistory.Size = new Size(291, 282);
            txtMessageHistory.TabIndex = 3;
            txtMessageHistory.TextChanged += textBox1_TextChanged;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 330);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(210, 23);
            txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(228, 330);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 365);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtMessageHistory);
            Controls.Add(btnSignIn);
            Controls.Add(txtNick);
            Controls.Add(lblNick);
            Name = "Form1";
            Text = "Chat Client";
            FormClosing += Form_Closing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
        }

        #endregion

        private Label lblNick;
        private TextBox txtNick;
        private Button btnSignIn;
        private TextBox txtMessageHistory;
        private TextBox txtMessage;
        private Button btnSend;
    }
}
