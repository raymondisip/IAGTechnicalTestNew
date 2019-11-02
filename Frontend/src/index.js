import React from 'react';
import './index.css';
import * as serviceWorker from './serviceWorker';
import rootReducer from './reducers';
import { createStore, applyMiddleware, compose } from 'redux';
import { Provider } from 'react-redux';
import { render } from 'react-dom';
import App from './components/App';

import createSagaMiddleware from 'redux-saga';
import rootSaga from './sagas';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const sagaMiddleware = createSagaMiddleware();
const store = createStore(rootReducer, composeEnhancers(applyMiddleware(sagaMiddleware)));

sagaMiddleware.run(rootSaga);

render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('root'),
);

serviceWorker.register();
