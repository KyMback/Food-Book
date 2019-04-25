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
    value?: string;
}

export class InputField extends Component<Props> {
    public render() {
        return (
            <Form.Group as={Row} controlId={this.props.labelText}>
                <div className={'col s2'}>
                    <Form.Label>
                        {this.props.labelText}
                    </Form.Label>
                </div>
                <div className={'col s10'}>
                    <InputComponent controlId={this.props.labelText} {...this.props} />
                </div>
            </Form.Group>
        );
    }
}
