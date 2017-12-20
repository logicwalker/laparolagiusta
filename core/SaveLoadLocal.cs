using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.IO;

namespace netretis.core
{
    public class SaveLoadLocal
    {

        // Isostorage is used to maintain the saved geo-location across app sessions
        IsolatedStorageFile isoStore;

        public SaveLoadLocal()
        {
            isoStore = IsolatedStorageFile.GetUserStoreForApplication();
        }


        public bool SaveToIsoStore(string filename, int posToSave)
        {

                      
            string strBaseDir = string.Empty;
            string delimStr = "/";
            char[] delimiter = delimStr.ToCharArray();
            string[] dirsPath = filename.Split(delimiter);

            // Recreate the directory structure
            for (int i = 0; i < dirsPath.Length - 1; i++)
            {
                strBaseDir = System.IO.Path.Combine(strBaseDir, dirsPath[i]);
                isoStore.CreateDirectory(strBaseDir);
            }

            // Remove existing file
            if (isoStore.FileExists(filename))
            {
                isoStore.DeleteFile(filename);
            }

            // Write the file
            using (BinaryWriter bw = new BinaryWriter(isoStore.CreateFile(filename)))
            {
                bw.Write(posToSave);
                bw.Close();
            }
            return true;

        }


        public int LoadFromIsoStore(string filename)
        {

            int posToLoad;

            if (isoStore.FileExists(filename))
            {
                using (BinaryReader br = new BinaryReader(isoStore.OpenFile(filename, FileMode.Open)))
                {
                    // Reconstruct the geo-location class using data read from the data file in isostore

                    if (br.BaseStream.Length == 0)
                        return 0;

                    posToLoad = br.ReadInt16();

                    return (int)posToLoad;

                }
            }

            return 0;
        }

    }
}
