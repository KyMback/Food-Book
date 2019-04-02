import {Component} from "react";
import {CustomModal} from "../../components/customModal";
import React from "react";

export class ModalAbout extends Component<{}, {show: boolean;}> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            show: false,
        }
    }

    private changeState = (value: boolean) => {
        this.setState({show: value})
    };

    render() {
        const props = {
            onClick: null,
            className: "list-group-item list-group-item-action",
            disabled: false,
            href: "#About"
        };
        const trigger = {
            comp: "button",
            text: "About",
            attr: props
        };
        return (
            <CustomModal show={this.state.show} handlShow={this.changeState} trigger={trigger} title="About FoodBook">
                <span>BSUIR Minsk 2k19</span>
            </CustomModal>
        );
    }
}