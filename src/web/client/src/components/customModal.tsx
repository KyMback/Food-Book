import {Component} from "react";
import React from "react";
import {ModalFooter} from "react-bootstrap";
import Modal from "react-bootstrap/Modal";

interface MyModalProps {
    trigger: {
        attr: object;
        comp: string;
        text: string;
    };
    title: string;
    footer?: any;
    show?: boolean;
    handlShow?: any;
}

interface MyModalState {
    show: boolean ;
}


export class CustomModal extends Component<MyModalProps, MyModalState> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            show: false,
        };
    }

    private handleClose = () => {
        //this.setState({show: false});
        this.props.handlShow(false)
    };

    private handleShow = () => {
        this.props.handlShow(true)
        //this.setState({show: true});
    };

    public render() {
        // @ts-ignore
        this.props.trigger.attr["onClick"] = this.handleShow;
        let comp = React.createElement(this.props.trigger.comp, this.props.trigger.attr, this.props.trigger.text);
        return (
            <div>
                {comp}
                {/*<Modal show={this.state.show.valueOf() && this.state.show.valueOf() && this.props.show} onHide={this.handleClose}>*/}
                <Modal show={this.props.show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>{this.props.title}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        {this.props.children}
                    </Modal.Body>
                    {this.props.footer && (
                    <ModalFooter>
                        {this.props.footer}
                    </ModalFooter>)}
                </Modal>
            </div>
        );
    }
}
