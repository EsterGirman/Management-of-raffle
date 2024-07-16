import React, { useState, useEffect, useRef } from 'react';
import { useNavigate } from 'react-router';
import {  BrowserRouter, Routes, Route  } from 'react-router-dom';
import { getAllGifts,deleteGift, getDonor,addGift,updateGift,GetCustomer,DoRaffle } from '../axios/GiftApi';
import { Button } from 'primereact/button';
import { DataView, DataViewLayoutOptions } from 'primereact/dataview';
import { Rating } from 'primereact/rating';
import { Tag } from 'primereact/tag';
import { classNames } from 'primereact/utils';
import { InputText } from 'primereact/inputtext';
import { Dialog } from 'primereact/dialog'; 
import { Dropdown } from 'primereact/dropdown';
import {getAllDonors} from '../axios/DonorApi';
import { AddToBucket } from '../axios/CustomerApi';
import {getAllCategories} from '../axios/CategoryApi'
import { Messages } from 'primereact/messages';
import { Menubar } from 'primereact/menubar';
export default function DataViewGifts() { 
let emptyObject={
  id:0,
  name:"",
  price:null,
  Image:"",
  categoryId:"",
  donorId:"",
  donorName:""
}
    const [visible, setVisible] = useState(false);
    const [gifts, setgifts] = useState([]);
    const [donors, setDonors] = useState([]);
    const [giftWithDonor, setGiftWithDonor] = useState([]);
    const [layout, setLayout] = useState('grid');
    const [GiftDialog, setGiftDialog] = useState(false);
    const [giftEdit, setGiftEdit] = useState(emptyObject);
    const [giftAdding, setGiftAdding] = useState(emptyObject);
    const [DonorToDel, setDonorToDel] = useState(0);
    const [deleteGiftDialog, setDeleteGiftDialog] = useState(false);
    const [gift, setGift] = useState(emptyObject);
    const [addOrUpdate, setAddOrUpdate] = useState(false);
    const [customers,setCustomers]=useState([]); 
    const [showMessage, setShowMessage] = useState(false);
    const [categories, setCategories] = useState([]); 
    const [expanded, setExpanded] = useState(false); 
    const [expandedD, setExpandedD] = useState(false); 
    const [winnerName, setWinnerName] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);   
    const navigate = useNavigate();
    const customerId=useRef(1)
    const hasCustomers=useRef([])
    const nameEdit=useRef("")
    const DonorEdit=useRef("")
    const imageEdit=useRef("")
    const priceEdit=useRef("")
    const CategoryEdit=useRef("")
    const donorId=useRef("")
    const Drawn=useRef(false)
    const IsManager=useRef(false)
    const msgs = useRef(null);

    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false) } /></div>;
    useEffect(() => {
        getGifts();
    }, []);
    const handleDropdownToggle = () => {
      setExpanded(!expanded);
    };
    const handleDropdownToggleD = () => {
      setExpandedD(!expandedD);
    };
  //   useEffect(() => {
  //  if( donors.length>0)
  //  {
  //   console.log(gifts);
  //       if(gifts!=null){
  //       const a=[];
  //       gifts.forEach(x=>{
  //       const donorDetails= donors.find(d=>d.id==x.donorId)
  //       setCategories(getAllCategories())
  //        
  //     const newObject = {
  //       id: x.id,
  //       name: x.name,
  //       price: x.price,
  //       Image: x.image,
  //       Category: x.categoryId,
  //       donorId: x.donorId, 
  //       donorName:donorDetails.lastName
  //     };
  //     setGiftWithDonor(giftWithDonor => [...giftWithDonor, newObject]);
  //       })
  //         };
          
  //  }
  // }, [donors]);
  useEffect(() => {
    let val = Number(localStorage.getItem('Customer')) || 0;
if(val==1111){
  IsManager.current=true
}
else{
  IsManager.current=false
}
    const fetchData = async () => {
      if (donors.length > 0) {
        console.log(gifts);
        if (gifts !== null) {
          const updatedCategories = await getAllCategories();
          setCategories(updatedCategories.data)
          const updatedGiftWithDonor = gifts.map((gift) => {
            const donorDetails = donors.find((d) => d.id === gift.donorId);
            return {
              id: gift.id,
              name: gift.name,
              price: gift.price,
              Image: gift.image,
              IsDrawn:gift.isDrawn ,
              Category: gift.categoryId,
              donorId: gift.donorId,
              donorName: donorDetails.lastName
            };
          });
  
          // setCategories(updatedCategories);
          setGiftWithDonor(updatedGiftWithDonor);
        }
      }
    };
  
    fetchData();
  }, [donors, gifts]);

    const getGifts = async () => {
        let d =[]
        d= await getAllGifts();
        setgifts(d)
        debugger
        const donnor=await getAllDonors()
        setDonors(donnor)
      }
      const getCustomers=async(gift)=>{
        return await GetCustomer(gift.id) 
      }
    const actionBodyTemplate = (rowData) => {
      return (<>
       
       {showByers(rowData)}

        <React.Fragment> <Button icon="pi pi-users" className="p-button-rounded" onClick={()=>{Raffle(rowData)}}></Button>
          <Button
            icon="pi pi-pencil"
            rounded
            outlined
            className="mr-2"
            onClick={() => editGift(rowData)}
            />
          <Button
            icon="pi pi-trash"
            rounded
            outlined
            severity="danger"
            onClick={() => confirmDeleteDonor(rowData)}
          />
        </React.Fragment></>
      );
    };
    const confirmDeleteDonor =async (gift) => {
       await deleteGift(gift.id)
       const d = await getAllGifts();
        setgifts(d);
        // refreshPage()
    };
    const showByers=(gift)=> {  
      return (
          <div className="card flex justify-content-center">
              <Button label="Show buyers" icon="pi pi-external-link" onClick={() => getBuyers(gift)} />
              <Dialog visible={visible} maximizable style={{ width: '50vw' }} onHide={() => {if (!visible) return; setVisible(false); }}>
              <div> <h1>Buyers List:</h1> {customers? customers?.map(c => ( <div key={c.id}> <p>{c.customerId}</p>  </div> )) :
              <p>No buyers found</p> } </div>
              </Dialog>
          </div>
      )}
