namespace Kuznetsova
{
    partial class MainScreen
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.RdBxCross = new System.Windows.Forms.RadioButton();
            this.BtnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RdBxCross
            // 
            this.RdBxCross.AutoSize = true;
            this.RdBxCross.Location = new System.Drawing.Point(803, 354);
            this.RdBxCross.Name = "RdBxCross";
            this.RdBxCross.Size = new System.Drawing.Size(51, 17);
            this.RdBxCross.TabIndex = 0;
            this.RdBxCross.TabStop = true;
            this.RdBxCross.Text = "Cross";
            this.RdBxCross.UseVisualStyleBackColor = true;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(803, 403);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 1;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 438);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.RdBxCross);
            this.Name = "MainScreen";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainScreen_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RdBxCross;
        private System.Windows.Forms.Button BtnClear;
    }
}

