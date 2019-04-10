import {Component} from "react";
import React from "react";
import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

interface Props {
    title: string;
    footer?: any;
    show: boolean;
    onClose?: () => void;
}

export class BaseModal extends Component<Props> {
    constructor(props: any) {
        super(props);
    }



    public render() {
        return (
            <div>
                <Modal isOpen={this.props.show}>
                    <ModalHeader toggle={this.props.onClose}>
                        {this.props.title}
                    </ModalHeader>
                    <ModalBody>
                        {this.props.children}
                    </ModalBody>
                    {this.props.footer && (
                    <ModalFooter>
                        {this.props.footer}
                    </ModalFooter>)}
                </Modal>
            </div>
        );
    }
}
