import axios from 'axios';

axios.defaults.baseURL="http://localhost:5025/";

export async function getAllGifts(){
   
        return await axios.get('api/Gift')
        .then((response) => {
            return response.data
        })
        .catch((error) => {
            console.log(error) 
        });
}

export async function getGiftByID (giftId){

    return await axios.get(`api/Gift/${giftId}`)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function addGift (gift){
  let emptyGift = {
    Name: gift.Name,
    Price: gift.Price,
    CategoryId:gift.CategoryId,
    DonorId:gift.DonorId,
    Image: gift.Image,

  }
   
    return await axios.post('api/Gift', emptyGift)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function deleteGift(giftId){   
   
    axios.delete(`api/Gift?id=${giftId}`)
        .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
};

export async function updateGift(gift){   
 
  let emptyGift = {
    Id:gift.id,
    Name: gift.Name,
    Price: gift.Price,
    CategoryId:gift.CategoryId,
    DonorId:gift.DonorId,
    Image: gift.Image,
    IsDrawn:gift.IsDrawn
  }
  debugger
   
  return await  axios.put(`api/Gift?id=${emptyGift.Id}`,emptyGift)
      .then(function (response) {
        console.log("response");
      })
      .catch(function (error) {
          console.log(error)
  });
};


export async function getDonor(DonorId) {
  try {
    const response = await axios.get(`api/Donor/${DonorId}`);
    console.log('response', response.data);
    return response.data;
  } 
  catch (error) {
    console.log(error);
    return null; 
  }
}

export async function GetCustomer(GiftId) {
  try {
     
    const response = await axios.get(`api/Gift/GetCustomerBuyGift/${GiftId}`);
    console.log('response', response.data);
    return response.data;
  } 
  catch (error) {
    console.log(error);
    return null; 
  }
}

export async function GetGiftsByCustomer(giftId) {
  try {
     
    const response = await axios.get(`api/Gift/GetGiftsByCustomer/${giftId}`);
    console.log('response', response.data);
    return response.data;
  } 
  catch (error) {
    console.log(error);
    return null; 
  }
}

export async function DoRaffle(giftId){
  try {     
    debugger
    const response = await axios.post(`api/Gift/DoRaffle/${giftId}`);
    console.log('response', response.data);
    return response.data;
  } 
  catch (error) {
    console.log(error);
    return null; 
  }
}
