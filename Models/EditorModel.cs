using MessagePack;
using System.Data;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Assessment4Apr17.Models
{
    public class EditorModel
    {
        [Key]
        public int DocumentID { get; set; }
        public string Author { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentContent { get; set; }
    }
}
