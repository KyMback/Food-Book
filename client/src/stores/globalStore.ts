import { action, observable } from "mobx";

class GlobalStore {
    @observable isThinking: boolean;

    constructor(){
        this.isThinking = false;
    }
}

export const globalStore = new GlobalStore();