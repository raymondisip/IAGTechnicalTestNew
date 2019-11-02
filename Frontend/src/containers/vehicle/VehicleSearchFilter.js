import React from 'react';
import { getVehicleModels } from '../../actions';
import { connect } from 'react-redux';

const VehicleSearchFilter = ({ dispatch }) => {
  let input;

  return (
    <div>
      <form
        onSubmit={e => {
          e.preventDefault();
          if (!input.value.trim()) {
            return;
          }
          dispatch(getVehicleModels(input.value));
        }}
      >
        &nbsp;&nbsp;&nbsp;
        <input ref={node => (input = node)} />
        &nbsp;&nbsp;&nbsp;
        <button type="submit">Search Vehicle</button>
      </form>
    </div>
  );
};

export default connect()(VehicleSearchFilter);
