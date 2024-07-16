import React, { useState, useEffect, useRef,useMountEffect } from 'react';
import {  BrowserRouter, Routes, Route  } from 'react-router-dom';
import { FilterMatchMode, FilterOperator } from 'primereact/api';
import { DataTable } from 'primereact/datatable';
import { useNavigate } from 'react-router';
import { Column } from 'primereact/column';
import { InputText } from 'primereact/inputtext';
import { MultiSelect } from 'primereact/multiselect';
import { Button } from 'primereact/button'; //
import { Dialog } from 'primereact/dialog'; //
import { Menubar } from 'primereact/menubar';
import { GetAllDonates,getAllDonors, getDonorByID, addDonor, deleteDonor, getAllGiftsByDonor,updateDonor } from '../axios/DonorApi';
import CustReg from './CustReg';

export default function BasicFilterDemo() {

  const navigate = useNavigate();
  const [filters, setFilters] = useState({
    firstName: { value: null, matchMode: FilterMatchMode.STARTS_WITH },
    lastName: { value: null, matchMode: FilterMatchMode.STARTS_WITH },
    phone: { value: null, matchMode: FilterMatchMode.STARTS_WITH },
  });

  const [addDB, setaddDB] = useState(false);
  const [gifts, setGifts] = useState([]);
  const [visible, setVisible] = useState(false);
  const [Donor, setDonor] = useState([]);
  const [Donors, setDonors] = useState([]);
  const [DonorToDel, setDonorToDel] = useState(0);
  const [loading, setLoading] = useState(false);
  const [globalFilterValue, setGlobalFilterValue] = useState('');
  const [representatives] = useState([]);
  const [selectedDonors, setSelectedDonors] = useState(false); //
  const [deleteDonorDialog, setDeleteDonorDialog] = useState(false);
  const [DonorDialog, setDonorDialog] = useState(false);
  const FirstNameEdit=useRef("")
  const LastNameEdit=useRef("") 
  const PhoneEdit=useRef("")  

  const DonorEdit=async()=>{
   const d={
    id:Donor.id,
     firstName:FirstNameEdit.current,
      lastName:LastNameEdit.current,
      phone:PhoneEdit.current ,
      email:Donor.email,
      password:Donor.password

    }
      setDonor({...d})
      console.log("updateDonor1");   
     const i= await updateDonor(d);
     debugger
     if(i.name=='AxiosError')
     {

     }
       
     //refreshPage() 
  }

  const toast = useRef(null); //
  const dt = useRef(null); //
  const getDonors = async () => {
    const d = await getAllDonors();
    setDonors(d);
  }
  useEffect(() => {
     getDonors();
  }, []);
const addDonors=async()=>{
  // Donor.id=0;
      Donor.firstName=FirstNameEdit.current
      Donor.lastName=LastNameEdit.current
      Donor.phone=PhoneEdit.current
      await addDonor(Donor)
}
  const hideDialog = () => {
    setDonorDialog(false);
  };
 
  const saveDonor = async() => {
    debugger
    if (FirstNameEdit&&LastNameEdit&&PhoneEdit) {
      if(addDB){
        await DonorEdit()
        //refreshPage()
        }
    else{
        await addDonors()
        // refreshPage()
    }
    hideDialog()
    }
    else{
      alert("fill all the field")
    } 
  };

  const DonorDialogFooter = (
    <React.Fragment>
      <Button label="Cancel" icon="pi pi-times" outlined onClick={hideDialog} />
      <Button label="Save" icon="pi pi-check" onClick={saveDonor} />
    </React.Fragment>
  );

  const hideDeleteDonorDialog = () => {
    setDeleteDonorDialog(false);
  };

  const hideDeleteDonorsDialog = () => {
    setDeleteDonorDialog(false);
  };
  const findIndexById = (id) => {
    let index = -1;
    for (let i = 0; i < Donors.length; i++) {
      if (Donors[i].Id === id) {
        index = i;
        break;
      }
    }
    return index;
  };
  
//לא משנה את הפרטים
const editDonor = (Donor) => {
   
  setaddDB(true)
   debugger
  setDonor({ ...Donor });
  setDonorDialog(true); 
};

const confirmDeleteDonor = (Donor) => {
  setDonorToDel(Donor.id)
  setDeleteDonorDialog(true);
};

const deleteDonors = async() => {
  await deleteDonor(DonorToDel);
  await getAllDonors();  
  hideDeleteDonorDialog()
  //refreshPage()
}

const actionBodyTemplate = (rowData) => {
  return (
    <React.Fragment>
      <Button
        icon="pi pi-pencil"
        rounded
        outlined
        className="mr-2"
        onClick={() => editDonor(rowData)}
      />
      <Button
        icon="pi pi-trash"
        rounded
        outlined
        severity="danger"
        onClick={() => confirmDeleteDonor(rowData)}
      />
      <Button
        icon="pi pi-gift"
        rounded
        outlined
        className="mr-2"
        onClick={() => {getGifts(rowData)}}
      />
    </React.Fragment>
  );
};
const getgift = async(donor) => {

  const gifts =await GetAllDonates(donor.id)
  setGifts(gifts)
}
const addD = () => {
  setaddDB(false)
  setDonorDialog(true); 
  setSelectedDonors(true);
};

// function refreshPage(){ 
//   window.location.reload(); 
// }
const items = [
  { label: 'Home', icon: 'pi pi-home' ,url: '/Login'},
  { label: 'Donors', icon: 'pi pi-users' ,url: '/Donor'},
  { label: 'Gifts', icon: 'pi pi-gift',url: '/Gifts' }
];
  const getGifts=async(gift)=>{
    getgift(gift)
    // setGift(getCustomers(gift));
    setVisible(true)
  }
const deleteDonorDialogFooter = (
  <React.Fragment>
    <Button
      label="No"
      icon="pi pi-times"
      outlined
      onClick={hideDeleteDonorDialog}
    />
    <Button
      label="Yes"
      icon="pi pi-check"
      severity="danger"
      onClick={async()=>
        {
           
        deleteDonors()
        getDonors()
        }}
    />
  </React.Fragment>
);
return (
  <div className="Donor">
    <br></br><br></br>
    {selectedDonors?<CustReg></CustReg>:<>
    <span><div className="card flex flex-wrap justify-content-center gap-3">  
      <div className="card">
            <Menubar model={items} />
        </div>       
  <Button label="Add donor" severity="help" onClick={()=>addD()}  style={{ minWidth: '12rem' }}/>
 
</div></span><br></br><br></br>
    {Donors ? <DataTable value={ Donors } paginator rows={10} dataKey="id" filters={filters} filterDisplay="row" //selection={}
      globalFilterFields={['firstName', 'lastName', 'phone']} emptyMessage="No donor found.">
      <Column header="firstName" field="firstName" filterField="firstName" filter filterPlaceholder="Search by name" style={{ minWidth: '12rem' }} />
      <Column header="lastName" field='lastName' filterField="lastName" style={{ minWidth: '12rem' }} filter filterPlaceholder="Search by last name" />
      <Column header="Phone" filterField="phone" field='phone' style={{ minWidth: '12rem' }} filter filterPlaceholder="Search by phone"/>
      <Column body={actionBodyTemplate} exportable={false} style={{ minWidth: '12rem' }}></Column>
      
    </DataTable> : <></>}
    <Dialog visible={visible} maximizable style={{ width: '50vw' }} onHide={() => {if (!visible) return; setVisible(false); }}>
          <div> <h1>Donates List:</h1> {gifts.data ? gifts.data.map(g => ( <div key={g.id}> <p>{g.name}</p>  </div> )) :
          <p>No Donate found</p> } </div>
          </Dialog>
    <Dialog
      visible={DonorDialog}
      style={{ width: '32rem' }}
      breakpoints={{ '960px': '75vw', '641px': '90vw' }}
      header="Donor Details"
      modal
      className="d-fluid"
      footer={DonorDialogFooter}
      onHide={hideDialog}
    >

      <div className="formgrid grid">
        <div className="field col">
          <label htmlFor="FirstName" className="font-bold">
            FirstName
          </label>
          <InputText
            id="FirstName"
            defaultValue={Donor.firstName}
            onBlur={(e) => FirstNameEdit.current=e.target.value}
            mode="currency"
            currency="USD"
            locale="en-US"
          />
        </div>
        <div className="field col">
          <label htmlFor="LastName" className="font-bold">
            LastName
          </label>
          <InputText
            id="LastName"
            defaultValue={Donor.lastName}
            onBlur={(e) => LastNameEdit.current=e.target.value}
            mode="currency"
            currency="USD"
            locale="en-US"
          />
        </div>
        <div className="field col">
          <label htmlFor="Phone" className="font-bold">
            Phone
          </label>
          <InputText
            id="Phone"
            defaultValue={Donor.phone}
            onBlur={(e) => PhoneEdit.current=e.target.value}/>
        </div>
      </div>
    </Dialog>

    <Dialog
      visible={deleteDonorDialog}
      style={{ width: '32rem' }}
      breakpoints={{ '960px': '75vw', '641px': '90vw' }}
      header="Confirm"
      modal
      footer={deleteDonorDialogFooter}
      onHide={hideDeleteDonorsDialog}
    >
      <div className="confirmation-content">Are you sure you want to delete the selected Donor?
        <i
          className="pi pi-exclamation-triangle mr-3"
          style={{ fontSize: '2rem' }}
        />
      </div>
    </Dialog>
    </>
}
  </div>

);
}


