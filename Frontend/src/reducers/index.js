import { GET_VEHICLE_MODELS, VEHICLE_MODELS_RECEIVED } from '../actions/types';

const reducer = (state = {}, action) => {
  switch (action.type) {
    case GET_VEHICLE_MODELS: {
      return { ...state, news: action.vehicleMake, loading: true };
    }
    case VEHICLE_MODELS_RECEIVED:
      return { ...state, vehicleModels: action.vehicleModels, loading: false };
    default:
      return state;
  }
};

export default reducer;
