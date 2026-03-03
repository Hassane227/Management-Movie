import { useEffect, useState, type ChangeEvent } from "react";
import {  NavLink, useNavigate, useParams } from "react-router-dom"
import type { MovieDto } from "../../models/movieDto";
import apiConnector from "../../api/apiConnector";
import { Button, Form, Segment } from "semantic-ui-react";

export default function MovieForm() {
 
    const {id} = useParams();
    const navigate = useNavigate();

    const [movie, setMovie] = useState<MovieDto>({
        id:undefined,
        title: '',
        description: '',
        createDate: undefined,
        category: ''
    })
      // utilisation de useEffect hook

      useEffect(()=>{
        if(id)
        {
            apiConnector.getMovieById(id).then(movie=> setMovie(movie!));           
        }

      },[])

      function handleSubmit(){
        if(!movie.id)
        {
            apiConnector.createMovie(movie).then(()=>{
                navigate('/');
            })

        }

        else {
            apiConnector.editMovie(movie).then(()=> navigate('/'));
        }
      }

      function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>){
        const {name, value} = event.target as HTMLInputElement | HTMLTextAreaElement;
        setMovie({...movie, [name]: value});
      }
    
    return (
        <>
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete="off" className='ui invereted form'>
              <Form.Input placeholder="Title" value={movie.title} name="title" onChange={handleInputChange} />
            <Form.Input placeholder="Category" value={movie.category} name="category" onChange={handleInputChange} />
            <Form.TextArea placeholder="Description" value={movie.description} name="description" onChange={handleInputChange} />

            <Button type="submit" positive floated="right"
            content="Submit"/>

            <Button as={NavLink} to="/" floated="right"  content="Cancel" />



            </Form>

        </Segment>
        
        </>
    )
}