using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentService.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<test2>? Tests2 { get; set; } = null;




    }
}
