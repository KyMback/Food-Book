import {action, computed, observable, runInAction} from "mobx";
import {getAllRecipes, getMyRecipes, getRecipes} from "../../api/recipes/recipesApi/recipesApi";
import {Query, QueryResult} from "material-table";

class CatalogStore {
    @observable currentPage: string;

    @computed
    public get fetchDataFunction(): any {
        switch (this.currentPage) {
            case "all": return getAllRecipes;
            case "my": return getMyRecipes;
        }
    }

    constructor() {
        this.currentPage = "all";
    }

    @action
    public resetToDefaults = () => {
        this.currentPage = "all";
    };

    @action
    public openMyRecipe = () =>{
        this.currentPage = "my";
    };

    public getRecipes = async (request: Query) => {
        switch (this.currentPage) {
            case "all":
        }
        if(this.currentPage){
            return await getMyRecipes(request)
        }else{
            return await getAllRecipes(request)
        }
    };
}

export const catalogStore = new CatalogStore();