import {Component} from "react";
import {Header} from "../header";
import React from "react";
import MaterialTable from "material-table";
import {getAllRecipes, getMyRecipes, getRecipes} from "../../api/recipes/recipesApi/recipesApi";
import {catalogStore} from "../../stores/catalog/catalogStore";
import {observer} from "mobx-react";
import {RecipesTable} from "./recipesTable";

@observer
export class Catalog extends Component {
    public render(){
        return (
            <div className="d-flex flex-column col-10" style={{marginTop: "20px"}}>
                <Header/>
                <RecipesTable fetchData={catalogStore.fetchDataFunction}/>
            </div>
        );
    };

    private resolveTable = () => {
        return catalogStore.resetToDefaults()
    }
}