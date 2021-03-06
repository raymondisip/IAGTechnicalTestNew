import { GET_VEHICLE_MODELS, VEHICLE_MODELS_RECEIVED, API_ERROR } from '../actions/types';

const reducer = (state = {}, action) => {
  switch (action.type) {
    case GET_VEHICLE_MODELS: {
      return { ...state, vehicleMake: action.vehicleMake, vehicleModels: undefined, loading: true };
    }
    case VEHICLE_MODELS_RECEIVED: {
      return { ...state, vehicleModels: action.vehicleModels, loading: false };
    }
    case API_ERROR: {
      return { ...state, vehicleModels: undefined, loading: false };
    }
    default:
      return state;
  }
};

export default reducer;
