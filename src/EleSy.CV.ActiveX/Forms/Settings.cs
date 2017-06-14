using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace EleSy.CV.ActiveX.Forms
{
    
    public partial class Settings : Form
    {
        private string _distaneEnd;
        private string _distaneNow;
        private string _value;
        private Settings form;
        public string Path { get; set; }

        
        private const string path = @"c:\pathToTag.txt";
     
        public Settings()
        {
            InitializeComponent();
            Path = path;


            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                Try(lines, textBox1,0);
                Try(lines, textBox2,1);
                Try(lines, textBox3,2);
                Try(lines, textBox4,3);
                
            }

        }

        private void Try(string[] lines, TextBox textBox, int count)
        {
            try
            {
                textBox.Text = lines[count];
            }
            catch (Exception)
            {

                textBox.Text = "";
            }
        }
     
 

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {

                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                // Create the file.
                using (var fs = File.Create(path))
                {
                   var info = new UTF8Encoding(true).GetBytes(textBox1.Text + "\r\n" +
                        textBox2.Text + "\r\n" + textBox3.Text + "\r\n" + textBox4.Text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);

                }
              Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
