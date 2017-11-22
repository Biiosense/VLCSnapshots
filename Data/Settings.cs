using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [JsonObject(MemberSerialization.Fields)]
    public class Settings
    {

        private string snapshotsFolderPath;
        private string dataFilePath;

        public Settings() { }

        public Settings(string snapshotsFolderPath, string dataFilePath)
        {
            this.snapshotsFolderPath = snapshotsFolderPath;
            this.dataFilePath = dataFilePath;
        }

        public string SnapshotsFolderPath { get => snapshotsFolderPath; set => snapshotsFolderPath = value; }
        public string DataFilePath { get => dataFilePath; set => dataFilePath = value; }


        public override string ToString()
        {
            return "Snapshots Folder Path : " + snapshotsFolderPath + "\n" +
                "Data File Path " + dataFilePath + "\n";
                
        }

    }
}
