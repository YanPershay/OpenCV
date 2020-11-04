namespace Webcam
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
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.picStream = new System.Windows.Forms.PictureBox();
            this.btnStream = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            this.btnLaplas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStream)).BeginInit();
            this.SuspendLayout();
            // 
            // picOutput
            // 
            this.picOutput.Location = new System.Drawing.Point(475, 32);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(408, 261);
            this.picOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOutput.TabIndex = 0;
            this.picOutput.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(634, 328);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(119, 29);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Origin Webcam";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // picStream
            // 
            this.picStream.Location = new System.Drawing.Point(33, 32);
            this.picStream.Name = "picStream";
            this.picStream.Size = new System.Drawing.Size(382, 261);
            this.picStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStream.TabIndex = 2;
            this.picStream.TabStop = false;
            // 
            // btnStream
            // 
            this.btnStream.Location = new System.Drawing.Point(33, 328);
            this.btnStream.Name = "btnStream";
            this.btnStream.Size = new System.Drawing.Size(120, 27);
            this.btnStream.TabIndex = 3;
            this.btnStream.Text = "Canny Webcam";
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Click += new System.EventHandler(this.btnCanny_Click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(159, 328);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(126, 29);
            this.btnSobel.TabIndex = 4;
            this.btnSobel.Text = "Sobel Webcam";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);
            // 
            // btnLaplas
            // 
            this.btnLaplas.Location = new System.Drawing.Point(291, 328);
            this.btnLaplas.Name = "btnLaplas";
            this.btnLaplas.Size = new System.Drawing.Size(124, 29);
            this.btnLaplas.TabIndex = 5;
            this.btnLaplas.Text = "Laplas Webcam";
            this.btnLaplas.UseVisualStyleBackColor = true;
            this.btnLaplas.Click += new System.EventHandler(this.btnLaplas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 490);
            this.Controls.Add(this.btnLaplas);
            this.Controls.Add(this.btnSobel);
            this.Controls.Add(this.btnStream);
            this.Controls.Add(this.picStream);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picOutput);
            this.Name = "Form1";
            this.Text = "Camera";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStream)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox picStream;
        private System.Windows.Forms.Button btnStream;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.Button btnLaplas;
    }
}

