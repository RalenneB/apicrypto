using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apicrypto.Dtos.Comment
{
    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be 3 chars at least")]
        [MaxLength(250, ErrorMessage = "Title must be under 250 chars")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Content must be 3 chars at least")]
        [MaxLength(250, ErrorMessage = "Content must be under 250 chars")]

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}