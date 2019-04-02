import {Component} from "react";
import React from "react";
import {CustomModal} from "../customModal";
import Row from "react-bootstrap/Row";
import {FormLine} from "../form/formLine";
import {Form, Col} from "react-bootstrap";
import Button from "@material-ui/core/Button";
import {withStyles} from "@material-ui/core";
import {httpPost} from "../../api/requests";
import {action, runInAction} from "mobx";
import {userContextStore} from "../../stores/userContextStore";
import {SignIn} from "../../api/recipes/userApi/userApi";

interface FormLineState {
    login: string;
    password: string;
    query: string;
    show: boolean;
    res?: any;
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


export class ModalLogin extends Component<{load: any;}, FormLineState> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            login: "",
            password: "",
            query: "idle",
            show: false,
            res: null
        }
    }

    @action
    private handleSubmit = async (event: any) => {
        event.preventDefault();

        this.setState({
            query: "progress"
        });

        let data = {
            "Login": this.state.login,
            "Password": this.state.password
        };

        const response = await SignIn(data);

        console.log('test');

        // @ts-ignore
        if (response.status === 200) {
            runInAction(() => userContextStore.activeUser = {
                active: true,
                name: data.Login
            });
            this.props.load();
        }

        // @ts-ignore
        this.setState({ query: "success", show: false, res: response.status});
    };

    private changeState = (value: boolean) => {
        this.setState({show: value})
    };

    public render() {
        let props = {
            "onClick": null

        };
        let trigger = {
            comp: "a",
            text: "Sign In",
            attr: props
        };

        return (
            <CustomModal show={this.state.show} handlShow={this.changeState} trigger={trigger} title="Log in">
                <Form onSubmit={this.handleSubmit}>
                    <FormLine controlId="Email"
                              type="text"
                              placeholder="name@example.com"
                              labelText="Email"
                              as="input"
                              onChange={(e: any) => {
                                  this.setState(
                                      {login: e.target.value})
                              }}/>
                    <FormLine controlId="Password"
                              type="password"
                              placeholder="Password"
                              labelText="Password"
                              as="input"
                              onChange={(e: any) => {
                                  this.setState(
                                      {password: e.target.value})
                              }}/>
                    <Form.Group as={Row}>
                        <Col sm={{span: 10, offset: 2}}>
                            <Button className={
                                // @ts-ignore
                                this.props.button}
                                    type="submit"
                                    variant="contained"
                                    color="primary"
                                // @ts-ignore
                                    style={{"backgroundColor": "#2196f3"}}>Ok</Button>
                        </Col>
                    </Form.Group>
                </Form>
            </CustomModal>
        );
    }
}

// @ts-ignore
export default withStyles(styles)(ModalLogin);
