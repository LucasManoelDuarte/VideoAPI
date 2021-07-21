using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoAPI.Models
{
    public class Video
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo Titulo não pode ultrapassar 100 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Descricao é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo Titulo não pode ultrapassar 100 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo Url é obrigatório")]
        [Url(ErrorMessage = "URL inválida!")]
        public string Url { get; set; }
    }
}
