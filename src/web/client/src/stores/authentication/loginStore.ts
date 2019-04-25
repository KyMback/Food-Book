import { action, observable, runInAction } from "mobx";
import { signIn } from "../../api/recipes/userApi/userApi";
import { userContextStore } from "../userContextStore";

class LoginStore {
    @observable login: string;
    @observable password: string;

    constructor() {
        this.login = "";
        this.password = "";
    }

    @action
    public resetToDefaults = () => {
        this.login = "";
        this.password = "";
    }

    @action
    public signIn = async (): Promise<boolean> => {
        const response = await signIn({
            login: this.login,
            password: this.password
        });

        if (response.succeeded) {
            runInAction(() => userContextStore.activeUser = {
                active: true,
                name: this.login
            });

            return true;
        }

        return false;
    }
}

export const loginStore = new LoginStore();