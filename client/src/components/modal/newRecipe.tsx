import {Component, MouseEvent, RefObject} from "react";
import {BaseModal} from "../baseModal";
import React from "react";
import {Col, Form, Modal} from "react-bootstrap";
import Row from "react-bootstrap/Row";
// @ts-ignore
import {FormLine} from "../form/fields/formLine";
import {InputFieldProps, makeInputFields} from "../form/factories/inputFieldsFactory";
import {loginStore} from "../../stores/authentication/loginStore";
import {action} from "mobx";
import {addNewRecipeStore} from "../../stores/authentication/addNewRecipeStore";
import {Button} from "reactstrap";

interface NewRecipeState {
    show: boolean;
}

export class NewRecipe extends Component<{}, NewRecipeState> {
    private fields: InputFieldProps[] = [
        {
            placeholder: "New Recipe",
            labelText: "Title",
            type: "text",
            as: "input",
            onChange: (newValue: string) => addNewRecipeStore.title = newValue,
        },
        {
            type: "",
            as: "textarea",
            placeholder: "Recipe text",
            labelText: "Recipe",
            row: 5,
            onChange: (newValue: string) => loginStore.password = newValue,
        },
    ];

    constructor(props: any, context: any) {
        super(props, context);
        this.state = {
            show: false
        };
    }

    public render() {
        return (
            <div>
                <Button onClick={this.show}>Create recipe</Button>
                <BaseModal onClose={this.hide} show={this.state.show} title="New Recipe">
                    <Form>
                        <FormLine controlId="Title"
                                  type="text"
                                  placeholder="New Recipe"
                                  labelText="Title"
                                  as="input"
                                  onChange={(newValue: string) => addNewRecipeStore.title = newValue}/>
                        <FormLine controlId="Recipe"
                                  type=""
                                  placeholder="Recipe text"
                                  labelText="Recipe"
                                  as="textarea"
                                  row={5}
                                  onChange={(newValue: string) => addNewRecipeStore.ingredients = newValue}/>
                        <Form.Group as={Row}>
                            <Col sm={{span: 10, offset: 2}}>
                                <Button  onClick={this.onCreate}>Create</Button>
                            </Col>
                        </Form.Group>
                    </Form>
                </BaseModal>
            </div>
        );
    }

    public show = () => {
        addNewRecipeStore.resetToDefaults();
        this.setState({show: true});
    };

    private hide = () => {
        this.setState({show: false});
    };

    @action
    private onCreate = async (event: MouseEvent<any>) => {
        event.preventDefault();
        const result = await addNewRecipeStore.create();
        if (result) {
            this.hide();
        }
    };
}