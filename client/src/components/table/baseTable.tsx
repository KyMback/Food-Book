import {Component, createRef, RefObject} from "react";
import MaterialTable, {Query, QueryResult} from "material-table";
import {catalogStore} from "../../stores/catalog/catalogStore";
import React from "react";
import {observer} from "mobx-react";
import {getAllRecipes} from "../../api/recipes/recipesApi/recipesApi";

interface Props {
    open: object;
    className?: string
}

@observer
export class BaseRecipesTable extends Component<Props> {

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
                data={getAllRecipes}
                options={{
                    search: false,
                    columnsButton: true
                }}

                onRowClick={(event, rowData) => {
                    console.log(event, rowData);
                    // @ts-ignore
                    this.props.open(rowData);
                }}

            />
        );
    }

    public forceUpdateHandler = () => {
        console.log('update-e');
        // @ts-ignore

    };
}