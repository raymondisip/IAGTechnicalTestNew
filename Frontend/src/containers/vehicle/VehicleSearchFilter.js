import React from 'react';
import { getVehicleModels } from '../../actions';
import { connect } from 'react-redux';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Icon from '@material-ui/core/Icon';
import Grid from '@material-ui/core/Grid';

const VehicleSearchFilter = ({ dispatch }) => {
  let vehicleMake;

  return (
    <div>
      <Grid container direction="row" justify="flex-start" alignItems="center" spacing={3} p={5}>
        <Grid container direction="row" justify="flex-start" alignItems="center" item xs={2}>
          <TextField label="Vehicle Make" inputProps={{ ref: node => (vehicleMake = node) }} p={5} required />
        </Grid>
        <Grid container direction="row" justify="flex-start" alignItems="center" item xs={2}>
          {/* <button type="submit">Search Vehicle</button> */}
          <Button
            variant="contained"
            color="primary"
            onClick={() => {
              if (vehicleMake.value.length > 0) dispatch(getVehicleModels(vehicleMake.value));
            }}
            endIcon={<Icon>search</Icon>}
          >
            Search
          </Button>
        </Grid>
      </Grid>
    </div>
  );
};

export default connect()(VehicleSearchFilter);
