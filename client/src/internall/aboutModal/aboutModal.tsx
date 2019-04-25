import {Component} from "react";
import {BaseModal} from "../../components/baseModal";
import React from "react";

export class ModalAbout extends Component<{}, {show: boolean;}> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            show: false,
        }
    }

    render() {
        // const props = {
        //     onClick: null,
        //     className: "list-group-item list-group-item-action",
        //     disabled: false,
        //     href: "#About"
        // };
        // const trigger = {
        //     comp: "button",
        //     text: "About",
        //     attr: props
        // };
        return (
            <BaseModal show={this.state.show} title="About FoodBook">
                <span>BSUIR Minsk 2k19</span>
            </BaseModal>
        );
    }
}