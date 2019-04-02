import {observable} from "mobx";
import {UserContextModel} from "../internall/models/userContextModel";

class UserContextStore {
    @observable public activeUser?: UserContextModel;
}



export const userContextStore = new UserContextStore();