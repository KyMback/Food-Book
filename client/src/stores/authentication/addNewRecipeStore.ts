import { action, observable, runInAction } from "mobx";
import {createRecipe} from "../../api/recipes/recipesApi/recipesApi";

class AddNewRecipeStore {
    @observable title: string;
    @observable ingredients: string;

    constructor() {
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
        const response = await createRecipe({
            title: this.title,
            ingredients: this.ingredients
        });

        return response.succeeded;
    }
}

export const addNewRecipeStore = new AddNewRecipeStore();