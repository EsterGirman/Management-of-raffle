import { Menubar } from 'primereact/menubar';
import React, { useState, useEffect, useRef } from 'react';
import { useNavigate } from 'react-router';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { payment, deletePurchase, getAllPurchases } from '../axios/PurchaseApi';
import { Button } from 'primereact/button';
import { DataView, DataViewLayoutOptions } from 'primereact/dataview';
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { classNames } from 'primereact/utils';
import { InputText } from 'primereact/inputtext';
import { Dialog } from 'primereact/dialog';
import { Dropdown } from 'primereact/dropdown';
import { GetGiftsByCustomer } from '../axios/GiftApi'
import { addWinner } from '../axios/WinnersApi';

export default function ShopingCart() {

  const [visible, setVisible] = useState(false);
  const [winners, setwinners] = useState([]);
  const [donors, setDonors] = useState([]);
  const [winnerWithDonor, setwinnerWithDonor] = useState([]);
  const [layout, setLayout] = useState('grid');
  const [winnerDialog, setwinnerDialog] = useState(false);
  const [addOrUpdate, setAddOrUpdate] = useState(false);
  const [customers, setCustomers] = useState([]);
  const [showMessage, setShowMessage] = useState(false);
  const [categories, setCategories] = useState([]);
  const [expanded, setExpanded] = useState(false);
  const [expandedD, setExpandedD] = useState(false);
  const navigate = useNavigate();
  const customerId = useRef(5)
  const nameEdit = useRef("")
  const DonorEdit = useRef("")
  const imageEdit = useRef("")
  const priceEdit = useRef("")
  const CategoryEdit = useRef("")
  const donorId = useRef("")
  const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false)} /></div>;
  useEffect(() => {

    getwinners();
  }, []);
  const handleDropdownToggle = () => {
    setExpanded(!expanded);
  };
  const handleDropdownToggleD = () => {
    debugger
    setExpandedD(!expandedD);
  };

  useEffect(() => {
    const fetchData = async () => {
      if (donors.length > 0) {
        console.log(winners);

      }
    };

    fetchData();
  }, [donors, winners]);

  const getwinners = async () => {
    debugger
    let val = Number(localStorage.getItem('Customer2')) || 0;
    var d = await GetGiftsByCustomer(val)
    setwinners(d)

  }
  const items = [
    { label: 'Home', icon: 'pi pi-home' ,url: '/Login'},
    { label: 'Donors', icon: 'pi pi-users' ,url: '/Donors'},
    { label: 'Gifts', icon: 'pi pi-gift',url: '/Gifts' }
  ];
  const actionBodyTemplate = (winner) => {
    const handlePaymentAndAddWinner = async () => {
      await payment();
      await addWinner(winner); // Pass the winner object to addWinner
      navigate('/Payment', {replace: false});
    };
  
    const handleDeletewinner = () => {
      confirmDeleteDonor(winner);
    };
    return (
      <React.Fragment>
        <Button
          icon="pi pi-wallet"
          rounded
          outlined
          className="mr-2"
          onClick={()=>{payment();addWinner(winner);navigate('/Payment',{replace:false})}}
        />
        <Button
          icon="pi pi-trash"
          rounded
          outlined
          severity="danger"
          onClick={() => confirmDeleteDonor(winner)}
        />
      </React.Fragment>
    );
  };

  const confirmDeleteDonor = async (winner) => {
    await deletePurchase(winner.id)

  };



  const HideEditDialog = (rowData) => {
    setwinnerDialog(false);
  };
  // const BeforeAddToBucket=(rowData)=>{


  const listItem = (winner, index) => {
    return (
      <div className="col-12" key={winner.id}>
        <div className={classNames('flex flex-column xl:flex-row xl:align-items-start p-4 gap-4', { 'border-top-1 surface-border': index !== 0 })}>
          <img className="w-9 sm:w-16rem xl:w-10rem shadow-2 block xl:block mx-auto border-round" src={`/Pictures${winner.image}`} alt={winner.name} />
          <div className="flex flex-column sm:flex-row justify-content-between align-items-center xl:align-items-start flex-1 gap-4">
            <div className="flex flex-column align-items-center sm:align-items-start gap-3">
              <div className="text-2xl font-bold text-900">{winner.name}</div>
              <div className="flex align-items-center gap-3">
                <span className="flex align-items-center gap-2">
                  <i className="pi pi-tag"></i>
                  <span className="font-semibold">{winner.category}</span>
                </span>
              </div>
            </div>
            <div className="flex sm:flex-column align-items-center sm:align-items-end gap-3 sm:gap-2">
              <span className="text-2xl font-semibold">${winner.price}</span>
              {actionBodyTemplate(winner)}


            </div>
          </div>
        </div>
      </div>
    );
  };

  const gridItem = (winner) => {
    return (
   
      <div className="col-12 sm:col-6 lg:col-12 xl:col-4 p-2" key={winner.id}> 
        {console.log("gg",winner)}
        <div className="p-4 border-1 surface-border surface-card border-round">
          <div className="flex flex-wrap align-items-center justify-content-between gap-2">
            <div className="flex align-items-center gap-2">
              <i className="pi pi-tag"></i>
              <span className="font-semibold">{winner.category}</span>
            </div>
          </div>
          <div className="flex flex-column align-items-center gap-3 py-5">
            <img className="w-9 shadow-2 border-round" src={`/Pictures${winner.image}`} alt={winner.name} />
            <div className="text-2xl font-bold">{winner.name}</div>
          </div>
          <div className="flex align-items-center justify-content-between">
            <span className="text-2xl font-semibold">${winner.price}</span>
            {actionBodyTemplate(winner)}


          </div>
        </div>
      </div>
    );
  };


  const itemTemplate = (winner, layout, index) => {
    if (!winner) {
      return;
    }
    if (layout === 'list') return listItem(winner, index);
    else if (layout === 'grid') return gridItem(winner);
  };



  const listTemplate = (winners, layout) => {
    return (
      <div className="grid grid-nogutter">
        {winners ? winners.map((winner, index) => itemTemplate(winner, layout, index)) : null}
      </div>
    );
  };
  // function refreshPage(){ 
  // window.location.reload(); 
  // }
  const hideDialog = () => {
    setwinnerDialog(false);
  };



  const header = () => {
    return (
      <div className="flex justify-content-end">
        <DataViewLayoutOptions layout={layout} onChange={(e) => setLayout(e.value)} />
      </div>
    );
  };
  return (
    <>
      <div className="card">

        <DataView value={winners} listTemplate={listTemplate} layout={layout} header={header()} />
      </div>
    </>
  )
}