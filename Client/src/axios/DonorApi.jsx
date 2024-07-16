import axios from 'axios';

axios.defaults.baseURL="http://localhost:5025/";
export async function getAllDonors(){
    return await axios.get('api/Donor')
        .then((response) => {
            return response.data
        })
        .catch((error) => {
            console.log(error) 
        });
}

export async function getDonorByID (donorId){
 
    return await axios.get(`api/Donor/${donorId}`)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function addDonor (donor){
  donor.id=0;

    return await axios.post('api/Donor', donor)       
    .then(function (response) {
      debugger
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function deleteDonor(donorId){ 
   await axios.delete(`api/Donor?id=${donorId}`)
        .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
};

export async function updateDonor(Donor){   
  // console.log("succeeddddd");   

  // let emptyDonor = {
  //   Id: null,
  //   FirstName: '',
  //   LastName: '',
  //   Phone: '',
  //   password:'',
  //   Email:''
  // }
  // emptyDonor.Id=Donor.id
   
  // emptyDonor.FirstName=Donor.firstName
  // emptyDonor.LastName=Donor.lastName
  // emptyDonor.Phone=Donor.phone
  // emptyDonor.Email=Donor.email
  // emptyDonor.password=Donor.password;
  debugger
  return await  axios.put(`api/Donor?id=${Donor.id}`,Donor)
    .then(function (response) {
      console.log("response");
    })
    .catch(function (error) {
      console.log(error);
      return error;
       
    });
  };

export async function getAllGiftsByDonor(donorId){
    return await axios.get(`api/Gift/${donorId}`)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
}

export async function GetAllDonates(donorId){
  return await axios.get(`api/Donor/GetAllDonates?id=${donorId}`)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}

