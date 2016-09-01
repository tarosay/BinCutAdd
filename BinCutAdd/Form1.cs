using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCutAdd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filename = textBox1.Text;

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs);

            int i = 0;
            long a = 1;
            while (a > 0)
            {
                byte[] b = r.ReadBytes(250000000);
                //byte[] b = r.ReadBytes(500000000);
                //byte[] b = r.ReadBytes(1000000000);
                a = (long)b.Length;
                if (a <= 0)
                {
                    break;
                }
                Debug.WriteLine(b.Length.ToString() + "バイト読み込みました");
                tbxMes.Text += b.Length.ToString() + "バイト読み込みました\r\n";
                GC.Collect();
                
                tbxMes.SelectionStart = tbxMes.Text.Length;
                //テキストボックスにフォーカスを移動
                tbxMes.Focus();
                //カレット位置までスクロール
                tbxMes.ScrollToCaret();

                Application.DoEvents();


                FileStream fw = new FileStream(filename + "." + i.ToString("00"), FileMode.Create);
                BinaryWriter w = new BinaryWriter(fw);

                w.Write(b);
                fw.Close();
                Debug.WriteLine(b.Length.ToString() + "切り出しました");
                tbxMes.Text += b.Length.ToString() + "バイト切り出しました\r\n";
                GC.Collect();
                
                tbxMes.SelectionStart = tbxMes.Text.Length;
                //テキストボックスにフォーカスを移動
                tbxMes.Focus();
                //カレット位置までスクロール
                tbxMes.ScrollToCaret();
                
                Application.DoEvents();

                b = null;
                GC.Collect();
                GC.Collect();
                i++;
            }
            fs.Close();

            Debug.WriteLine("切り出しを終了しました");
            tbxMes.Text += "切り出しを終了しました\r\n";

            tbxMes.SelectionStart = tbxMes.Text.Length;
            //テキストボックスにフォーカスを移動
            tbxMes.Focus();
            //カレット位置までスクロール
            tbxMes.ScrollToCaret();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = tbxAname0.Text;
            int s = int.Parse(textBox3.Text);
            string rfname = "";

            //FileStream fw = new FileStream(Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename), FileMode.Create);
            FileStream fw = new FileStream(filename, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fw);

            for (int i = 0; i < s; i++)
            {
                //rfname = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + "." + i.ToString("00");
                rfname = filename + "." + i.ToString("00");
                FileStream fs = new FileStream(rfname, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(fs);

                byte[] b = r.ReadBytes(250000000);

                fs.Close();

                //        Debug.WriteLine(b.Length.ToString() + "バイト読み込みました");
                tbxMes.Text += rfname + "から、" + b.Length.ToString() + "バイト読み込みました\r\n";
                GC.Collect();
                
                tbxMes.SelectionStart = tbxMes.Text.Length;
                //テキストボックスにフォーカスを移動
                tbxMes.Focus();
                //カレット位置までスクロール
                tbxMes.ScrollToCaret();

                Application.DoEvents();

                w.Write(b);

                tbxMes.Text += b.Length.ToString() + "バイト書き足しました\r\n";
                GC.Collect();

                tbxMes.SelectionStart = tbxMes.Text.Length;
                //テキストボックスにフォーカスを移動
                tbxMes.Focus();
                //カレット位置までスクロール
                tbxMes.ScrollToCaret();

                Application.DoEvents();

                b = null;
                GC.Collect();
                GC.Collect();
            }
            fw.Close();
            
            //Debug.WriteLine("切り出しを終了しました");
            tbxMes.Text += "結合を終了しました\r\n";

            tbxMes.SelectionStart = tbxMes.Text.Length;
            //テキストボックスにフォーカスを移動
            tbxMes.Focus();
            //カレット位置までスクロール
            tbxMes.ScrollToCaret();

        }
    }
}
