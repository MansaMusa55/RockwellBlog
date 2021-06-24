﻿using Microsoft.AspNetCore.Http;
using RockwellBlog.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RockwellBlog.Models
{
    public class Post
    {
        /// <summary>
        /// Primary key of the Post
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Foreign key to the blog that is the parent of this post
        /// </summary>
        public int BlogId { get; set; }
        /// <summary>
        /// The title of the post
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Title { get; set; }
        /// <summary>
        /// A breif intro
        /// </summary>
        [Required]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Abstract { get; set; }
        //The main content of the post
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// When the post was created
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }
        /// <summary>
        /// This contains a value is the post was updated
        /// </summary>
        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }
        /// <summary>
        /// This is an interanl filed used to route to the details action
        /// </summary>
        public string Slug { get; set; }
        /// <summary>
        /// Identifies the state of the post
        /// </summary>
        [Required]
        [Display(Name = "Publish State")]
        public PublishState PublishState { get; set; }

        /// <summary>
        /// Byte array of the image
        /// </summary>
        public byte[] ImageData { get; set; }
        /// <summary>
        /// Content type of the image
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// This is the file type (i.e jpg/png, etc)
        /// </summary>
        [NotMapped]
        [Display(Name = "Choose Post Image")]
        public IFormFile ImageFile { get; set; }


        //Navigational properties
        public virtual Blog Blog { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}