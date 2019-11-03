import React from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { connect } from 'react-redux';
import LinearProgress from '@material-ui/core/LinearProgress';

import { TablePagination } from '@material-ui/core';

const VehicleSearchResult = ({ models, loading }) => {
  return (
    <Paper>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Years Available</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {loading ? (
            <TableRow>
              <TableCell component="th" scope="row" colSpan={6}>
                <LinearProgress />
              </TableCell>
            </TableRow>
          ) : models ? (
            models.map(model => (
              <TableRow key={model.name + model.yearsAvailable}>
                <TableCell component="th" scope="row">
                  {model.name}
                </TableCell>
                <TableCell>{model.yearsAvailable}</TableCell>
              </TableRow>
            ))
          ) : (
            <TableRow>
              <TableCell component="th" scope="row">
                No Records Found.
              </TableCell>
            </TableRow>
          )}
        </TableBody>
      </Table>
    </Paper>
  );
};

const mapStateToProps = state => ({
  models: state.vehicleModels,
  loading: state.loading,
});

export default connect(
  mapStateToProps,
  null,
)(VehicleSearchResult);
