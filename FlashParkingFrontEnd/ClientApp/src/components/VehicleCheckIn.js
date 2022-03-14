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
                {checkInData.map(checkInRow =>
                <tr key={checkInRow.spaceId}>
                    <td>{checkInRow.garageName}</td>
                    <td>{checkInRow.sectionName}</td>
                    <td>{checkInRow.spaceName}</td>
                    <td>{this.renderCheckInOutButton(checkInRow)}
                    </td>
                </tr>
              )}
            </tbody>
          </table>
        );
    }

    renderCheckInOutButton(checkInRow) {
        console.log(checkInRow.vehicleId);
        var buttonText = checkInRow.vehicleId ? "Eject Vehicle" : "Intake Vehicle";
        var func = () => this.ToggleSpaceFilled(checkInRow);

        return <button onClick={func}>
            {buttonText}
        </button>
    }

    async ToggleSpaceFilled(checkInRow) {
        await fetch("vehiclecheckin", {
            method: 'POST', body: JSON.stringify(checkInRow),
            headers:
            {
                'Content-Type': 'application/json'
            }
        });
        await this.populateCheckInData();
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : VehicleCheckIn.renderCheckInTable.call(this, this.state.checkInData);

        return (
            <div>
            <h1 id="tabelLabel">Garage Overview</h1>
            {contents}
            </div>
        );
    }

    async populateCheckInData()
    {
        console.log("populating...");
        const response = await fetch('vehiclecheckin');
        const data = await response.json();
        this.setState({ checkInData: data, loading: false });
    }
}
