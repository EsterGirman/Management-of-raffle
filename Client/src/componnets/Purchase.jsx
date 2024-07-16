import React, { useState, useEffect } from 'react';
import { classNames } from 'primereact/utils';
import { BrowserRouter as Router, Route, Link, Switch } from 'react-router-dom';
import {getAllCustomers, getCustomerByID, addCustomer, deleteCustomer} from '../axios/CustomerApi'