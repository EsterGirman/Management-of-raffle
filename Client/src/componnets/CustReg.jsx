import React, { useEffect, useState,useRef } from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from 'react-router-dom';
import { Form, Field } from 'react-final-form';
import { useNavigate } from 'react-router';
import { InputText } from 'primereact/inputtext';
import { Button } from 'primereact/button';
import { Dropdown } from 'primereact/dropdown';
import { Password } from 'primereact/password';
import { Checkbox } from 'primereact/checkbox';
import { Dialog } from 'primereact/dialog';
import { Divider } from 'primereact/divider';
import { classNames } from 'primereact/utils';
import {addCustomer} from '../axios/CustomerApi'
import './register.css';
import { addDonor } from '../axios/DonorApi';

export default  function Register () {

    const [showMessage, setShowMessage] = useState(false);
    const [formData, setFormData] = useState({});
    const navigate = useNavigate();
    let customer=useRef(null);
    const FirstName=useRef("")
    const LastName=useRef("") 
    const Address =useRef("")  
    const Email=useRef("")
    const Phone=useRef("")
    const Pass=useRef("")
    const [accept,setaccept]=useState(false)
    let donor=useRef({
        FirstName:FirstName.current,
        LastName:LastName.current ,
        Phone:Phone.current,
        Email:Email.current,
        Password:Pass.current
    });


    const addNew=async()=>{
        if(accept==true){
            donor.current.FirstName=FirstName.current
            donor.current.LastName=LastName.current 
            donor.current.Phone=Phone.current
            donor.current.Email=Email.current
            donor.current.Password=Pass.current
      await addDonor(donor.current)
       }
       else{
        customer.FirstName=FirstName
        customer.LastName=LastName
        customer.Phone=Phone
        customer.Email=Email
        customer.Password=Pass  
        addCustomer(customer);  }   
    }

    const validate = (data) => {
        console.log("data",data);
        let errors = {};

        if (!data.name) {
            errors.name = 'Name is required.';
        }
        if (!data.Lastname) {
            errors.Lastname = 'LastName is required.';
        }
        if (!data.phone) {
            errors.phone = 'phone is required.';
        }
        else if(data.phone.length!==10){
            errors.phone = 'Invalid phone number.';
        }
        // else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(data.phone)) {
        //     errors.phone = 'Invalid phone number.';
        // }
        if (!data.email) {
            errors.email = 'mail is required.';
        }
        else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i.test(data.email)) {
            errors.email = 'Invalid mail.';           
        }
        if (!data.address) {
            errors.address = 'Address is required.';
        }
        if (!data.password) {
            errors.password = 'Password is required.';
        }
        return errors;
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

    const dialogFooter = <div className="flex justify-content-center"><Button label="OK" className="p-button-text" autoFocus onClick={() => setShowMessage(false) } /></div>;
    const passwordHeader = <h6>Pick a password</h6>;
    const passwordFooter = (
        <React.Fragment>
            <Divider />
            <p className="mt-2">Suggestions</p>
            <ul className="pl-2 ml-2 mt-0" style={{ lineHeight: '1.5' }}>
                <li>At least one lowercase</li>
                <li>At least one uppercase</li>
                <li>At least one numeric</li>
                <li>Minimum 8 characters</li>
            </ul>
        </React.Fragment>
    );

    return (
        <div className="form-demo">
            <Dialog visible={showMessage} onHide={() => setShowMessage(false)} position="top" footer={dialogFooter} showHeader={false} breakpoints={{ '960px': '80vw' }} style={{ width: '30vw' }}>
                <div className="flex align-items-center flex-column pt-6 px-3">
                    <i className="pi pi-check-circle" style={{ fontSize: '5rem', color: 'var(--green-500)' }}></i>
                    <h5>Registration Successful!</h5>
                    <p style={{ lineHeight: 1.5, textIndent: '1rem' }}>
                        Your account is registered under name <b>{formData.name}</b> 
                    </p>
                </div>
            </Dialog>
            
            <div className="flex justify-content-center">
                <div className="card">
                    <h5 className="text-center">Register</h5>
                    <Form onSubmit={onSubmit} initialValues={{ name: '', phone: '', password: '', date: null, country: null, accept: false }} validate={validate} render={({ handleSubmit }) => (
                        <form onSubmit={handleSubmit} className="p-fluid">
                            <Field name="name" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <InputText id="name" {...input} autoFocus className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>FirstName.current=e.target.value} />
                                        <label htmlFor="name" className={classNames({ 'p-error': isFormFieldValid(meta) })}>First name*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                            <Field name="Lastname" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <InputText id="Lastname" {...input} autoFocus className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>LastName.current=e.target.value} />
                                        <label htmlFor="name" className={classNames({ 'p-error': isFormFieldValid(meta) })}>Last name*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                            <Field name="phone" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label p-input-icon-right">
                                        <InputText id="phone" {...input} className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>Phone.current=e.target.value} />
                                        <label htmlFor="phone" className={classNames({ 'p-error': isFormFieldValid(meta) })}>phone*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                            <Field name="email" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label p-input-icon-right">
                                    <i className="pi pi-envelope" />
                                        <InputText id="email" {...input} className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>Email.current=e.target.value} />
                                        <label htmlFor="email" className={classNames({ 'p-error': isFormFieldValid(meta) })}>email*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                            <Field name="address" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label p-input-icon-right">                                   
                                        <InputText id="address" {...input} className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>Address.current=e.target.value} />
                                        <label htmlFor="address" className={classNames({ 'p-error': isFormFieldValid(meta) })}>address*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                            <Field name="password" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <Password id="password" {...input} toggleMask className={classNames({ 'p-invalid': isFormFieldValid(meta) })} header={passwordHeader} footer={passwordFooter}  onBlur={e=>Pass.current=e.target.value}/>
                                        <label htmlFor="password" className={classNames({ 'p-error': isFormFieldValid(meta) })}>Password*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
                                </div>
                            )} />
                           
                            <Field name="accept" type="checkbox" render={({ input, meta }) => (
                                <div className="field-checkbox">
                                    <Checkbox inputId="accept" {...input} className={classNames({ 'p-invalid': isFormFieldValid(meta) })} 
                                    onChange={(e)=>{setaccept(e.checked)} } 
                                    checked={accept}
                                    />
                                    <label htmlFor="accept" className={classNames({ 'p-error': isFormFieldValid(meta) })}>I want to donor*</label>
                                </div>
                            )} />

                            <Button onClick={addNew} type="submit" label="Submit" className="mt-2" />
                        </form>
                    )} />
                </div>
            </div>
        </div>
    );
}
