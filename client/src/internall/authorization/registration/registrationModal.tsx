import { Component } from "react";
import { BaseModal } from "../../../components/baseModal";
import React from "react";
import { Col, Form } from "react-bootstrap";
import Row from "react-bootstrap/Row";
import { observer } from "mobx-react";
import { InputFieldProps, makeInputFields } from "../../../components/form/factories/inputFieldsFactory";
import { registrationStore } from "../../../stores/authentication/registrationStore";
import { Button } from "reactstrap";

const styles = (theme: any) => ({
    root: {
        display: "flex",
        flexDirection: "column",
        alignItems: "center"
    },
    button: {
        margin: theme.spacing.unit * 2,
        color: "#0066ff",
    },
    placeholder: {
        height: 40
    }
});

interface State {
    show: boolean;
}

@observer
export class RegistrationModal extends Component<{id: string}, State> {
    private fields: InputFieldProps[] = [
        {
            labelText: "Login",
            onChange: (newValue: string) => registrationStore.login = newValue,
        },
        {
            labelText: "Email",
            onChange: (newValue: string) => registrationStore.email = newValue,
        },
        {
            labelText: "Password",
            type: "password",
            onChange: (newValue: string) => registrationStore.password = newValue,
        },
        {
            labelText: "Confirm password",
            type: "password",
            onChange: (newValue: string) => registrationStore.passwordConf = newValue,
        },
    ];

    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            show: false,
        };
    }

    public render() {
        return (
            <BaseModal onClose={this.hide} show={this.state.show} title="Registration" id={this.props.id}>
                <Form>
                    {makeInputFields(this.fields)}
                    <Form.Group as={Row}>
                        <Col sm={{span: 10, offset: 2}}>
                            <Button onClick={this.signUp}>Sign Up</Button>
                        </Col>
                    </Form.Group>
                </Form>
            </BaseModal>
        )
    }

    public show = () => {
        registrationStore.resetToDefaults();
        this.setState({show: true});
    };

    private hide = () => {
        // this.setState({show: false});
        // @ts-ignore
        $('#modal_reg').modal('close');
    };

    private signUp = async () => {
        const response = await registrationStore.signUp();

        if(response){
            this.hide();
        }
    };
}