import {Component} from "react";
import {Header} from "../../components/Header";
import React from "react";
import MaterialTable from "material-table";
import {observer} from "mobx-react";
import {userContextStore} from "../../stores/userContextStore";
import {resolveAny} from "dns";
import {GetUserDetails} from "../../api/recipes/userApi/userApi";
import {getRecipe} from "../../api/recipes/recipesApi/recipesApi";


@observer
export class Catalog extends Component<{}, {rowData: any;}> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            rowData: [{},],
        }
    }

    private getUserDetails = async ()=>{
        const user = userContextStore.activeUser;
        if(user){
            const user_details = await GetUserDetails();
            const data = {
                "Query": "query test($from: Int!, $count: Int!, $title: String, $ownerId: String) { recipes(from: $from, count: $count, title: $title, ownerId: $ownerId) { entities { id title ingredients createdBy createdOn}count}}",
                "Variables": {
                    "from": 0,
                    "count": 10,
                    "ownerId": user_details.body.id
                }
            };

            const response = await getRecipe(data);
            this.setState(
                {
                    rowData: response.body.data
                }
            )
        }
    };

    public render(){

        let rowData = [
            {name: "Test Recipe", addby: "буратино", data: "10.03.2019", rating: "5"},
            {name: "Test Recipe 2", addby: "Папа карло", data: "11.03.2019", rating: "4.5"},
        ];

        return (
            <div className="d-flex flex-column col-10" style={{marginTop: "20px"}}>
                <Header load={this.getUserDetails}/>
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
                        data={this.state.rowData}
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