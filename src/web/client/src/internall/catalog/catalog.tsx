import {Component} from "react";
import {Header} from "../header";
import React from "react";
import MaterialTable from "material-table";
import { getRecipes } from "../../api/recipes/recipesApi/recipesApi";

export class Catalog extends Component {

    // private getUserDetails = async ()=>{
    //     const user = userContextStore.activeUser;
    //     if(user){
    //         const user_details = await getUserDetails();
    //         const data = {
    //             "Query": "query test($from: Int!, $count: Int!, $title: String, $ownerId: String) { recipes(from: $from, count: $count, title: $title, ownerId: $ownerId) { entities { id title ingredients createdBy createdOn}count}}",
    //             "Variables": {
    //                 "from": 0,
    //                 "count": 10,
    //                 "ownerId": user_details.data.body.id
    //             }
    //         };
    //
    //         const response = await getRecipe(data);
    //         this.setState(
    //             {
    //                 rowData: response.body.data
    //             }
    //         )
    //     }
    // };

    public render(){
        return (
            <div className="d-flex flex-column col-10" style={{marginTop: "20px"}}>
                <Header/>
                <div>
                    <MaterialTable
                        title={"Recipe"}
                        columns={
                            [
                                {title: "Title", field: "title"},
                                {title: "Added by", field: "createdBy"},
                                {title: "Data", field: "createdOn"},
                                // {title: "Rating", field: "rating"}
                            ]
                        }
                        data={getRecipes}
                        options={{
                            search: false,
                            columnsButton: true
                        }}
                    />
                </div>
            </div>
        );
    };
}