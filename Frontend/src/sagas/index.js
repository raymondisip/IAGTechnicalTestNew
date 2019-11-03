import { put, takeLatest, all } from 'redux-saga/effects';
import { GET_VEHICLE_MODELS, VEHICLE_MODELS_RECEIVED, API_ERROR } from '../actions/types';

export function* getVehicleModels(payload) {
  try {
    const jsonResponse = yield fetch(`https://localhost:44387/vehicle-checks/makes/${payload.vehicleMake}`).then(response => response.json());
    yield put({ type: VEHICLE_MODELS_RECEIVED, vehicleModels: jsonResponse.models });
  } catch (error) {
    yield put({ type: API_ERROR, error: error });
  }
}

export function* actionWatcher() {
  yield takeLatest(GET_VEHICLE_MODELS, getVehicleModels);
}

export default function* rootSaga() {
  yield all([actionWatcher()]);
}
