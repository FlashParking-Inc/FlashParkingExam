import React, { Component } from 'react';

export class Dashboard extends Component {
    static displayName = Dashboard.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateDashboardData();
  }

    static renderGarageTable(dashboardData) {

    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Name</th>
            <th>Open Spots</th>
            <th>Closed Spots</th>
            <th>Total Spots</th>
          </tr>
        </thead>
        <tbody>
                {dashboardData.map(forecast =>
              <tr key={forecast.locationId}>
                  <td>{forecast.name}</td>
                  <td>{forecast.openSpots}</td>
                  <td>{forecast.filledSpots}</td>
                  <td>{forecast.totalSpots}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Dashboard.renderGarageTable(this.state.dashboardData);

    return (
      <div>
        <h1 id="tabelLabel">Garage Overview</h1>
        {contents}
      </div>
    );
  }

  async populateDashboardData() {
    const response = await fetch('dashboard');
    const data = await response.json();
    this.setState({ dashboardData: data, loading: false });
  }
}
