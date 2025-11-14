namespace WinFormsApp3
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
            txtAnswer = new TextBox();
            txtQuestion = new TextBox();
            btnLoadCsv = new Button();
            btnAnswer = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtAnswer
            // 
            txtAnswer.BackColor = SystemColors.ScrollBar;
            txtAnswer.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnswer.Location = new Point(12, 112);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ReadOnly = true;
            txtAnswer.Size = new Size(753, 190);
            txtAnswer.TabIndex = 0;
            // 
            // txtQuestion
            // 
            txtQuestion.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtQuestion.Location = new Point(12, 362);
            txtQuestion.Multiline = true;
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(753, 180);
            txtQuestion.TabIndex = 0;
            // 
            // btnLoadCsv
            // 
            btnLoadCsv.BackColor = Color.LawnGreen;
            btnLoadCsv.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadCsv.Location = new Point(771, 460);
            btnLoadCsv.Name = "btnLoadCsv";
            btnLoadCsv.Size = new Size(118, 82);
            btnLoadCsv.TabIndex = 1;
            btnLoadCsv.Text = "GỬI";
            btnLoadCsv.UseVisualStyleBackColor = false;
            btnLoadCsv.Click += button1_Click;
            // 
            // btnAnswer
            // 
            btnAnswer.BackColor = Color.Yellow;
            btnAnswer.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAnswer.ForeColor = SystemColors.ActiveCaptionText;
            btnAnswer.Location = new Point(771, 362);
            btnAnswer.Name = "btnAnswer";
            btnAnswer.Size = new Size(118, 92);
            btnAnswer.TabIndex = 2;
            btnAnswer.Text = "CHỌN FILE";
            btnAnswer.UseVisualStyleBackColor = false;
            btnAnswer.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(895, 362);
            button3.Name = "button3";
            button3.Size = new Size(117, 180);
            button3.TabIndex = 3;
            button3.Text = "LÀM SẠCH";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(233, 51);
            label1.Name = "label1";
            label1.Size = new Size(590, 32);
            label1.TabIndex = 4;
            label1.Text = "HỆ THỐNG CHATBOX HỖ TRỢ NHA KHOA";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1024, 554);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(btnAnswer);
            Controls.Add(btnLoadCsv);
            Controls.Add(txtQuestion);
            Controls.Add(txtAnswer);
            Name = "Form1";
            Text = "HỆ THỐNG CHATBOX HỖ TRỢ NHA KHOA";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAnswer;
        private TextBox txtQuestion;
        private Button btnLoadCsv;
        private Button btnAnswer;
        private Button button3;
        private Label label1;
    }
}
