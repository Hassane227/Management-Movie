import { Outlet, useLocation } from 'react-router-dom';
import './App.css'
import MovieTable from './Components/movies/MovieTable';
import { Container } from 'semantic-ui-react';
import { useEffect } from 'react';
import { setupErrorInterceptor } from './interceptor/axiosinterceptor';

function App() {
  useEffect(() => {
    setupErrorInterceptor();

  },[])
  const location = useLocation();
  return(
    <>
    { location.pathname === '/' ?<MovieTable/>: (
      <Container className="container-style">
                   <Outlet/>
        </Container>
    )
           }
    </>
  )
}

export default App;