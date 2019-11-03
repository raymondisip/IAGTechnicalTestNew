import * as actions from './index';
import { GET_VEHICLE_MODELS } from './types';

describe('ACTIONS', () => {
  it('should create an action with correct type', () => {
    let vehicleMake = 'Lotus';
    let expectedAction = {
      type: GET_VEHICLE_MODELS,
      vehicleMake: vehicleMake,
    };
    expect(actions.getVehicleModels(vehicleMake)).toEqual(expectedAction);
  });
});
