﻿namespace Lab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CamSelect = new System.Windows.Forms.ComboBox();
            this.Shot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(519, 592);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CamSelect
            // 
            this.CamSelect.FormattingEnabled = true;
            this.CamSelect.Location = new System.Drawing.Point(563, 20);
            this.CamSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CamSelect.Name = "CamSelect";
            this.CamSelect.Size = new System.Drawing.Size(304, 21);
            this.CamSelect.TabIndex = 1;
            // 
            // Shot
            // 
            this.Shot.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold);
            this.Shot.Location = new System.Drawing.Point(661, 544);
            this.Shot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Shot.Name = "Shot";
            this.Shot.Size = new System.Drawing.Size(129, 58);
            this.Shot.TabIndex = 2;
            this.Shot.Text = "Shot";
            this.Shot.UseVisualStyleBackColor = true;
            this.Shot.Click += new System.EventHandler(this.Shot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 609);
            this.Controls.Add(this.Shot);
            this.Controls.Add(this.CamSelect);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox CamSelect;
        private System.Windows.Forms.Button Shot;
    }
}

