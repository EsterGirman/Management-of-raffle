import axios from 'axios';

axios.defaults.baseURL="http://localhost:5025/";

export async function getAllPurchases(){
    return await axios.get('api/Purchase')
        .then((response) => {
            return response
        })
        .catch((error) => {
            console.log(error) 
        });
}

export async function getPurchaseByID ( PurchaseId){
    return await axios.get(`api/Purchase/${PurchaseId}`)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error){
      console.log(error);
    });
}

export async function addPurchase (purchase){

    return await axios.post('api/Purchase', purchase)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function deletePurchase(PurchaseId){   
   
    axios.delete(`api/Purchase?id=${PurchaseId}`)
        .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
};

export async function updatePurchase(purchaseId){   
   
    axios.put(`api/Purchase/${purchaseId}`)
        .then(function (response) {
        })
        .catch(function (error) {
            console.log(error)
        });
};

export async function payment(purchaseId){   
   
  axios.put(`api/Purchase/payment/${purchaseId}`)
      .then(function (response) {
      })
      .catch(function (error) {
          console.log(error)
      });
};

