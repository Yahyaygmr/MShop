using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Comment.Context;
using MShop.Comment.Entities;
using System.Runtime.CompilerServices;

namespace MShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(CommentContext commentContext) : ControllerBase
    {
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = commentContext.UserComments.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            commentContext.UserComments.Add(userComment);
            commentContext.SaveChanges();

            return Ok("Yorum Başarıyla Keydedildi");
        }
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            commentContext.UserComments.Update(userComment);
            commentContext.SaveChanges();

            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = commentContext.UserComments.Find(id);

            commentContext.UserComments.Remove(value);
            commentContext.SaveChanges();
            return Ok("Yorum Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult CommentList(int id)
        {
            var value = commentContext.UserComments.Find(id);
            return Ok(value);
        }
    }
}
