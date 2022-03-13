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
            <th>Location</th>
            <th>Section</th>
            <th>Space</th>
            <th>Occupant</th>
          </tr>
        </thead>
        <tbody>
        {checkInData.map(checkIn =>
            <tr key={checkIn.spaceId}>
                <td>{checkIn.garageName}</td>
                <td>{checkIn.sectionName}</td>
                <td>{checkIn.spaceName}</td>
                <td>{checkIn.vehicleVin}</td>
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
        const response = await fetch('vehiclecheckin');
        const data = await response.json();
        this.setState({ checkInData: data, loading: false });
    }
}
