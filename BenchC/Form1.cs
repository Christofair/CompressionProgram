using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace BenchC
{
    public partial class Form1 : Form
    {
        bool poinformowano = false;
        bool gotowe = false;
        Compression compression;
        public Form1()
        {
            InitializeComponent();
            this.compression = new Compression();
            compression.ProgressChanged += this.ChangeProgressBar;
        }

        private void input_btn_Click(object sender, EventArgs e)
        {
            // Otwórz okno dialogowe z możliwością wyboru pliku lub folderu.
            FileDialog fd = new OpenFileDialog();
            fd.ValidateNames = false;
            fd.CheckFileExists = false;
            fd.CheckPathExists = true;
            fd.FileName = "wybór folderu";
            if(!poinformowano)
                MessageBox.Show("Aby wybrać folder wpisz nazwę nieistniejącego pliku.");
            if (fd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(fd.FileName))
                {
                    compression.SetInputPath(fd.FileName);
                    input_textbox.Text = fd.FileName;
                }
                else
                {
                    string fp = Path.GetDirectoryName(fd.FileName);
                    compression.SetInputPath(fp, true);
                    input_textbox.Text = fp;
                }
                poinformowano = true;
                gotowe = false;
            }
        }

        private void output_btn_Click(object sender, EventArgs e)
        {
            FileDialog fd = new SaveFileDialog();
            fd.Filter = "Pliki archiwum | *.7z, *.zip";
            if(fd.ShowDialog() == DialogResult.OK)
            {
                compression.OutputPath = fd.FileName;
                output_textbox.Text = fd.FileName;
                gotowe = false;
            }
        }

        private void spakuj_btn_Click(object sender, EventArgs e)
        {
            if (compression.Ready())
            {
                string k = compression.checkDiversity();
                compression.SetMethodAndFormat(k);
                compression.Compress();
                gotowe = true;
            }
        }

        private void open_dir_btn_Click(object sender, EventArgs e)
        {
            if (!gotowe) return;
            using (Process p = new Process())
            {
                p.StartInfo.FileName = "explorer";
                p.StartInfo.Arguments = Path.GetFullPath(Path.GetDirectoryName(compression.OutputPath));
                p.Start();
            }
        }
        public void ChangeProgressBar(object sender, ProgressChangedEventArgs args)
        {
            progressBar1.Value = args.ProgressPercentage;
        }
    }
    class Compression
    {
        string output_path, input_path;
        bool directory;
        string method, format; // format = ext.
        int progress;

        public event ProgressChangedEventHandler ProgressChanged;

        public Compression()
        {
            output_path = input_path = method = format = string.Empty;
            directory = false;
            progress = 0;
        }
        public void SetInputPath(string value, bool dir = false)
        {
            input_path = value;
            directory = dir;
        }
        public string GetInputPath() { return input_path; }
        public string OutputPath
        {
            set{ output_path = value; }
            get { return output_path;  }
        }
        public bool Ready()
        {
            if (output_path != string.Empty && input_path != string.Empty)
                return true;
            else
                return false;
        }
        public int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    progress = value;
                try { ProgressChanged.Invoke(this, new ProgressChangedEventArgs(Progress, null)); } catch { }
            }
        }
        void SMF(string m, string f)
        {
            method = m;
            format = f;
        }
        public string checkDiversity()
        {
            if(directory)
                return checkDiversity(input_path);
            else
            {
                string ext = Path.GetExtension(input_path);
                if (Regex.IsMatch(ext, "bin|txt"))
                    return "binary, tekst";
                else if (Regex.IsMatch(ext, "jpg|bmp|png"))
                    return "images";
                else if (Regex.IsMatch(ext, "mp3|wav|ogg|mp4|avi|mpg"))
                    return "audio, video";
                else
                    return "bin,txt";
            }
        }
        public string checkDiversity(string dir)
        {
            Hashtable tof = new Hashtable()
            {
                {"bin,txt", false },
                {"audio,video", false},
                {"hybrid", false},
                {"images", false}
            };
            foreach (string file in Directory.EnumerateFiles(dir, "*"))
            {
                string ext = Path.GetExtension(file);
                if (Regex.IsMatch(ext, "bin|txt"))
                {
                    tof["bin,txt"] = true;
                    Console.WriteLine("binary, text");
                }
                else if (Regex.IsMatch(ext, "jpg|bmp|png"))
                {
                    tof["images"] = true;
                    Console.WriteLine("images");
                }
                else if (Regex.IsMatch(ext, "mp3|wav|ogg|mp4|avi|mpg"))
                {
                    tof["audio,video"] = true;
                    Console.WriteLine("audio, video");
                }
                else
                {
                    tof["bin,txt"] = true;
                    Console.WriteLine("brak rozszerzenia np.");
                }
            }
            int count = 0;
            foreach (string b in tof.Keys)
            {
                if ((bool)tof[b] == true) ++count;
            }
            if (count > 1)
            {
                return "hybrid";
            }
            foreach (string dirn in Directory.EnumerateDirectories(dir, "*"))
            {
                try
                {
                    if ((bool)tof[checkDiversity(dirn)] != true)
                    {
                        return "hybrid";
                    }
                }
                catch (KeyNotFoundException exception) { }
            }
            // Sprawdź dla którego klucza jest wartość true i zwróć ten klucz;
            foreach (string b in tof.Keys) if ((bool)tof[b] == true) return b;
            return ""; // brak plików.
        }
        public void SetMethodAndFormat(string kind) 
        {
            if (kind == "images") SMF("LZMA","7z");
            else if(kind =="audio,video") SMF("Deflate","zip");
            else if (kind == "bin,txt") SMF("Deflate","zip");
            else if (kind == "hybrid") SMF("Deflate","zip");
        }
        void SeekProgress(object sender, DataReceivedEventArgs arg)
        {
            if (arg.Data != null)
            {
                Match g = Regex.Match(arg.Data, "\\d{1,3}%");
                if (g.Success)
                {
                    Progress = int.Parse(g.Value.Trim('%'));
                }
            }
        }
        public void Compress()
        {
            Progress = 0;
            string program = "\"C:\\Program Files\\7-Zip\\7z.exe\"";
            string args = "a -m9=" + method + " -bsp2 \"" + Path.ChangeExtension(output_path, format) +
                "\" \"" + input_path + "\"";
            using (Process p = new Process())
            {
                p.StartInfo.FileName = program;
                p.StartInfo.Arguments = args;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.ErrorDataReceived += this.SeekProgress;
                p.Start();
                p.BeginErrorReadLine();
                p.WaitForExit();
                Progress = 100;
            }
        }
    }
}
