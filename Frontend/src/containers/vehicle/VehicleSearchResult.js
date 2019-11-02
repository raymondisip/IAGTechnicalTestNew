import React from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import { connect } from 'react-redux';

const VehicleSearchResult = ({ models }) => {
  return models ? (
    <Table aria-label="simple table">
      <TableHead>
        <TableRow>
          <TableCell>Name</TableCell>
          <TableCell>Years Available</TableCell>
        </TableRow>
      </TableHead>
      <TableBody>
        {models.map(model => (
          <TableRow key={model.name + model.yearsAvailable}>
            <TableCell component="th" scope="row">
              {model.name}
            </TableCell>
            <TableCell>{model.yearsAvailable}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  ) : null;
};

const mapStateToProps = state => ({
  models: state.vehicleModels,
});

export default connect(
  mapStateToProps,
  null,
)(VehicleSearchResult);
