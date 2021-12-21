using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ZipFile = Ionic.Zip.ZipFile;

namespace TexturePig.MineClient
{
    internal class GetResourcePacks
    {
        public string Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\resourcepacks";
        
        public List<ResourcePackItem> PackList = new List<ResourcePackItem>();

        public GetResourcePacks()
        {
            string[] ListFiles = Directory.GetFiles(Path);
            foreach (string File in ListFiles)
                PackList.Add(ComputeEach(File));
        }

        public ResourcePackItem ComputeEach(string file) 
        {
            string TempFile = System.IO.Path.GetTempPath() + @"\pack.mcmeta";
            try
            {
                using (ZipFile zip = Ionic.Zip.ZipFile.Read(file))
                {
                    ZipEntry e = zip["pack.mcmeta"];
                    e.Extract(System.IO.Path.GetTempPath(), ExtractExistingFileAction.OverwriteSilently);
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.ToString()); }

            var mcMeta = McMeta.FromJson(File.ReadAllText(TempFile));

            ResourcePackItem resourcePackItem =  new ResourcePackItem() 
            {
                Name = System.IO.Path.GetFileName(file).Replace(".zip", string.Empty).Replace("§4", string.Empty).Replace("§l", string.Empty).Replace("§c", string.Empty).Replace("§6", string.Empty).Replace("§e", string.Empty).Replace("§2", string.Empty).Replace("§a", string.Empty).Replace("§b", string.Empty).Replace("§3", string.Empty).Replace("§1", string.Empty).Replace("§9", string.Empty).Replace("§d", string.Empty).Replace("§5", string.Empty).Replace("§f", string.Empty).Replace("§7", string.Empty).Replace("§8", string.Empty).Replace("§0", string.Empty).Replace("! ", string.Empty),
                Version = VersionType.v161to189,
                Location = file,
                bitmap = null,
                Description = mcMeta.Pack.Description
            };
            File.Delete(TempFile);
            return resourcePackItem;
        }
    }
}
