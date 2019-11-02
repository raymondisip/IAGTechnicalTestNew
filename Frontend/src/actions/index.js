import { GET_VEHICLE_MODELS } from './types';

export const getVehicleModels = vehicleMake => ({
  type: GET_VEHICLE_MODELS,
  vehicleMake: vehicleMake,
});
