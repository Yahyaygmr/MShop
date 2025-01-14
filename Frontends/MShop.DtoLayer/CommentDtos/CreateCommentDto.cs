﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.DtoLayer.CommentDtos
{
    public class CreateCommentDto
    {
        public string? ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string ProductId { get; set; }
    }
}
