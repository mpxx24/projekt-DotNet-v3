using System;
using System.ComponentModel.DataAnnotations;

namespace dotNETv3
{
    class File
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime AddedTime { get; set; }
        public string Extension { get; set; }
    }
}
