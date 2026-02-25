using Mapster;
using Movies.Contracts.Responses;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Mappings
{
     public class MapingConfig
    {

        public static void configure()
        {

            TypeAdapterConfig<List<Movie>, GetMoviesResponse>.NewConfig()
                .Map(dest => dest.MovieDtos, src => src);

            TypeAdapterConfig<Movie, GetMovieByIdResponse>.NewConfig()
                .Map(dest => dest.MovieDto, src => src);

        }

    }
}
