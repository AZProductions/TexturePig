using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TexturePig.MineClient
{
    internal class ResourcePackItem
    {
        public string Name { get; set; }
        public VersionType Version { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public BitmapSource bitmap { get; set; }
    }
}
