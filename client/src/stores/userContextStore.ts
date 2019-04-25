import {action, observable} from "mobx";
import {UserContextModel} from "../internall/models/userContextModel";
import {UserDetails} from "../internall/models/userDetails";
import {getUserDetails} from "../api/recipes/userApi/userApi";

class UserContextStore {
    @observable public activeUser?: UserContextModel;
    @observable public user?: UserDetails;

    @action
    public signOut = () => {
        this.user = undefined;
    };

    @action
    public loadUserDetails = async () =>{
        const resp =  await getUserDetails();
        this.user = {
            id: resp.Id,
            login: resp.Login,
            email: resp.Email
        };
    }
}



export const userContextStore = new UserContextStore();