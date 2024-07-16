import {  BrowserRouter, Routes, Route } from 'react-router-dom';
import Donors from './componnets/Donors';
import DonorReg from './componnets/DonorReg';
import CustReg from './componnets/CustReg';
import BasicFilterDemo from './componnets/Donors';
import DataViewGifts from './componnets/DataViewGifts'
import Bucket from './componnets/Bucket';
import Login from './componnets/Login'
import ShopingCart from './componnets/ShopingCart'
import Payment from './componnets/Payment'
import ExportReport from './componnets/ExportReport'
function App() {
  return (
<div>
<BrowserRouter>
  <Routes>
      <Route path="/Donors" element={<Donors/>} />
      <Route path="/ShopingCart" element={<ShopingCart />} />
      <Route path="/CustReg" element={<CustReg/>} />
      <Route path="/" element={<Login />} />
      
      <Route path="/Gifts" element={<DataViewGifts />} />
      <Route path="/Payment" element={<Payment />} />
      <Route path="/ExportReport" element={<ExportReport />} />
  </Routes>
  </BrowserRouter>
</div>
  );
}

export default App;
