using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Entities
{
    public class Article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int ApiId { get; set; }

        public bool IsFolder { get; set; }

        public int RowVer { get; set; }

        [StringLength(255)]
        [Index]
        public string Title { get; set; }

        [StringLength(255)]
        public string TitleId { get; set; }

        public string Body { get; set; }
    }

}
