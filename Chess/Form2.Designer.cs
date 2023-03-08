namespace Chess
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.switch1 = new Chess.Switch();
            this.label2 = new System.Windows.Forms.Label();
            this.switch2 = new Chess.Switch();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Time Tracker";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // switch1
            // 
            this.switch1.AutoSize = true;
            this.switch1.Location = new System.Drawing.Point(296, 38);
            this.switch1.MinimumSize = new System.Drawing.Size(20, 22);
            this.switch1.Name = "switch1";
            this.switch1.OffBackColor = System.Drawing.Color.Gray;
            this.switch1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switch1.OnBackColor = System.Drawing.Color.SteelBlue;
            this.switch1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switch1.Size = new System.Drawing.Size(66, 22);
            this.switch1.TabIndex = 1;
            this.switch1.Text = "switch1";
            this.switch1.UseVisualStyleBackColor = true;
            this.switch1.CheckedChanged += new System.EventHandler(this.switch1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Turn Timer";
            // 
            // switch2
            // 
            this.switch2.AutoSize = true;
            this.switch2.Location = new System.Drawing.Point(296, 138);
            this.switch2.MinimumSize = new System.Drawing.Size(45, 22);
            this.switch2.Name = "switch2";
            this.switch2.OffBackColor = System.Drawing.Color.Gray;
            this.switch2.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.switch2.OnBackColor = System.Drawing.Color.SteelBlue;
            this.switch2.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.switch2.Size = new System.Drawing.Size(66, 22);
            this.switch2.TabIndex = 3;
            this.switch2.Text = "switch2";
            this.switch2.UseVisualStyleBackColor = true;
            this.switch2.CheckedChanged += new System.EventHandler(this.switch2_CheckedChanged);
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.button3.Location = new System.Drawing.Point(257, 301);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Time Per move";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(242, 240);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button4
            // 
            this.button4.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.button4.Location = new System.Drawing.Point(12, 301);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 357);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.switch2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.switch1);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Switch switch1;
        private Label label2;
        private Switch switch2;
        private Button button3;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private Button button4;
    }
}