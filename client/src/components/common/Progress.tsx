import { observer } from "mobx-react";
import { Component } from "react";
import React from "react";
import { CircularProgress } from "@material-ui/core";
import { globalStore } from "../../stores/globalStore";

@observer
export class Progress extends Component{
    public render() {
        return (
            <CircularProgress hidden={!globalStore.isThinking} className="circle circularProgress"/>
        );
    }
}