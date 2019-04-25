import { Component, RefObject } from "react";
import React from "react";
import { Form, FormControl } from "react-bootstrap";
import { LoginModal } from "./authorization/login/loginModal";
import { RegistrationModal } from "./authorization/registration/registrationModal";
import { userContextStore } from "../stores/userContextStore";
import { observer } from "mobx-react";
import Button from "reactstrap/lib/Button";
import { signOut } from "../api/recipes/userApi/userApi";

@observer
export class Header extends Component {
    private loginModalRef: RefObject<LoginModal> = React.createRef<LoginModal>();
    private registrationModalRef: RefObject<RegistrationModal> = React.createRef<RegistrationModal>();

    public render() {
        const user = userContextStore.user;

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
                        <span>{user.login}</span>
                        <a href="#" onClick={() => signOut()}>SignOut</a>
                    </div>
                ) : this.getUnAuthorizedActions() }
            </div>
        );
    }

    private getUnAuthorizedActions = () => {
        return (
            <>
                <div className="d-flex justify-content-between ">
                    <Button onClick={this.openLoginModal}>SignIn</Button>
                    <Button onClick={this.openRegistrationModal}>Registration</Button>
                </div>

                <LoginModal ref={this.loginModalRef}/>
                <RegistrationModal ref={this.registrationModalRef}/>
            </>
        )
    };

    private openLoginModal = () => {
        this.loginModalRef.current!.show();
    };

    private openRegistrationModal = () => {
        this.registrationModalRef.current!.show();
    };

}