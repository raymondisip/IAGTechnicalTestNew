import VehicleSearchFilter from '../containers/vehicle/VehicleSearchFilter';
import VehicleSearchResult from '../containers/vehicle/VehicleSearchResult';
import Header from '../containers/common/Header';
import React from 'react';
import Container from '@material-ui/core/Container';

const App = () => (
  <Container maxWidthXl>
    <div>
      <Header />
      <br />
      <VehicleSearchFilter />
      <br />
      <VehicleSearchResult />
    </div>
  </Container>
);

export default App;
