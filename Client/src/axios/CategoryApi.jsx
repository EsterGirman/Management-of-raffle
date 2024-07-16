import axios from 'axios';

axios.defaults.baseURL="http://localhost:5025/";

export async function getAllCategories(){
    return await axios.get('api/Category')
        .then((response) => {
            return response
        })
        .catch((error) => {
            console.log(error) 
        });
}

export async function getCategoryByID (categoryId){

    return await axios.get(`api/Category/${categoryId}`)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function addCategory (category){

    return await axios.post('api/Category', category)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function deleteCategory(categoryId){   
   
    axios.delete(`api/Category?id=${categoryId}`)
        .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
};

export async function updateCategory(categoryId){   
   
    axios.put(`api/Category/${categoryId}`)
        .then(function (response) {
        })
        .catch(function (error) {
            console.log(error)
        });
};

