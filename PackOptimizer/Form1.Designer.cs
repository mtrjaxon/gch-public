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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            button2 = new Button();
            menuStrip1 = new MenuStrip();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            expirementalFeaturesToolStripMenuItem = new ToolStripMenuItem();
            button4 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            asyncExtractCheckBox = new CheckBox();
            label5 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(155, 238);
            button1.Name = "button1";
            button1.Size = new Size(100, 29);
            button1.TabIndex = 0;
            button1.Text = "Open Directory";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 273);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(561, 123);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(367, 238);
            button3.Name = "button3";
            button3.Size = new Size(100, 29);
            button3.TabIndex = 5;
            button3.Text = "Pack";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(261, 238);
            button2.Name = "button2";
            button2.Size = new Size(100, 29);
            button2.TabIndex = 6;
            button2.Text = "Extract";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(585, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { expirementalFeaturesToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // expirementalFeaturesToolStripMenuItem
            // 
            expirementalFeaturesToolStripMenuItem.Name = "expirementalFeaturesToolStripMenuItem";
            expirementalFeaturesToolStripMenuItem.Size = new Size(190, 22);
            expirementalFeaturesToolStripMenuItem.Text = "Expiremental Features";
            expirementalFeaturesToolStripMenuItem.Click += expirementalFeaturesToolStripMenuItem_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Silver;
            button4.Enabled = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(473, 238);
            button4.Name = "button4";
            button4.Size = new Size(100, 29);
            button4.TabIndex = 9;
            button4.Text = "Create";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 249);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 10;
            label1.Text = "Log Viewer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 31);
            label2.Name = "label2";
            label2.Size = new Size(59, 21);
            label2.TabIndex = 11;
            label2.Text = "gch2.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 52);
            label3.Name = "label3";
            label3.Size = new Size(176, 21);
            label3.TabIndex = 12;
            label3.Text = "created by yoursorrow";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 82);
            label4.Name = "label4";
            label4.Size = new Size(585, 120);
            label4.TabIndex = 13;
            label4.Text = resources.GetString("label4.Text");
            // 
            // asyncExtractCheckBox
            // 
            asyncExtractCheckBox.AutoSize = true;
            asyncExtractCheckBox.ForeColor = Color.White;
            asyncExtractCheckBox.Location = new Point(261, 213);
            asyncExtractCheckBox.Name = "asyncExtractCheckBox";
            asyncExtractCheckBox.Size = new Size(97, 19);
            asyncExtractCheckBox.TabIndex = 14;
            asyncExtractCheckBox.Text = "Async Extract";
            asyncExtractCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Cursor = Cursors.Hand;
            label5.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(113, 253);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 15;
            label5.Text = "Clear";
            label5.Click += label5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(585, 408);
            Controls.Add(label5);
            Controls.Add(asyncExtractCheckBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private RichTextBox richTextBox1;
        private Button button3;
        private Button button2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem expirementalFeaturesToolStripMenuItem;
        private Button button4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox asyncExtractCheckBox;
        private Label label5;
    }
}