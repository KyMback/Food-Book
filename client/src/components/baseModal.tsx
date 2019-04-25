import {Component} from "react";
import React from "react";
import { Modal, ModalBody, ModalFooter, ModalHeader } from "reactstrap";

interface Props {
    title: string;
    footer?: any;
    show: boolean;
    onClose?: () => void;
    id: string;
}

export class BaseModal extends Component<Props> {
    constructor(props: any) {
        super(props);
    }

    public render() {
        return (
            <div className={"modal"} id={this.props.id}>
                <div className="modal-content">
                    <h4>{this.props.title}</h4>
                    {this.props.children}
                </div>
                {/*<div className="modal-footer">*/}
                    {/*{this.props.footer}*/}
                    {/*/!*<a href="#!" className="modal-close waves-effect waves-green btn-flat">Agree</a>*!/*/}
                {/*</div>*/}
                {/*<Modal isOpen={this.props.show}>*/}
                    {/*<ModalHeader toggle={this.props.onClose}>*/}
                        {/**/}
                    {/*</ModalHeader>*/}
                    {/*<ModalBody>*/}
                        {/*{this.props.children}*/}
                    {/*</ModalBody>*/}
                    {/*{this.props.footer && (*/}
                    {/*<ModalFooter>*/}
                        {/*{this.props.footer}*/}
                    {/*</ModalFooter>)}*/}
                {/*</Modal>*/}
            </div>
        );
    }
}
