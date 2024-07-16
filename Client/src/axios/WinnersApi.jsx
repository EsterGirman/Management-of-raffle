import axios from 'axios';

axios.defaults.baseURL="http://localhost:5025/";
export async function getAllWinners(){
    return await axios.get('api/Winner')
        .then((response) => {
            return response.data
        })
        .catch((error) => {
            console.log(error) 
        });
}

export async function addWinner (winner){
    return await axios.post('api/Winner', winner)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}