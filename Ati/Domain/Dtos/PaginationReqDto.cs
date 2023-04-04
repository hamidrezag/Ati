using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Domain.Dtos
{
    public class PaginationReqDto
    {

        [Required]
        [DefaultValue(10)]
        public int PageSize { get; set; } = 10;

        [Required]
        [DefaultValue(1)]
        public int PageNumber { get; set; } = 1;

        [Required]
        [DefaultValue(false)]
        public bool AscSort { get; set; } = false;

        [DefaultValue("Id")]
        public string SrtField { get; set; } = "Id";
    }
}
