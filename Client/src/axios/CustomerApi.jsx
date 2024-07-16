import axios from 'axios';

axios.defaults.baseURL="http://localhost:5025/";

export async function getAllCustomers(){
    return await axios.get('api/Customer')
        .then((response) => {
            return response
        })
        .catch((error) => {
            console.log(error) 
        });
}

export async function getCustomerByID (customerId){

    return await axios.get(`api/Customer/${customerId}`)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function addCustomer (customer){
  customer.id=0;
  debugger
    return await axios.post('api/Customer/login', customer)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function deleteCustomer(customerId){   
   
    axios.delete(`Customer${customerId}`)
        .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
};

export async function updateCustomer(customerId){   
   
    axios.put(`api/Customer/${customerId}`)
        .then(function (response) {
        })
        .catch(function (error) {
            console.log(error)
        });
};

export async function getAllPurchases(purchasId){
  return await axios.get(`api/Customer/${purchasId}`)
      .then((response) => {
          return response
      })
      .catch((error) => {
          console.log(error) 
      });
}
export async function AddToBucket(giftId,customerId){
  
  return await axios.post(`api/Customer/bucket?giftId=${giftId}&CustumrId=${customerId}`)
      .then((response) => {
          return response
      })
      .catch((error) => {
          console.log(error) 
      });
}
