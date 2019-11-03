import { put, takeLatest } from 'redux-saga/effects';
import { getVehicleModels, actionWatcher } from './index';
import { GET_VEHICLE_MODELS, VEHICLE_MODELS_RECEIVED } from '../actions/types';

describe('SAGAS', () => {
  it('should dispatch action "GET_VEHICLE_MODELS" ', () => {
    let generator = actionWatcher();

    expect(generator.next().value).toEqual(takeLatest(GET_VEHICLE_MODELS, getVehicleModels));
    expect(generator.next().done).toBeTruthy();
  });

  it('should dispatch action "VEHICLE_MODELS_RECEIVED" with result from fetch Vehicke check API', () => {
    let make = 'Lotus';

    let mockModels = [
      {
        name: '2 Eleven',
        yearsAvailable: 2,
        years: [2008, 2009],
      },
    ];

    let mockResponse = {
      make: 'Lotus',
      models: mockModels,
    };

    let expectedResult = { type: VEHICLE_MODELS_RECEIVED, vehicleModels: mockModels };

    let generator = getVehicleModels(make);
    generator.next();

    expect(generator.next(mockResponse).value.payload.action).toEqual(expectedResult);
    expect(generator.next().done).toBeTruthy();
  });
});
