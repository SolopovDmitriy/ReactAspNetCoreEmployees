import React, { Component } from 'react'; // ����������� react
import { Route } from 'react-router';  // ���������� <Route exact path='/' component={Home} />
import { Layout } from './components/Layout'; // ���������� ����������
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
//import HomeRoute from '../../components/pages/Home/Home';

import { EmployeeData } from './components/EmployeeData';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} /> {/* Route path='/counter' - ������ ���� � �������� --> component={Counter} --> import { Counter } from './components/Counter'; */}
        <Route path='/fetch-data' component={FetchData} />
            <Route path='/employee-data' component={EmployeeData} /> {/* employee-data   ����� ���� ����������� */}
      </Layout>
    );
  }
}
