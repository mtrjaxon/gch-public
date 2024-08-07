namespace PackOptimizer
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
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            button2 = new Button();
            button4 = new Button();
            label2 = new Label();
            asyncExtractCheckBox = new CheckBox();
            label5 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(8, 21, 31);
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 332);
            button1.Name = "button1";
            button1.Size = new Size(100, 29);
            button1.TabIndex = 0;
            button1.Text = "Open Directory";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(8, 21, 31);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(12, 53);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(561, 273);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(8, 21, 31);
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(224, 332);
            button3.Name = "button3";
            button3.Size = new Size(100, 29);
            button3.TabIndex = 5;
            button3.Text = "Backup";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 21, 31);
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(118, 332);
            button2.Name = "button2";
            button2.Size = new Size(100, 29);
            button2.TabIndex = 6;
            button2.Text = "Extract";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(8, 21, 31);
            button4.FlatStyle = FlatStyle.Flat;
            button4.ForeColor = Color.White;
            button4.Location = new Point(330, 332);
            button4.Name = "button4";
            button4.Size = new Size(100, 29);
            button4.TabIndex = 9;
            button4.Text = "Create";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(52, 21);
            label2.TabIndex = 11;
            label2.Text = "GCH3";
            // 
            // asyncExtractCheckBox
            // 
            asyncExtractCheckBox.AutoSize = true;
            asyncExtractCheckBox.ForeColor = Color.White;
            asyncExtractCheckBox.Location = new Point(12, 367);
            asyncExtractCheckBox.Name = "asyncExtractCheckBox";
            asyncExtractCheckBox.Size = new Size(105, 19);
            asyncExtractCheckBox.TabIndex = 14;
            asyncExtractCheckBox.Text = "Async Features";
            asyncExtractCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.Hand;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(537, 329);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 15;
            label5.Text = "Clear";
            label5.Click += label5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(443, 18);
            label1.TabIndex = 16;
            label1.Text = "This project is not regularly maintained. Expect massive issues.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(11, 32, 48);
            ClientSize = new Size(585, 393);
            Controls.Add(label1);
            Controls.Add(label5);
            Controls.Add(asyncExtractCheckBox);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox richTextBox1;
        private Button button3;
        private Button button2;
        private Button button4;
        private Label label2;
        private CheckBox asyncExtractCheckBox;
        private Label label5;
        private Label label1;
    }
}