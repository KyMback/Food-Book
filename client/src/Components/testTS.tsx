import {Component} from "react";
import Modal from "react-bootstrap/Modal";
import React from "react";
import {AnyAaaaRecord} from "dns";

interface MyModalProps {

}

interface MyModalState {
    show: boolean ;
}


export class MyModal extends Component<MyModalProps, MyModalState> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            show: false,
        };
    }

    private handleClose = () => {
        this.setState({show: false});
    };

    private handleShow = () => {
        this.setState({show: true});
    };

    public render() {
        return (
            <div>
                <a href="#" onClick={this.handleShow}>
                    Registration
                </a>

                <Modal show={this.state.show.valueOf()} onHide={this.handleClose}>
                    {this.props.children}
                </Modal>
            </div>
        );
    }


}
