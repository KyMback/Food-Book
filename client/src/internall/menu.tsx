import {Component, RefObject} from "react";
import {NewRecipe} from "../components/modal/newRecipe";
import React from "react";
import {ListGroup} from "react-bootstrap";
import {ModalAbout} from "./aboutModal/aboutModal";
import {FeedBack} from "./feedBack/feedBack";
import {Button} from "reactstrap";
import {catalogStore} from "../stores/catalog/catalogStore";
import {userContextStore} from "../stores/userContextStore";
import {observer} from "mobx-react";


@observer
export class Menu extends Component{
    public render() {
        const user = userContextStore.user;
        return (
            <div className="d-flex right-side-bar col-2">
                <ListGroup as="ul" defaultActiveKey="#link1" className="col-12">
                    <li>
                        <span className="stroke">👍</span>
                        <span className="logo">FoodBook</span>
                    </li>
                    {user ? (
                        <li>
                            <NewRecipe/>
                        </li>
                    ): (<li></li>)}

                    <ListGroup.Item action href="#link1">
                        <Button onClick={this.favorites}>Favourites</Button>
                    </ListGroup.Item>
                    {user ? (
                        <ListGroup.Item action href="#link2">
                            <Button onClick={this.myRecipes}>My recipe</Button>
                        </ListGroup.Item>
                    ): (<li></li>)}

                    <hr/>
                    <ModalAbout/>
                    <FeedBack/>
                </ListGroup>
            </div>

        )
    }

    private favorites = () => {
        catalogStore.resetToDefaults()
    };

    private myRecipes = () => {
        catalogStore.openMyRecipe()
    }

}