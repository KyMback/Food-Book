import {Component} from "react";
import React from "react";
import {Button, Form, FormControl} from "react-bootstrap";
import {ModalLogin} from "./modal/login";
import {Registration} from "./modal/registration";
import {userContextStore} from "../stores/userContextStore";
import {observer} from "mobx-react";

@observer
export class Header extends Component<{load: any;}, {}> {
    public render() {
        const user = userContextStore.activeUser;

        return (
            <div className="d-flex justify-content-between">
                <div>
                    <Form inline>
                        <FormControl type="text" placeholder="Search" className="mr-sm-4"/>
                        <Button variant="outline-success">Search</Button>
                    </Form>
                </div>
                {user ? (
                        <div className="d-flex justify-content-between col-2">
                            <span>{user.name}</span>
                            <a href="#">SignOut</a>
                        </div>
                    ) : (
                        <div className="d-flex justify-content-between col-2">
                            <ModalLogin load={this.props.load}/>
                            <Registration/>
                        </div>
                    )}
            </div>
        );
    }
}