import axios from 'axios';

export interface State {
    count: 0
}

const state: State = {
    count: 0
}

const getters = {
    count: (state: State) => state.count
}