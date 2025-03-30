using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("StreamedFiles")]
    public class StreamedFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Status FileStatus { get; set; }
    }
}
