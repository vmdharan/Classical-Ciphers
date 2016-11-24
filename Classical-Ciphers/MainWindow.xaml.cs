﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Classical_Ciphers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Buffer to store the data from the input file.
        private byte[] inputData;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            // Show the 'open file' dialog.
            var dialog_SelectFile = new System.Windows.Forms.OpenFileDialog();
            var retval = dialog_SelectFile.ShowDialog();

            try
            {
                switch(retval)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        // Get the picked file.
                        var pickedFile = dialog_SelectFile.FileName;
                        tbPickedFile.Text = pickedFile;
                        tbPickedFile.ToolTip = pickedFile;

                        // Read data from the picked file into the buffer.
                        inputData = File.ReadAllBytes(tbPickedFile.Text);

                        // Get the file size
                        lblFileSizeBytes.Content = inputData.Length.ToString();
                        break;

                    case System.Windows.Forms.DialogResult.Cancel:
                    default:
                        break;
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        private void btnEncode_Click(object sender, RoutedEventArgs e)
        {
            if(int.Parse(lblFileSizeBytes.Content.ToString()) > 0)
            {
                //encodeCaesar();
                ROT13 cipher2 = new ROT13();
                cipher2.encode(inputData);
                File.WriteAllBytes(tbPickedFile.Text + ".enc", cipher2.data);
            }
        }

        private void btnDecode_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(lblFileSizeBytes.Content.ToString()) > 0)
            {
                //decodeCaesar();
                ROT13 cipher2 = new ROT13();
                cipher2.decode(inputData);
                File.WriteAllBytes(tbPickedFile.Text + ".dec", cipher2.data);
            }
        }

        private void encodeCaesar()
        {
            Caesar cipher1 = new Caesar();
            cipher1.encode(inputData);
            File.WriteAllBytes(tbPickedFile.Text + ".enc", cipher1.data);
        }

        private void decodeCaesar()
        {
            Caesar cipher1 = new Caesar();
            cipher1.decode(inputData);
            File.WriteAllBytes(tbPickedFile.Text + ".dec", cipher1.data);
        }
    }
}
