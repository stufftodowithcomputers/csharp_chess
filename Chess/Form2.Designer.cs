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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.switch1.Location = new System.Drawing.Point(866, 43);
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Turn Timer";
            // 
            // switch2
            // 
            this.switch2.AutoSize = true;
            this.switch2.Location = new System.Drawing.Point(866, 126);
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(732, 859);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Hall of Fame";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(507, 859);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 50);
            this.button2.TabIndex = 5;
            this.button2.Text = "Leaderboard";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.button3.Location = new System.Drawing.Point(12, 880);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Return";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 921);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.switch2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.switch1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(960, 960);
            this.MinimumSize = new System.Drawing.Size(960, 960);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Switch switch1;
        private Label label2;
        private Switch switch2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}