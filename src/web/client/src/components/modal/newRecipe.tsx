import {Component} from "react";
import {BaseModal} from "../baseModal";
import React from "react";
import {Button, Col, Form, Modal} from "react-bootstrap";
import Row from "react-bootstrap/Row";
// @ts-ignore
import {FormLine} from "../form/fields/formLine";
import {createRecipe} from "../../api/recipes/recipesApi/recipesApi";

interface NewRecipeState {
    title: string;
    recipe: string;
    show: boolean;
}

export class NewRecipe extends Component<{}, NewRecipeState> {
    constructor(props: any, context: any) {
        super(props, context);

        this.state = {
            title: "",
            recipe: "",
            show: false
        };
    }

    private handleChangeTitle = (event: any) => {
        this.setState({
            title: event.target.value,
        });
    };

    private handleChangeRecipe = (event: any) => {
        this.setState({
            recipe: event.target.value,
        });
    };

    private handleSubmit = async (event: any) => {
        event.preventDefault();
        let data = {
            "Title": this.state.title,
            "Ingredients": this.state.recipe
        };

        console.log(await createRecipe(data));
    };

    public render() {
        return (
            <BaseModal show={this.state.show} title="New Recipe">
                <Form onSubmit={this.handleSubmit}>
                    <FormLine controlId="Title"
                              type="text"
                              placeholder="New Recipe"
                              labelText="Title"
                              as="input"
                              onChange={this.handleChangeTitle}/>
                    <FormLine controlId="Recipe"
                              type=""
                              placeholder="Recipe text"
                              labelText="Recipe"
                              as="textarea"
                              row={5}
                              onChange={this.handleChangeRecipe}/>
                    <Form.Group as={Row}>
                        <Col sm={{span: 10, offset: 2}}>
                            <Button type="button" value="Submit" onClick={this.handleSubmit}>Save</Button>
                        </Col>
                    </Form.Group>
                </Form>
            </BaseModal>
        )
    }
}