import {action, observable, runInAction} from "mobx";
import {updateRecipes} from "../../api/recipes/recipesApi/recipesApi";

class UpdateRecipeStore {
    @observable title: string;
    @observable ingredients: string;
    @observable id: string;

    constructor() {
        this.id = "";
        this.title = "";
        this.ingredients = "";
    }

    @action
    public resetToDefaults = () => {
        this.title = "";
        this.ingredients = "";
    };

    @action
    public create = async (): Promise<boolean> => {
        const response = await updateRecipes({
            id: this.id,
            title: this.title,
            ingredients: this.ingredients
        });

        return response.succeeded;
    }
}

export const updateRecipeStore = new UpdateRecipeStore();