import React, { Component } from 'react';

export class EmployeeData extends Component {
    static displayName = EmployeeData.name;

  constructor(props) {
    super(props);
    this.state = { employees: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }


  


  static renderForecastsTable(employees) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>        
            <th>Fio</th>
            <th>Speciality</th>
          </tr>
        </thead>
        <tbody>
          {employees.map(employee =>
            <tr key={employee.id}>
                  <td>{employee.fio}</td>
                  <td>{employee.speciality}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : EmployeeData.renderForecastsTable(this.state.employees);

    return (
      <div>
        <h1 id="tabelLabel" >Our employees</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    async populateWeatherData() {                            //������������ �� ������                                  
        const response = await fetch('employee');         //����������� ������ - �� ��������: employee - ��� ������� GET
        const data = await response.json();                          //����� ��������� � json   
        this.setState({ employees: data, loading: false });          //������ ��������� ������� state - ������ forecasts ������ ������� � �������
    }
}
