import reducer from './index';
import { GET_VEHICLE_MODELS, VEHICLE_MODELS_RECEIVED } from '../actions/types';

describe('REDUCER', () => {
  it('should return the initial state', () => {
    expect(reducer(undefined, {})).toEqual({});
  });

  it('should handle "GET_VEHICLE_MODELS" action', () => {
    let vehicleMake = 'Lotus';
    let expectedResult = {
      vehicleMake: vehicleMake,
      vehicleModels: undefined,
      loading: true,
    };
    expect(reducer({}, { type: GET_VEHICLE_MODELS, vehicleMake: vehicleMake })).toEqual(expectedResult);
  });

  it('should handle VEHICLE_MODELS_RECEIVED action', () => {
    let mockData = [
      {
        name: '2 Eleven',
        yearsAvailable: 2,
        years: [2008, 2009],
      },
    ];
    let expectedResult = { vehicleModels: mockData, loading: false };
    expect(reducer({}, { type: VEHICLE_MODELS_RECEIVED, vehicleModels: mockData })).toEqual(expectedResult);
  });
});
