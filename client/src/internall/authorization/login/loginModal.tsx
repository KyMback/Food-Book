import {Component, MouseEvent} from "react";
import React from "react";
import { BaseModal } from "../../../components/baseModal";
import Row from "react-bootstrap/Row";
import { Form, Col } from "react-bootstrap";
import { withStyles } from "@material-ui/core";
import { action } from "mobx";
import { loginStore } from "../../../stores/authentication/loginStore";
import { observer } from "mobx-react";
import { Button } from "reactstrap";
import { InputFieldProps, makeInputFields } from "../../../components/form/factories/inputFieldsFactory";
import {userContextStore} from "../../../stores/userContextStore";

interface State {
    query: string;
    show: boolean;
}

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


export class LoginModal extends Component<{id: string}, State> {
    private fields: InputFieldProps[] = [
        {
            placeholder: "name@example.com",
            labelText: "Email",
            onChange: (newValue: string) => loginStore.login = newValue,
        },
        {
            type: "password",
            placeholder: "Password",
            labelText: "Password",
            onChange: (newValue: string) => loginStore.password = newValue,
        },
    ];

    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            query: "idle",
            show: false,
        }
    }

    public render() {
        return (
            <BaseModal onClose={this.hide} show={this.state.show} title="Log in" id={this.props.id}>
                {makeInputFields(this.fields)}
                <Button  onClick={this.onLogin}>Sign in</Button>
            </BaseModal>
        );
    }

    public show = () => {
        loginStore.resetToDefaults();
        this.setState({show: true});
    };

    private hide = () => {
        // this.setState({show: false});
        // @ts-ignore
        $('#modal_login').modal('close');
        console.log('close');
    };

    @action
    private onLogin = async (event: MouseEvent<any>) => {
        event.preventDefault();
        const result = await loginStore.signIn();
        if(result){
            this.hide();
        }
    };
}

// @ts-ignore
export default withStyles(styles)(LoginModal);
