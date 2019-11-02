import VehicleSearchFilter from '../containers/vehicle/VehicleSearchFilter';
import VehicleSearchResult from '../containers/vehicle/VehicleSearchResult';
import Header from '../containers/common/Header';
import React, { Component } from 'react';

export default class App extends Component {
  render = () => {
    return (
      <div>
        <Header />
        <br />
        <VehicleSearchFilter />
        <br />
        <VehicleSearchResult />
      </div>
    );
  };
}
