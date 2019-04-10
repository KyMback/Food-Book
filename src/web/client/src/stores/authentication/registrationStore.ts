import { action, observable } from "mobx";
import { signUp } from "../../api/recipes/userApi/userApi";

class RegistrationStore {
    @observable login: string;
    @observable email: string;
    @observable password: string;
    @observable passwordConf: string;

    constructor() {
        this.login = "";
        this.email = "";
        this.password = "";
        this.passwordConf = "";
    }

    @action
    public resetToDefaults() {
        this.login = "";
        this.email = "";
        this.password = "";
        this.passwordConf = "";
    }

    public signUp = async (): Promise<boolean> => {
        const response = await signUp({
            userName: this.login,
            email: this.email,
            password: this.password,
            repeatedPassword: this.passwordConf,
        });

        if(response.succeeded) {
            return true;
        }

        return false;
    };
}

export const registrationStore = new RegistrationStore();