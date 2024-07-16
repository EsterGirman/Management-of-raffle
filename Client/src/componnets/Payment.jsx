import React, { useEffect, useState,useRef } from 'react';
import { useNavigate } from 'react-router';
import { Form, Field } from 'react-final-form';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Dropdown } from 'primereact/dropdown';
import { Password } from 'primereact/password';
import { Checkbox } from 'primereact/checkbox';
import { Dialog } from 'primereact/dialog';
import { Divider } from 'primereact/divider';
import { classNames } from 'primereact/utils';
import {addCustomer} from '../axios/CustomerApi'
import { useMountEffect } from 'primereact/hooks';
import { Messages } from 'primereact/messages';
import './register.css';
import { addDonor } from '../axios/DonorApi';
import { Menubar } from 'primereact/menubar';
export default  function Login () {
    const [showMessage, setShowMessage] = useState(false);
    const [formData, setFormData] = useState({});
    const navigate = useNavigate();
    const number=useRef("")
    const validity=useRef("") 
    const CVC=useRef("") 
    const msgs = useRef(null);

    const validate = (data) => {
        let errors = {};

        if (!data.number) {
            errors.number = 'Number is required.';
        }
        // else if(data.number!=16){
        //     errors.number = 'The credit number is invalid.';
        // }
        if (!data.validity) {
            errors.validity = 'Validity is required.';
        }
        // else if(!/^(0[1-9]|1[0-2])([0-9]{2})$/.test(data.validity)){
        //     errors.validity = 'Validity is required.';
        // }
        if (!data.CVC) {
            errors.CVC = 'The validity is incorrect.';
        }
        else if(!/^\d{3}$/.test(data.CVC)){
            errors.CVC = 'The CVC is incorrect.';
        }
        return Object.keys(errors).length === 0 ? null : errors;
    };

    const onSubmit = (data, form) => {
        setFormData(data);       
        setShowMessage(true);
        form.restart();
    };

    const isFormFieldValid = (meta) => !!(meta.touched && meta.error);
    const getFormErrorMessage = (meta) => {
        return isFormFieldValid(meta) && <small className="p-error">{meta.error}</small>;
    };
    const items = [
        { label: 'Home', icon: 'pi pi-home' ,url: '/Login'},
        { label: 'Donors', icon: 'pi pi-users' ,url: '/Donors'},
        { label: 'Gifts', icon: 'pi pi-gift',url: '/Gifts' }
      ];
    const submit=(data)=>{
        const errors = validate(data);
    if (!errors && msgs.current) {
        msgs.current.clear();
        msgs.current.show({ sticky: true, severity: 'success', summary: 'Success', detail: 'The payment was collected', closable: false });
    }
    }
    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false) } /></div>;
    

    return (
        <div className="form-demo">

            <div className="flex justify-content-center">
                <div className="card">
                    <h5 className="text-center">Payment</h5>
                    <div className="card">
            <Menubar model={items} />
        </div> 
                    <Form onSubmit={onSubmit} initialValues={{ number: '', validity: '', CVC: ''}} validate={validate} render={({ handleSubmit }) => (
                        <form onSubmit={handleSubmit} className="p-fluid">
                            <Field name="number" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <InputText id="number" {...input} autoFocus className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>number.current=e.target.value} />
                                        <label htmlFor="name" className={classNames({ 'p-error': isFormFieldValid(meta) })}>Credit card number*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                            <Field name="validity" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <InputText id="validity" {...input} autoFocus className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>validity.current=e.target.value} />
                                        <label htmlFor="name" className={classNames({ 'p-error': isFormFieldValid(meta) })}>validity*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                             <Field name="CVC" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <InputText id="CVC" {...input} autoFocus className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>CVC.current=e.target.value} />
                                        <label htmlFor="name" className={classNames({ 'p-error': isFormFieldValid(meta) })}>CVC*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />     
                         <Button onClick={submit} type="submit" label="Payment" className="mt-2" />
                        <Messages ref={msgs}></Messages> 
                        </form>
                        
                    )} />
                </div>
            </div>
        </div>
    );
}

