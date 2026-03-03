import type { AxiosResponse } from "axios"
import type { MovieDto } from "../models/movieDto"
import type { GetMovieReponse } from "../models/getMovieReponse"
import axios from "axios"
import { API_BASE_URL } from "../Config"
import type { GetMovieByIdResponse } from "../models/getMovieByIdResponse"
 const apiConnector = {
    getMovies : async(): Promise<MovieDto[]>=>{

        try {
            const response: AxiosResponse<GetMovieReponse> =
            await axios.get(`${API_BASE_URL}/movies`)
            
            const movies = response.data.movieDtos.map(movie => ({
                ...movie,
                createDate: movie.createDate?.slice(0, 10)  ??""

            }
            ));

            return movies;
            
        } catch (error) {

                 console.log('Error fetching movies:', error);
                 throw error
            
        }
    },


    createMovie: async (movie: MovieDto): Promise<void> => {
    
            await axios.post<number>(`${API_BASE_URL}/movies`,movie);
            
       
    },

    editMovie: async (movie : MovieDto):Promise<void> =>
    {
      try {
        await axios.put<number>(`${API_BASE_URL}/movies/${movie.id}`,movie);
        
      } catch (error) {
        
        console.log('Error editing movie:',error);
        throw error
        
      }

    },

    deleteMovie: async (movieId: number): Promise<void> =>
    {
        try {

            await axios.delete(`${API_BASE_URL}/movies/${movieId}`);
            
            
        } catch (error) {
            console.log('Error deleting movie:',error);
            throw error
            
        }
    },


getMovieById: async (movieId: string): Promise<MovieDto | undefined> =>
    {
        try {
            const response: AxiosResponse<GetMovieByIdResponse> = 
            await axios.get<GetMovieByIdResponse>(`${API_BASE_URL}/movies/${movieId}`);

            return response.data.movieDto;
            
        } catch (error) {
            console.log('Error fetching movie by id:',error);
            throw error

            
        }
    }


    
}

export default apiConnector;