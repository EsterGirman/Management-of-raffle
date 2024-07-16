import React, { useState, useEffect, useRef } from 'react';
import { DataTable } from 'primereact/datatable';
import { Column } from 'primereact/column';
import { getAllWinners } from '../axios/WinnersApi';
import { Toast } from 'primereact/toast';
import { Button } from 'primereact/button';
import { Toolbar } from 'primereact/toolbar';
import { IconField } from 'primereact/iconfield';
import { InputIcon } from 'primereact/inputicon';
import { InputText } from 'primereact/inputtext';
import { getAllGifts, DoRaffle } from '../axios/GiftApi';
import { getAllCustomers } from '../axios/CustomerApi';
import { Menubar } from 'primereact/menubar';
export default function ExportReport() {
    let emptyWinner = {
        id: null,
        customer: null,
        gift: null
    };

    const [winners, setWinners] = useState();
    const [gifts, setGifts] = useState();
    const [costumers, setCostumers] = useState();
    const [winnerDialog, setWinnerDialog] = useState(false);
    const [winner, setWinner] = useState(emptyWinner);
    const [submitted, setSubmitted] = useState(false);
    const [globalFilter, setGlobalFilter] = useState(null);
    const toast = useRef(null);
    const dt = useRef(null);
    const [AllTables,setAllTables] = useState([]);
    useEffect(() => {
        getWinners()
    }, []);
    useEffect(() => {
        getCustomers()
    }, []);
    useEffect(() => {
        getGifts()
    }, []);
    const getWinners = async () => {
        let w = []
        w = await getAllWinners();
        setWinner(w);
    }
    const getCustomers = async () => {
        let w = []
        w = await getAllCustomers();
        setCostumers(w.data);
    }
    const getGifts = async () => {
        let w = []
        w = await getAllGifts();
        setGifts(w);
    }
    const findIndexById = (id) => {
        let index = -1;

        for (let i = 0; i < winners.length; i++) {
            if (winners[i].id === id) {
                index = i;
                break;
            }
        }
        return index;
    };
    const items = [
        { label: 'Home', icon: 'pi pi-home' ,url: '/Login'},
        { label: 'Donors', icon: 'pi pi-users' ,url: '/Donors'},
        { label: 'Gifts', icon: 'pi pi-gift',url: '/Gifts' }
      ];
    const exportCSV = () => {
        dt.current.exportCSV();
    };
    useEffect(() => {
        if (gifts && winner && costumers&&!AllTables.length>0) {
            winner.map((w) => {
                const g = gifts.find((e) => w.giftId == e.id);
                const c = costumers.find((e) => w.customerId == e.id);
                const x = { "gift": g.name, "costumer": c.firstName + " " + c.lastName };
               setAllTables(e => [...e, x]);
            })
        }
    }, [winner, gifts, costumers])
    const header = (
        <div className="flex flex-wrap gap-2 align-items-center justify-content-between">
            <h4 className="m-0">Manage winners</h4>
            <IconField iconPosition="left">
                <InputIcon className="pi pi-search" />
                <InputText type="search" onInput={(e) => setGlobalFilter(e.target.value)} placeholder="Search..." />
            </IconField>
        </div>
    );
    const rightToolbarTemplate = () => {
        return <Button label="Export" icon="pi pi-upload" className="p-button-help" onClick={exportCSV} />;
    };

    return (
        <div>
            <Toast ref={toast} />
            <div className="card">
                <Toolbar className="mb-4" right={rightToolbarTemplate}></Toolbar>
                <div className="card">
            <Menubar model={items} />
        </div> 
                <DataTable ref={dt} value={AllTables}
                    paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                    currentPageReportTemplate="Showing {first} to {last} of {totalRecords} winners" globalFilter={globalFilter} header={header}>
                    <Column field="gift" header="Gift" sortable style={{ minWidth: '12rem' }}></Column>
                    <Column field="costumer" header="Winner" sortable style={{ minWidth: '16rem' }}></Column>
                </DataTable>
            </div>
        </div>
    );
}