﻿using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace Gif_Image_Creator
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            groupBox1 = new GroupBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(255, 192, 192);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(270, 134);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Paint += groupBox1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(192, 64, 0);
            label1.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 192, 192);
            label1.Location = new Point(33, 15);
            label1.Name = "label1";
            label1.Size = new Size(227, 96);
            label1.TabIndex = 0;
            label1.Text = "Select at least \r\none image to \r\ncreate a GIF file.";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(294, 157);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form5";
            Text = "Select Image";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            // Створюємо градієнтний кисть
            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                groupBox1.ClientRectangle,
                Color.Pink, // Верхній колір (білий)
                Color.Orange, // Нижній колір (зелений)
                LinearGradientMode.Vertical); // Вказуємо вертикальний градієнт

            // Використовуючи кисть, заповнюємо прямокутник градієнтом
            e.Graphics.FillRectangle(gradientBrush, groupBox1.ClientRectangle);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
    }
}