import React, { Component } from 'react';

export class VehicleCheckIn extends Component {
    static displayName = VehicleCheckIn.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
      this.populateCheckInData();
  }

    static renderCheckInTable(checkInData) {

    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Sure</th>
            <th>lol</th>
            <th>why not</th>
            <th>stick a car there</th>
          </tr>
        </thead>
        <tbody>
                {checkInData.map(forecast =>
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
        : VehicleCheckIn.renderCheckInTable(this.state.checkInData);

    return (
      <div>
        <h1 id="tabelLabel">Garage Overview</h1>
        {contents}
      </div>
    );
  }

    async populateCheckInData()
    {
        const response = await fetch('dashboard');
        const data = await response.json();
        this.setState({ checkInData: data, loading: false });
    }
}
