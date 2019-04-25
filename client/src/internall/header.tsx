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

    private signOut = async () => {
        let response = await signOut();
        if(response.succeeded){
            userContextStore.signOut();
        }
    };

    public render() {
        const user = userContextStore.user;

        return (
            <div className="d-flex">
                {user ? (
                    <div className="loguot">
                        <span className="user_logo" >{user.login}</span>
                        <a href="#" onClick={() => this.signOut()}>SignOut</a>
                    </div>
                ) : this.getUnAuthorizedActions() }
            </div>
        );
    }

    private getUnAuthorizedActions = () => {
        return (
            <>
                <div className="login-registr">
                    <Button onClick={this.openLoginModal}>SignIn</Button>
                    <Button onClick={this.openRegistrationModal}>Registration</Button>
                </div>

                <LoginModal ref={this.loginModalRef} id={'modal_login'}/>
                <RegistrationModal ref={this.registrationModalRef} id={'modal_reg'}/>
            </>
        )
    };

    private openLoginModal = () => {
        // this.loginModalRef.current!.show();
        // @ts-ignore
        $('#modal_login').modal();
        // @ts-ignore
        $('#modal_login').modal('open');
    };

    private openRegistrationModal = () => {
        // this.registrationModalRef.current!.show();
        // @ts-ignore
        $('#modal_reg').modal();
        // @ts-ignore
        $('#modal_reg').modal('open');
    };

}