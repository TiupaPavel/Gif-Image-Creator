using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using Nito.AsyncEx;
using Gif_Image_Creator;
using Task_9;
using static System.Windows.Forms.DataFormats;


namespace Task_9
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private List<string> selectedImagePaths = new List<string>();
        private List<string> selectedVideoPaths = new List<string>();

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button3 = new Button();
            button2 = new Button();
            button5 = new Button();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            groupBox1 = new GroupBox();
            button6 = new Button();
            button4 = new Button();
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            openToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 64, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(19, 15);
            button3.Name = "button3";
            button3.Size = new Size(120, 39);
            button3.TabIndex = 9;
            button3.Text = "Open Image";
            button3.UseVisualStyleBackColor = false;
            button3.Click += buttonSelectImages_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 64, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(183, 15);
            button2.Name = "button2";
            button2.Size = new Size(120, 39);
            button2.TabIndex = 6;
            button2.Text = "Save Image";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonCreateGif_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(192, 64, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(19, 60);
            button5.Name = "button5";
            button5.Size = new Size(120, 39);
            button5.TabIndex = 11;
            button5.Text = "Developer";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 64, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(183, 60);
            button1.Name = "button1";
            button1.Size = new Size(120, 39);
            button1.TabIndex = 5;
            button1.Text = "Reset Image";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonResetImages_Click;
            // 
            // progressBar1
            // 
            progressBar1.ForeColor = Color.FromArgb(192, 64, 0);
            progressBar1.Location = new Point(19, 160);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(284, 22);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 12;
            progressBar1.Click += progressBar1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(324, 198);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Paint += groupBox1_Paint;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(192, 64, 0);
            button6.ForeColor = Color.White;
            button6.Location = new Point(183, 105);
            button6.Name = "button6";
            button6.Size = new Size(120, 39);
            button6.TabIndex = 14;
            button6.Text = "Exit";
            button6.UseVisualStyleBackColor = false;
            button6.Click += CloseToolStripMenuItem_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(192, 64, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(19, 105);
            button4.Name = "button4";
            button4.Size = new Size(120, 39);
            button4.TabIndex = 13;
            button4.Text = "Instructions";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button6_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Gif Image Creator";
            notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, closeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(115, 52);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.BackColor = Color.FromArgb(192, 64, 0);
            openToolStripMenuItem.ForeColor = Color.White;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 24);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click_1;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.BackColor = Color.FromArgb(192, 64, 0);
            closeToolStripMenuItem.ForeColor = Color.White;
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(114, 24);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            ClientSize = new Size(348, 222);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Gif Image Creator";
            Load += Form1_Load;
            Resize += Form1_Resize;
            groupBox1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void buttonSelectImages_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Изображения|*.jpg;*.png;*.gif;*.bmp;*.jpeg|Все файлы|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePaths.AddRange(openFileDialog.FileNames);
                }
            }
        }

        private async Task CreateGifAsync(List<string> imagePaths, string outputFilePath)
        {
            try
            {
                using (var gif = new MagickImageCollection())
                {
                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Maximum = imagePaths.Count;
                    });

                    for (int i = 0; i < imagePaths.Count; i++)
                    {
                        using (var image = new MagickImage(imagePaths[i]))
                        {
                            image.AutoOrient();
                            // Дополнительные настройки размера и положения изображения

                            image.AnimationDelay = 100;
                            gif.Add(image.Clone()); // Clone the image before adding
                        }

                        int currentValue = i + 1;
                        progressBar1.Invoke((MethodInvoker)delegate
                        {
                            if (!IsDisposed)
                            {
                                progressBar1.Value = currentValue;
                            }
                        });
                    }

                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        if (!IsDisposed)
                        {
                            progressBar1.Value = progressBar1.Maximum;
                        }
                    });

                    try
                    {
                        await Task.Run(() => gif.Write(outputFilePath, MagickFormat.Gif));
                        Form4 form4 = new Form4();
                        form4.Show();
                    }
                    catch (Exception ex)
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                }
            }
            catch (MagickException ex)
            {
                if (!IsDisposed)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                }
            }
        }

        private async void buttonCreateGif_Click(object sender, EventArgs e)
        {
            if (selectedImagePaths.Count > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "GIF files (*.gif)|*.gif";
                    saveFileDialog.Title = "Select the location to save the GIF file";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputFilePath = saveFileDialog.FileName;

                        await CreateGifAsync(selectedImagePaths, outputFilePath);
                    }
                }
            }
            else
            {
                Form5 form5 = new Form5();
                form5.Show();
            }
        }

        private async Task UpdateProgressBarAsync(int percentage)
        {
            await Task.Run(() =>
            {
                if (!IsDisposed)
                {
                    // Проверка на выход за границы диапазона
                    int newValue = Math.Min(Math.Max(progressBar1.Minimum, percentage), progressBar1.Maximum);

                    // Используйте Invoke для обновления прогресс-бара из другого потока
                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Value = newValue;
                    });
                }
            });
        }

        private void CreateGif(List<string> imagePaths, string outputFilePath)
        {
            try
            {
                using (var gif = new MagickImageCollection())
                {
                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        progressBar1.Maximum = imagePaths.Count;
                    });

                    for (int i = 0; i < imagePaths.Count; i++)
                    {
                        using (var image = new MagickImage(imagePaths[i]))
                        {
                            image.AutoOrient();
                            // Дополнительные настройки размера и положения изображения

                            image.AnimationDelay = 100;
                            gif.Add(image.Clone()); // Clone the image before adding
                        }

                        int currentValue = i + 1;
                        progressBar1.Invoke((MethodInvoker)delegate
                        {
                            if (!IsDisposed)
                            {
                                progressBar1.Value = currentValue;
                            }
                        });
                    }

                    progressBar1.Invoke((MethodInvoker)delegate
                    {
                        if (!IsDisposed)
                        {
                            progressBar1.Value = progressBar1.Maximum;
                        }
                    });

                    try
                    {
                        gif.Write(outputFilePath, MagickFormat.Gif);
                        Form4 form4 = new Form4();
                        form4.Show();
                    }
                    catch (Exception ex)
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                    }
                }
            }
            catch (MagickException ex)
            {
                if (!IsDisposed)
                {
                    Form2 form2 = new Form2();
                    form2.Show();
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private Form1 form1 = null;

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (form1 == null || form1.IsDisposed)
                {
                    form1 = new Form1();
                    form1.FormClosed += (s, args) => form1 = null;
                    form1.Show();
                }
                else
                {
                    form1.WindowState = FormWindowState.Normal;
                    form1.Activate();
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private AsyncContext _asyncContext;

        private void WriteGifFile(MagickImageCollection gif, string outputFilePath)
        {
            // Вместо gif.Write(outputFilePath, MagickFormat.Gif); используем следующий код:
            using (var outputStream = new FileStream(outputFilePath, FileMode.Create))
            {
                //gif.Write(outputStream, MagickFormat.Gif);
            }
        }

        private void buttonResetImages_Click(object sender, EventArgs e)
        {
            selectedImagePaths.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private Button button3;
        private Button button2;
        private Button button5;
        private Button button1;
        private ProgressBar progressBar1;
        private GroupBox groupBox1;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Button button4;
        private Button button6;
    }
}