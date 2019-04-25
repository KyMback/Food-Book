import {Component, createRef, RefObject} from "react";
import MaterialTable, {Query, QueryResult} from "material-table";
import {catalogStore} from "../../stores/catalog/catalogStore";
import React from "react";
import {observer} from "mobx-react";
import {getAllRecipes, getMyRecipes} from "../../api/recipes/recipesApi/recipesApi";

interface Props {
    update: object;
    delete: object;
    className?: string
}

@observer
export class MyRecipesTable extends Component<Props> {

    public render(): React.ReactNode {

        return (
            <MaterialTable
                title={"Recipe"}
                columns={
                    [
                        {title: "Title", field: "title"},
                        {title: "Added by", field: "createdBy"},
                        {title: "Data", field: "createdOn"},
                    ]
                }
                data={getMyRecipes}
                options={{
                    search: false,
                    columnsButton: true,
                    actionsColumnIndex: -1,
                }}

                onRowClick={(event, rowData) => {
                    console.log(event, rowData);
                    // @ts-ignore
                    this.props.update(rowData);
                }}

                actions={[
                    {
                        icon: 'delete',
                        tooltip: 'Delete User',
                        onClick: async (event, rowData) => {
                            let result = confirm("You want to delete " + rowData.title);
                            if (result) {
                                // @ts-ignore
                                let response = await this.props.delete(rowData.id);
                                if (response.ok) {
                                    alert('success delete ' + rowData.title);
                                } else {
                                    alert('failed to delete ' + rowData.title);
                                }
                            }
                        }
                    }
                ]}
            />
        );
    }

    public forceUpdateHandler = () => {
        this.forceUpdate();
    };
}