const getBuyers=async(gift)=>{

  const b=await getCustomers(gift)
  setCustomers(b);
  setVisible(true)
}

    const editGift1 = () => {
      debugger
      gift.id=giftEdit.id
      gift.Name=nameEdit.current
      gift.Price=priceEdit.current
      gift.CategoryId=CategoryEdit.current.id
      gift.Image=imageEdit.current
      gift.DonorId=DonorEdit.current.id
      gift.IsDrawn=Drawn.current
      updateGift(gift)
      Drawn.current=false;
    }; 
    const editGift = (rowData) => {
      setGiftEdit({ ...rowData });
       setGiftDialog(true);
       setAddOrUpdate(false)
     };
    const HideEditDialog = (rowData) => {
      setGiftDialog(false);
    };
    const BeforeAddToBucket=(rowData)=>{
    AddToBucket(rowData.id,customerId.current)
    setShowMessage(true)
    }

    const Raffle = async (rowData) => {
      debugger
      try {
        if(Drawn.current==false){
        const winner = await DoRaffle(rowData.id);
        setWinnerName(winner.customerId);
        setIsModalOpen(true);
        Drawn.current=true;
        editGift1(gift)
      }
        else {          
          alert("The gift was drawn");          
        }
      } catch (error) {
        console.log(error);
      }
    };
    const items = [
      { label: 'Home', icon: 'pi pi-home' ,url: '/Login'},
      { label: 'Donors', icon: 'pi pi-users' ,url: '/Donors'},
      { label: 'Gifts', icon: 'pi pi-gift',url: '/Gifts' }
    ];
    const closeModal = () => {
      setIsModalOpen(false);
    };
    const listItem = (gift, index) => {
      debugger
      //thereIsCustomer(gift)

        return (          
            <div className="col-12" key={gift.id}>
                <div className={classNames('flex flex-column xl:flex-row xl:align-items-start p-4 gap-4', { 'border-top-1 surface-border': index !== 0 })}>
                    <img className="w-9 sm:w-16rem xl:w-10rem shadow-2 block xl:block mx-auto border-round" src={`/Pictures${gift.image}`} alt={gift.name} />
                    <div className="flex flex-column sm:flex-row justify-content-between align-items-center xl:align-items-start flex-1 gap-4">
                        <div className="flex flex-column align-items-center sm:align-items-start gap-3">
                            <div className="text-2xl font-bold text-900">{gift.name}</div>
                            <div className="text-2xl font-bold">{gift.donorName}</div>
                            <div className="flex align-items-center gap-3">
                                <span className="flex align-items-center gap-2">
                                    <i className="pi pi-tag"></i>
                                    <span className="font-semibold">{gift.category}</span>
                                    {gift.IsDrawn? <span className="font-semibold">the gift is drawn</span>:<></>}

                                </span>                              
                            </div>
                        </div>
                        <div className="flex sm:flex-column align-items-center sm:align-items-end gap-3 sm:gap-2">
                            <span className="text-2xl font-semibold">${gift.price}</span>
                            {IsManager.current?actionBodyTemplate(gift): <Button icon="pi pi-shopping-cart" className="p-button-rounded" onClick={()=>{BeforeAddToBucket(gift)}}></Button>}
                            
                        </div>
                    </div>
                </div>
            </div>
        );
    };
   
    const gridItem = (gift) => {
      debugger
      //thereIsCustomer(gift)

        return (
            <div className="col-12 sm:col-6 lg:col-12 xl:col-4 p-2" key={gift.id}>
                <div className="p-4 border-1 surface-border surface-card border-round">
                    <div className="flex flex-wrap align-items-center justify-content-between gap-2">
                        <div className="flex align-items-center gap-2">
                            <i className="pi pi-tag"></i>
                            <span className="font-semibold">{gift.category}</span>
                            {gift.IsDrawn? <span className="font-semibold">the gift is drawn</span>:<></>}
                        </div>                     
                    </div>
                    <div className="flex flex-column align-items-center gap-3 py-5">
                        <img className="w-9 shadow-2 border-round" src={`/Pictures${gift.image}`} alt={gift.name} />
                        <div className="text-2xl font-bold">{gift.name}</div>
                        <div className="text-2xl font-bold">donor: {gift.donorName}</div>
                    </div>
                    <div className="flex align-items-center justify-content-between">
                        <span className="text-2xl font-semibold">${gift.price}</span> 
                        {IsManager.current?actionBodyTemplate(gift): <Button icon="pi pi-shopping-cart" className="p-button-rounded" onClick={()=>{BeforeAddToBucket(gift)}}></Button>}
                       
                    </div>
                </div>
            </div>
        );
    };
    const addingGift = () => {
      gift.Name=nameEdit.current
      gift.Price=priceEdit.current
      gift.CategoryId=CategoryEdit.current.Id
      gift.Image=imageEdit.current
      gift.DonorId=donorId.current
      addGift(gift)
    }

    const giftDialogFooter = (
      <React.Fragment>
        <Button label="Cancel" icon="pi pi-times" outlined onClick={HideEditDialog}/>
        {addOrUpdate?<Button label="Save" icon="pi pi-check" onClick={addingGift}/>
        : <Button label="Save" icon="pi pi-check" onClick={editGift1} />}
      </React.Fragment>
    );
    const itemTemplate = (gift, layout, index) => {
        if (!gift) {
            return;
        }
        if (layout === 'list') return listItem(gift, index);
        else if (layout === 'grid') return gridItem(gift);
    };

    const addG = () => {
      setAddOrUpdate(true)
      setGiftDialog(true);
    };

    const listTemplate = (gifts, layout) => {
      debugger
        return <div className="grid grid-nogutter">{gifts ? gifts.map((gift, index) => itemTemplate(gift, layout, index)) : <></>} </div>;
    };
    // function refreshPage(){ 
    // window.location.reload(); 
    // }
    const hideDialog = () => {
      setGiftDialog(false);
    };

    const validate = (data) => {
      let errors = {};

      if (!data.name) {
          errors.name = 'Name is required.';
      }
      if (!data.Price) {
          errors.Lastname = 'LastName is required.';
      }
      return errors;
  };

    const header = () => {
        return (
            <div className="flex justify-content-end">
                <DataViewLayoutOptions layout={layout} onChange={(e) => setLayout(e.value)} />
            </div>
        );
    };
    return (
        <div className="card">
           <div className="card">
            <Menubar model={items} />
        </div> 
            {IsManager.current?<Button label="Add Gift" severity="help" onClick={()=>addG()}  style={{ minWidth: '12rem' }}/> :""}          
           {IsManager.current?"":<Button label="Shopping cart" severity="help" onClick={()=>navigate('/ShopingCart',{replace:false})}  style={{ minWidth: '12rem' }}/>  } 
            <Dialog visible={showMessage} onHide={() => setShowMessage(false)} position="top" footer={dialogFooter} showHeader={false} breakpoints={{ '960px': '80vw' }} style={{ width: '30vw' }}>
              <div className="flex align-items-center flex-column pt-6 px-3">
                  <i className="pi pi-check-circle" style={{ fontSize: '5rem', color: 'var(--green-500)' }}></i>
                  <h5>Added successfully</h5>
                  <p style={{ lineHeight: 1.5, textIndent: '1rem' }}>
                  The item has been successfully added to the cart
                  </p>
              </div>
            </Dialog>
            <DataView value={giftWithDonor} listTemplate={listTemplate} layout={layout} header={header()} validate={validate}/>
            <Dialog
                visible={GiftDialog}
                style={{ width: '32rem' }}
                breakpoints={{ '960px': '75vw', '641px': '90vw' }}
                header="Gift Details"
                modal
                className="d-fluid"
                footer={giftDialogFooter}
                onHide={hideDialog}
              >
            <div className="formgrid grid">
              <div className="field col">
                <label htmlFor="FirstName" className="font-bold">
                  Name
                </label>
                <InputText
                  id="Name"
                  defaultValue={giftEdit.name}
                  onBlur={(e) => nameEdit.current=e.target.value}
                  mode="currency"
                  currency="USD"
                  locale="en-US"
                />
              </div>
              <div className="field col">
                <label htmlFor="price" className="font-bold">
                  Price
                </label>
                <InputText
                  id="price"
                  defaultValue={giftEdit.price}
                  onBlur={(e) => priceEdit.current=e.target.value}
                  mode="currency"
                  currency="USD"
                  locale="en-US"
                />
              </div>
             
              <div className="field col">
                <label htmlFor="Category" className="font-bold">
                  
                </label>
                <div>
            <div
              style={{ cursor: 'pointer' }}
              onClick={()=>handleDropdownToggle()}
            >
        {expanded ? '▼' : '▶️'} Categories
      </div>
      {expanded? <ul>
          {categories.map((category) => {
            return(
           <Button key={category}  onClick={()=>{CategoryEdit.current=category}}> {category.name}</Button>)
          })}
        </ul>:<></>
      }
        </div>

        </div><br></br>
        <div className="field col">
          <label htmlFor="donorId" className="font-bold">
         
          </label>
          
          <div>
          <div
            style={{ cursor: 'pointer' }}
            onClick={handleDropdownToggleD}
          >
            {expandedD ? '▼' : '▶️'} Donors
          </div>
          {expandedD? <ul>
          {donors.map((d) => {
            return(
           <Button key={d}  onClick={()=>{DonorEdit.current=d}}> {d.FirstName}</Button>)
          })}
        </ul>:<></>
      }
        </div>
              </div>
              <div className="field col">
                <label htmlFor="Image" className="font-bold">
                  Image
                </label>
                <InputText
                  id="Image"
                  defaultValue={giftEdit.Image}
                  onBlur={(e) => imageEdit.current=e.target.value}/>
              </div>
            </div>
        </Dialog>
        {isModalOpen && (
        <div className="modal">
          <div className="modal-content">
            <h2>Raffle Winner</h2>
            <p>Name: {winnerName}</p>
            <button onClick={closeModal}>Close</button>
          </div>
        </div>
      )}
  </div>
    )
}



