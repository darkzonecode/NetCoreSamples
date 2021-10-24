using System;
using System.IO;
using System.IO.Compression;
using System.IO.IsolatedStorage;
using System.Text;

namespace ReadWriteFilesAndStrems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            #region Reading and Writing Text Files
            TextReader tr = File.OpenText(@"C:\Windows\win.ini");
            Console.WriteLine(tr.ReadToEnd());
            tr.Close();

            TextWriter tw = File.CreateText(@"C:\Test\output.txt");
            tw.WriteLine("Hello World!");
            tw.Close();

            #endregion


            #region Reading and Writing Binary Files

            // Write 10 integers.
            FileStream fs = new FileStream(@"C:\Test\data.bin", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < 11; i++)
            {
                bw.Write(i);
            }
            bw.Close();
            fs.Close();

            //Read the data.
            fs = new FileStream(@"C:\Test\data.bin", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine(br.ReadInt32());
            }
            br.Close();
            fs.Close();

            #endregion


            #region Reading and Writing Strings.

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            sw.Write("Hello ");
            sw.Write("World!");
            sw.Close();

            StringReader sr = new StringReader(sb.ToString());
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();

            #endregion

            #region Using a Memory Stream

            // Create a MemoryStream object.
            MemoryStream ms = new MemoryStream();

            // Create a Strin=mWriter object to allow writing strings to MemoryStream.

            StreamWriter sw1 = new StreamWriter(ms);

            // Write to the StreamWriter and MemoryStream.
            sw1.WriteLine("Hello World from StreamWriter!");

            // Flush the content.
            sw1.Flush();

            ms.WriteTo(File.Create(@"C:\Test\memory.txt"));

            sw1.Close();
            ms.Close();

            #endregion

            #region Using Compresed stream

            GZipStream gzOut = new GZipStream(File.Create(@"C:\Test\data.zip"), CompressionMode.Compress);

            StreamWriter sw2 = new StreamWriter(gzOut);

            for (int i = 0; i < 1000; i++)
            {
                sw2.Write("Hello World!");
            }
            sw2.Close();
            gzOut.Close();

            GZipStream gzIn = new GZipStream(File.OpenRead(@"C:\Test\data.zip"), CompressionMode.Decompress);

            StreamReader sr2 = new StreamReader(gzIn);

            Console.WriteLine(sr2.ReadToEnd());

            sr2.Close();
            gzIn.Close();



            #endregion

            #region Using Isolated Storage

            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream isoFile = new IsolatedStorageFileStream("myFile.txt", FileMode.Create, isoStore);

            StreamWriter streamWriter = new StreamWriter(isoFile);

            streamWriter.WriteLine("This Test is written to a isolated storage file");

            streamWriter.Close();

            isoFile.Close();

            isoStore.Close();

            // Read Content from Isolated Storage.

            IsolatedStorageFile isoStoreRead = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream isoFileRead = new IsolatedStorageFileStream("myFile.txt", FileMode.Open, isoStoreRead);

            StreamReader streamReader = new StreamReader(isoFileRead);

            string content = streamReader.ReadLine();

            streamReader.Close();

            isoFileRead.Close();

            isoStoreRead.Close();

            Console.WriteLine(content);

            #endregion
        }
    }
}
