import { Component } from "react";
import React from "react";
import { Form, Row, Col} from "react-bootstrap";

interface FormLineProps {
    controlId: string;
    type: string;
    placeholder?: string;
    labelText: string;
    as: string;
    class?: string;
    row?: number;
    onChange: (newValue: string) => void;
    value?: string;
}

interface FormLineState {
}


export class FormLine extends Component<FormLineProps, FormLineState> {
    public render() {
        return (
            <Form.Group as={Row} controlId={this.props.controlId}>
                <div className={'col s2'}>
                    <Form.Label>
                        {this.props.labelText}
                    </Form.Label>
                </div>
                <div className={'col s10'}>
                    <Form.Control rows={this.props.row? 5 : 1}
                                  as={this.props.as === "input" ? "input": "textarea"}
                                  type={this.props.type}
                                  placeholder={this.props.placeholder}
                                  className={this.props.class}
                                  onChange={this.onChange}
                                  value={this.props.value}
                    />
                </div>
            </Form.Group>
        );
    }

    private onChange = (event: any) => {
        this.props.onChange(event.target.value);
    }
}
