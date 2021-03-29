using System;
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

namespace WorkingWithFileSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileSystemWatcher fsw;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //// To Brouse Files and Folders:

            //DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");

            //Console.WriteLine("Folders:");
            //foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            //{
            //    Console.WriteLine(dirInfo.Name);
            //}

            //Console.WriteLine("\nFiles:");

            //foreach (FileInfo fi in dir.GetFiles())
            //{
            //    Console.WriteLine(fi.Name);
            //}


            // Monitoring File System

            // 1. Create instance of FileSystemWatcher.
            fsw = new FileSystemWatcher(@"C:\Test");

            // 2. Set the FileSystemWatcher properties.
            fsw.IncludeSubdirectories = true;
            fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.LastWrite;

            // 3. Add the Changed event handler.
            fsw.Changed += new FileSystemEventHandler(fsw_Changed);


            // 4.Start monitoring.
            fsw.EnableRaisingEvents = true;


        }

        private void fsw_Changed(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();

            // Write a path of a changed file to the console.
            Console.WriteLine(e.ChangeType + " : " + e.FullPath);
        }
    }
}
