using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Data.Models
{
    /// <summary>
    /// Project model.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Project id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
