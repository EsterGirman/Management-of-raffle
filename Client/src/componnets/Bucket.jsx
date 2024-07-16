import React, { useState, useEffect } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { Button } from 'primereact/button';
import { Tag } from 'primereact/tag';
//import { getAllPurchases } from '../axios/PurchaseApi';
import { getAllPurchases } from '../axios/CustomerApi';
import { Menubar } from 'primereact/menubar';

export default function Bucket() {
    const [purchases, setpurchases] = useState(null);
    const [customerId, setCustomerId]=useState(0);
    useEffect(() => {
        setpurchases(getAllPurchases(customerId))
    }, []);

    const formatCurrency = (value) => {
        return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
    };

    const imageBodyTemplate = (purchase) => {
        return <img src={`https://primefaces.org/cdn/primereact/images/purchase/${purchase.gift.image}`} alt={purchase.image} className="w-6rem shadow-2 border-round" />;
    };

    const priceBodyTemplate = (purchase) => {
        return formatCurrency(purchase.gift.price);
    };

    const header = (
        <div className="flex flex-wrap align-items-center justify-content-between gap-2">
            <span className="text-xl text-900 font-bold">purchases</span>
            <Button icon="pi pi-refresh" rounded raised />
        </div>
    );
    const footer = `In total there are ${purchases ? purchases.length : 0} purchases.`;


    const items = [
        { label: 'Home', icon: 'pi pi-home' ,url: '/Login'},
        { label: 'Donors', icon: 'pi pi-users' ,url: '/Donors'},
        { label: 'Gifts', icon: 'pi pi-gift',url: '/Gifts' }
      ];






    return (
        <div className="card">
            <DataTable value={purchases} header={header} footer={footer} tableStyle={{ minWidth: '60rem' }}>
                <Column field="name" header="Name"></Column>
                <Column header="Image" body={imageBodyTemplate}></Column>
                <Column field="price" header="Price" body={priceBodyTemplate}></Column>
                <Column field="category" header="Category"></Column>
                <div className="card">
            <Menubar model={items} />
        </div> 
            </DataTable>
        </div>
    );
}

