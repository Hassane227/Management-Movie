import axios, {  type AxiosResponse } from "axios"

let isInterceptorSetup = false
export const setupErrorInterceptor = () => {
    if(!isInterceptorSetup){
        axios.interceptors.response.use(
            (response: AxiosResponse)=> response,
            (error)=>{
                const statusCode = error.response?.status;
                const data = error.response?.data;

                if (!statusCode) {
                    console.log('Network or unknown error');
                    return Promise.reject(error);
                }

                switch (statusCode) {
                    case 400:
                       if(data?.errors)
                       {
                        const modalStateErrors = [];
                        for (const item of data.errors)
                        {
                            const property = item.property;
                            const errorMessages = item.errorMessages;

                            if(property && errorMessages)
                            {
                                modalStateErrors.push(property,errorMessages);
                            }
                        }

                        console.log(modalStateErrors);
                    }
                    break;
                       case 401:
                        console.log('Unauthorized');
                        break;
                    case 404:
                        console.log('Not found');
                        break;
                        case 403:
                            console.log('Forbidden');
                            break;
                    default:
                        console.log('Generic error');
                  

                }
                return Promise.reject(error);
            }
        

        )
        isInterceptorSetup = true;
    }


}