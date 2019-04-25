import {Component, createRef, RefObject} from "react";
import MaterialTable, {Query, QueryResult} from "material-table";
import {catalogStore} from "../../stores/catalog/catalogStore";
import React from "react";
import {observer} from "mobx-react";

interface Props {
    fetchData: (request: Query) => Promise<QueryResult>;
    className?: string
}

@observer
export class RecipesTable extends Component<Props> {

    public render(): React.ReactNode {

        return (
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
                data={this.props.fetchData}
                options={{
                    search: false,
                    columnsButton: true
                }}
                detailPanel={this.renderDetails}
            />
        );
    }

    private renderDetails(rowData: any) : React.ReactNode {
        return (
            <div className="col-6 ">
                <h4>{rowData.title}</h4>
                <label><i>Created by: </i><strong>{rowData.createdBy}</strong></label>
                <h5>Recipe:</h5>
                <p><span>{rowData.ingredients}</span></p>
                <label><i>Created on: </i>{rowData.createdOn}</label>
            </div>
        )
    }
}