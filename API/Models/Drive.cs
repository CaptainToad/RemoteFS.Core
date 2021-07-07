using System;
using System.IO;

namespace API.Models
{
    public class Drive
    {
        public Drive(DriveInfo driveInfo)
        {
            Name = driveInfo.Name;
            Format = driveInfo.DriveFormat;
            Label = driveInfo.VolumeLabel;
            RootDirectory = driveInfo.RootDirectory.FullName;
            TotalSpace = driveInfo.TotalSize;
            FreeSpace = driveInfo.TotalFreeSpace;
        }

        public string Name { get; set; }
        public double FreeSpace { get; set; }
        public double TotalSpace { get; set; }
        public float PercentFree
        {
            get
            {
                var freeSpace = 0f;

                if (TotalSpace > 0 && FreeSpace > 0)
                {
                    freeSpace = (float)(FreeSpace / TotalSpace) * 100;
                }

                return freeSpace;
            }
        }
        public string Type { get; set; }
        public string Format { get; set; }
        public string RootDirectory { get; set; }
        public string Label { get; set; }
    }
}
