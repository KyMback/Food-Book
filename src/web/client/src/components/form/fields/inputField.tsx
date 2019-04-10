import { Component } from "react";
import React from "react";
import { Form, Row, Col} from "react-bootstrap";
import { InputComponent } from "../base/inputComponent";

interface Props {
    type?: string;
    placeholder?: string;
    labelText: string;
    class?: string;
    row?: number;
    onChange: (newValue: string) => void;
}

export class InputField extends Component<Props> {
    public render() {
        return (
            <Form.Group as={Row} controlId={this.props.labelText}>
                <Col sm={2}>
                    <Form.Label>
                        {this.props.labelText}
                    </Form.Label>
                </Col>
                <Col sm={10}>
                    <InputComponent controlId={this.props.labelText} {...this.props} />
                </Col>
            </Form.Group>
        );
    }
}
