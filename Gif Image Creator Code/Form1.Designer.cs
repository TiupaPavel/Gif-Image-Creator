using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using Nito.AsyncEx;


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
            button3.Location = new Point(17, 26);
            button3.Name = "button3";
            button3.Size = new Size(120, 39);
            button3.TabIndex = 9;
            button3.Text = "Open Image";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonSelectImages_Click;
            // 
            // button2
            // 
            button2.Location = new Point(181, 26);
            button2.Name = "button2";
            button2.Size = new Size(120, 39);
            button2.TabIndex = 6;
            button2.Text = "Save Image";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonCreateGif_Click;
            // 
            // button5
            // 
            button5.Location = new Point(17, 71);
            button5.Name = "button5";
            button5.Size = new Size(120, 39);
            button5.TabIndex = 11;
            button5.Text = "Creator";
            button5.UseVisualStyleBackColor = true;
            button5.Click += aboutButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(181, 71);
            button1.Name = "button1";
            button1.Size = new Size(120, 39);
            button1.TabIndex = 5;
            button1.Text = "Reset Image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonResetImages_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(17, 135);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(284, 16);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 12;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(progressBar1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button3);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(324, 169);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Paint += groupBox1_Paint;
            groupBox1.Enter += groupBox1_Enter;
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
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 24);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click_1;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(114, 24);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 193);
            Controls.Add(groupBox1);
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

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creator: PAVELLORDS", "About the Program");
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
                        MessageBox.Show("GIF file has been successfully created!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error when saving GIF file: {ex.Message}", "Save Error");
                    }
                }
            }
            catch (MagickException ex)
            {
                if (!IsDisposed)
                {
                    MessageBox.Show($"Error when creating GIF file: {ex.Message}", "Creation Error");
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
                MessageBox.Show("Select at least one image to create a GIF file.");
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
                        MessageBox.Show("GIF file has been successfully created!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error when saving GIF file: {ex.Message}", "Save Error");
                    }
                }
            }
            catch (MagickException ex)
            {
                if (!IsDisposed)
                {
                    MessageBox.Show($"Error when creating GIF file: {ex.Message}", "Creation Error");
                }
            }
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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрыть приложение
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
    }
}