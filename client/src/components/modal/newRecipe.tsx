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
                <button className="btn-floating btn-large waves-effect waves-light red"
                        onClick={this.show}>
                    <i className="material-icons">add</i></button>
                <BaseModal onClose={this.hide} show={this.state.show} title="New Recipe" id={'recipe_create'}>
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
        // this.setState({show: true});
        // @ts-ignore
        $('.modal').modal();
        // @ts-ignore
        $('#recipe_create').modal('open');
    };

    private hide = () => {
        // this.setState({show: false});
        // @ts-ignore
        $('#recipe_create').modal('close');
        // @ts-ignore
        $('#test2 > div > div > div.MuiPaper-root-5.MuiPaper-elevation2-9.MuiPaper-rounded-6 > table > tfoot > tr > td > div > div.MuiInputBase-root-161.MuiTablePagination-input-151 > div > div').click();
        // @ts-ignore
        $('#menu- > div.MuiPaper-root-5.MuiMenu-paper-104.MuiPaper-elevation8-15.MuiPaper-rounded-6.MuiPopover-paper-105 > ul > li.MuiButtonBase-root-92.MuiListItem-root-236.MuiListItem-default-239.MuiListItem-gutters-244.MuiListItem-button-245.MuiListItem-selected-247.MuiMenuItem-root-233.MuiMenuItem-selected-235.MuiMenuItem-gutters-234.MuiTablePagination-menuItem-152').click();
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