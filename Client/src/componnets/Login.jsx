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
import './register.css';
import { addDonor } from '../axios/DonorApi';

export default  function Login () {
    const [showMessage, setShowMessage] = useState(false);
    const [formData, setFormData] = useState({});
    let cust={FirstName:"",
        LastName:"",
        Password:""}
    const navigate = useNavigate();
    let customer=useRef(cust);
    let donor=useRef(null);
    const FirstName=useRef("")
    const LastName=useRef("") 
    const pasword=useRef("") 
    const Address =useRef("")  
    const Email=useRef("")
    const Phone=useRef("")
    const Pass=useRef("")
    const [accept,setaccept]=useState(false)

    const addNew=()=>{
            customer.current.FirstName=FirstName.current
            customer.current.LastName=LastName.current
            debugger
            customer.current.Password=Pass.current
        addCustomer(customer.current)
        localStorage.setItem('Customer', customer.current.Password);
        localStorage.setItem('Customer2', 1);

        navigate('/Gifts',{replace:false})
    }

    const validate = (data) => {
        let errors = {};

        if (!data.name) {
            errors.name = 'Name is required.';
        }
        if (!data.Lastname) {
            errors.Lastname = 'LastName is required.';
        }
        if (!data.password ) {
            errors.password = 'Password is required.';
        }
        //לעשות- רק אם יש באמת כזה סיסמא
        //if(data.password.length)
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
    

    return (
        <div className="form-demo">

            <div className="flex justify-content-center">
                <div className="card">
                    <h5 className="text-center">Login</h5>
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
                             <Field name="password" render={({ input, meta }) => (
                                <div className="field">
                                    <span className="p-float-label">
                                        <InputText id="Password" {...input} autoFocus className={classNames({ 'p-invalid': isFormFieldValid(meta) })}onBlur={e=>Pass.current=e.target.value} />
                                        <label htmlFor="name" className={classNames({ 'p-error': isFormFieldValid(meta) })}>Password*</label>
                                    </span>
                                    {getFormErrorMessage(meta)}
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

