import {Component, ReactType} from "react";
import Modal from "react-bootstrap/Modal";
import React from "react";
import { Form, Row, Col} from "react-bootstrap";

interface FormLineProps {
    controlId: string;
    type: string;
    placeholder: string;
    labelText: string;
    as: string;
    class?: string;
    row?: number;
    onChange: object;
}

interface FormLineState {
}


export class FormLine extends Component<FormLineProps, FormLineState> {
    public render() {

        return (
            <Form.Group as={Row} controlId={this.props.controlId}>
                <Col sm={2}>
                    <Form.Label>
                        {this.props.labelText}
                    </Form.Label>
                </Col>
                <Col sm={10}>
                    <Form.Control rows={this.props.row? 5 : 1}
                                  as={this.props.as === "input" ? "input": "textarea"}
                                  type={this.props.type}
                                  placeholder={this.props.placeholder}
                                  className={this.props.class}
                                    // @ts-ignore
                                  onChange={this.props.onChange}/>
                </Col>
            </Form.Group>
        );
    }


}
