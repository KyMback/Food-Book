import {Component} from "react";
import {CustomModal} from "../customModal";
import React from "react";
import {Col, Form, Modal} from "react-bootstrap";
// @ts-ignore
import {FormLine} from "../form/formLine";
import Row from "react-bootstrap/Row";
import {withStyles} from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import Fade from "@material-ui/core/Fade";
import CircularProgress from "@material-ui/core/CircularProgress"
import Button from "@material-ui/core/Button";
import {httpPost, httpPut} from "../../api/requests";


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

interface RegistrationProps {

}

interface RegistrationState {
    login: string;
    email: string;
    password: string;
    passwordConf: string;

    query: string;

    show: boolean;
}

export class Registration extends Component<RegistrationProps, RegistrationState> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            login: "",
            email: "",
            password: "",
            passwordConf: "",
            query: "idle",
            show: false,
        };
    }

    private handleSubmit = async (event: any) => {
        event.preventDefault();
        let path = "http://localhost:5000/api/signup";

        this.setState({
            query: "progress"
        });

        let data = {
            "UserName": this.state.login,
            "Email": this.state.email,
            "Password": this.state.password,
            "RepeatedPassword": this.state.passwordConf
        };

        const responce = await httpPost('signup', {body: data});

        console.log(responce.status);
        console.log(responce.body);
        this.setState({
            query: "success"
        });
    };

    private changeState = (value: boolean) => {
        this.setState({show: value})
    };

    public render() {
        let props = {
            "onClick": null,
            "href": "#"
        };
        let trigger = {
            comp: "a",
            text: "Sign Up",
            attr: props
        };

        return (
            <CustomModal show={this.state.show} handlShow={this.changeState} trigger={trigger} title="Registration">
                <Form onSubmit={this.handleSubmit}>
                    <FormLine controlId="Login"
                              type="text"
                              placeholder="Login123"
                              labelText="Login"
                              as="input"
                              onChange={(e: any) => {
                                  this.setState(
                                      {login: e.target.value})
                              }}/>
                    <FormLine controlId="Email"
                              type="email"
                              placeholder="exmple@fksis.by"
                              labelText="Email"
                              as="input"
                              onChange={(e: any) => {
                                  this.setState({email: e.target.value})
                              }}/>
                    <FormLine controlId="Password"
                              type="password"
                              placeholder="seCrEtPassw0rd"
                              labelText="Password"
                              as="input"
                              onChange={(e: any) => {
                                  this.setState({password: e.target.value})
                              }}/>
                    <FormLine controlId="ConPassword"
                              type="password"
                              placeholder="confirm password"
                              labelText=""
                              as="input"
                              onChange={(e: any) => {
                                  this.setState({passwordConf: e.target.value})
                              }}/>
                    <Form.Group as={Row}>
                        <Col sm={{span: 10, offset: 2}}>
                            <div className={
                                // @ts-ignore
                                this.props.placeholder}>
                                {this.state.query === "success" ? (
                                    <Typography>Success!</Typography>
                                ) : (
                                    <Fade
                                        in={this.state.query === "progress"}
                                        style={{
                                            transitionDelay: this.state.query === "progress" ? "800ms" : "0ms"
                                        }}
                                        unmountOnExit
                                    >
                                        <CircularProgress/>
                                    </Fade>
                                )}
                            </div>
                        </Col>
                    </Form.Group>
                    <Form.Group as={Row}>
                        <Col sm={{span: 10, offset: 2}}>
                            <Button className={
                                // @ts-ignore
                                this.props.button}
                                    type="submit"
                                    variant="contained"
                                    color="primary"
                                // @ts-ignore
                                    style={{"background-color": "#2196f3"}}>Ok</Button>
                        </Col>
                    </Form.Group>
                </Form>
            </CustomModal>
        )
    }
}


// @ts-ignore
export default withStyles(styles)(Registration);