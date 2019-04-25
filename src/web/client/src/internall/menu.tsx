import {Component} from "react";
import {NewRecipe} from "../components/modal/newRecipe";
import React from "react";
import {ListGroup} from "react-bootstrap";
import {ModalAbout} from "./aboutModal/aboutModal";
import {FeedBack} from "./feedBack/feedBack";


export class Menu extends Component <{},{}>{
    public render() {
        return (
            <div className="d-flex right-side-bar col-2">
                <ListGroup as="ul" defaultActiveKey="#link1" className="col-12">
                    <li>
                        <span className="stroke">👍</span>
                        <span className="logo">FoodBook</span>
                    </li>
                    <li>
                        <NewRecipe/>
                    </li>
                    <ListGroup.Item action href="#link1">
                        Favourites
                    </ListGroup.Item>
                    <ListGroup.Item action href="#link2">
                        My recipes
                    </ListGroup.Item>
                    <hr/>
                    <ModalAbout/>
                    <FeedBack/>
                </ListGroup>
            </div>

        )
    }
}