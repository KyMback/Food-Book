import * as React from "react";
import { InputProps } from "reactstrap";
import { Form } from "react-bootstrap";

interface Props {
    controlId: string;
    type?: string;
    placeholder?: string;
    labelText: string;
    class?: string;
    row?: number;
    onChange: (newValue: string) => void;
}

interface State {
    value: string;
}

export class InputComponent extends React.PureComponent<Props, State> {
    public static getDerivedStateFromProps(props: InputProps, state: State) {
        const newValue = props.value || "";
        if (newValue !== state.value) {
            return { value: newValue };
        }
        return null;
    }

    constructor(props: any) {
        super(props);
        this.state = { value: "" };
    }

    public render() {
        return (
            <Form.Control rows={this.props.row? 5 : 1}
                          as="input"
                          type={this.props.type}
                          placeholder={this.props.placeholder}
                          className={this.props.class}
                          onChange={this.handleChange}/>
        );
    }

    private handleChange = (e: any) => {
        this.props.onChange!(e.target.value);
    }
}