///////////////////////////////

// const GiftsTable = ({ gifts }) => {
//   const [sortByPrice, setSortByPrice] = useState(false);

//   const handleSort = () => {
//     setSortByPrice(!sortByPrice);
//   };

//   const sortedGifts = gifts.sort((a, b) => {
//     if (sortByPrice) {
//       return a.price - b.price;
//     } else {
//       return a.id - b.id; // מיון ברירת מחדל לפי מזהה
//     }
//   });

//   return (
//     <table>
//       <thead>
//         <tr>
//           <th>שם</th>
//           <th>מחיר</th>
//           <th><button onClick={handleSort}>מיון לפי מחיר</button></th>
//         </tr>
//       </thead>
//       <tbody>
//         {sortedGifts.map((gift) => (
//           <tr key={gift.id}>
//             <td>{gift.name}</td>
//             <td>{gift.price}</td>
//           </tr>
//         ))}
//       </tbody>
//     </table>
//   );
// };

// export default GiftsTable;

// סינון מהמבוקש ביותר-
// import React, { useState, useEffect } from 'react';

// const GiftsTable = ({ gifts, purchases }) => {
//   const [sortBySales, setSortBySales] = useState(false);

//   const handleSort = () => {
//     setSortBySales(!sortBySales);
//   };

//   // useEffect לחישוב מספר המכירות לכל מתנה
//   useEffect(() => {
//     const giftSales = {};
//     for (const purchase of purchases) {
//       const giftId = purchase.giftId;
//       giftSales[giftId] = giftSales[giftId] || 0;
//       giftSales[giftId]++;
//     }

//     const sortedGiftsWithSales = gifts.map((gift) => {
//       return {
//         ...gift,
//         salesCount: giftSales[gift.id] || 0,
//       };
//     });

//     setGiftsWithSales(sortedGiftsWithSales);
//   }, [gifts, purchases]);

//   const sortedGifts = giftsWithSales.sort((a, b) => {
//     if (sortBySales) {
//       return b.salesCount - a.salesCount; // יורד
//     } else {
//       return a.id - b.id; // מיון ברירת מחדל לפי מזהה
//     }
//   });

//   return (
//     <table>
//       <thead>
//         <tr>
//           <th>שם</th>
//           <th>מחיר</th>
//           <th>מספר רכישות</th>
//           <th><button onClick={handleSort}>מיון לפי מכירות</button></th>
//         </tr>
//       </thead>
//       <tbody>
//         {sortedGifts.map((gift) => (
//           <tr key={gift.id}>
//             <td>{gift.name}</td>
//             <td>{gift.price}</td>
//             <td>{gift.salesCount}</td>
//           </tr>
//         ))}
//       </tbody>
//     </table>
//   );
// };

// export default GiftsTable; 
