using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts.Dtos
{
    public record MovieDto(
        int Id,
        string? Title,
        string? Description,
        string? Category);
   
}
