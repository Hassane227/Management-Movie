using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts.Requests.Movies
{
    public record CreateMovieRequest(string Title, string Description, string Category);
   
}
