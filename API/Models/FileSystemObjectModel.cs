using System;
using System.IO;

namespace API.Models
{
    public class FileSystemObjectModel
    {
        public FileSystemObjectModel(FileSystemInfo fileSystemInfo)
        {
            Name = fileSystemInfo.Name;
            Exists = fileSystemInfo.Exists;
            Extension = fileSystemInfo.Extension;
            FullName = fileSystemInfo.FullName;
            Created = fileSystemInfo.CreationTime;
            Modified = fileSystemInfo.LastWriteTime;
            Accessed = fileSystemInfo.LastAccessTime;
            IsDirectory = fileSystemInfo.Attributes.HasFlag(FileAttributes.Directory);
            IsReadOnly = fileSystemInfo.Attributes.HasFlag(FileAttributes.ReadOnly);
            IsSystem = fileSystemInfo.Attributes.HasFlag(FileAttributes.System);
            IsHidden = fileSystemInfo.Attributes.HasFlag(FileAttributes.Hidden);
            if (IsDirectory)
            {
                var directoryInfo = fileSystemInfo as DirectoryInfo;

                if (directoryInfo?.Parent is not null)
                {
                    ParentName = directoryInfo.Parent.FullName;
                }
            }
            else
            {
                var fileInfo = fileSystemInfo as FileInfo;

                Size = fileInfo?.Length;
                if (fileInfo?.Directory is not null)
                {
                    DirectoryName = fileInfo.DirectoryName;
                }
            }
        }

        public string Name { get; set; }
        public long? Size { get; set; }
        public bool Exists { get; set; }
        public string Extension { get; set; }
        public string FullName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Accessed { get; set; }
        public bool IsDirectory { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsSystem { get; set; }
        public bool IsHidden { get; set; }
        public string ParentName { get; set; }
        public string DirectoryName { get; set; }
    }
}
