import { put, takeLatest, all } from 'redux-saga/effects';
import { GET_VEHICLE_MODELS, VEHICLE_MODELS_RECEIVED } from '../actions/types';

export function* getVehicleModels(payload) {
  const jsonResponse = yield fetch(`https://localhost:44387/vehicle-checks/makes/${payload.vehicleMake}`).then(response => response.json());
  yield put({ type: VEHICLE_MODELS_RECEIVED, vehicleModels: jsonResponse.models });
}

export function* actionWatcher() {
  yield takeLatest(GET_VEHICLE_MODELS, getVehicleModels);
}

export default function* rootSaga() {
  yield all([actionWatcher()]);
}
