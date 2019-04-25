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
import {updateRecipeStore} from "../../stores/authentication/updateRecipeStore";
import {observer} from "mobx-react";

interface NewRecipeState {
    show: boolean;
}

@observer
export class UpdateRecipe extends Component<{magic?: object}, NewRecipeState> {

    private fields: InputFieldProps[] = [
        {
            placeholder: "New title",
            labelText: "Title",
            type: "text",
            as: "input",
            value: updateRecipeStore.title,
            onChange: (newValue: string) => updateRecipeStore.title = newValue,
        },
        {
            type: "",
            as: "textarea",
            placeholder: "Recipe text",
            labelText: "Recipe",
            value: updateRecipeStore.ingredients,
            row: 5,
            onChange: (newValue: string) => updateRecipeStore.ingredients = newValue,
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
                <BaseModal onClose={this.hide} show={this.state.show} title={updateRecipeStore.title} id={'recipe_update'}>
                    <Form>
                        <FormLine controlId="Title"
                                  type="text"
                                  placeholder="New title"
                                  labelText="Title"
                                  as="input"
                                  value={updateRecipeStore.title}
                                  onChange={(newValue: string) => updateRecipeStore.title = newValue}/>
                        <FormLine controlId="Recipe"
                                  type=""
                                  placeholder="Recipe text"
                                  labelText="Recipe"
                                  as="textarea"
                                  value={updateRecipeStore.ingredients}
                                  row={5}
                                  onChange={(newValue: string) => updateRecipeStore.ingredients = newValue}/>
                        <Form.Group as={Row}>
                            <Col sm={{span: 10, offset: 2}}>
                                <Button  onClick={this.onCreate}>Update</Button>
                            </Col>
                        </Form.Group>
                    </Form>
                </BaseModal>
            </div>
        );

    }

    public showWindow = () => {
        // @ts-ignore
        $('.modal').modal();
        // @ts-ignore
        $('#recipe_update').modal('open');
    };

    private hide = () => {
        // this.setState({show: false});
        // @ts-ignore
        $('#recipe_update').modal('close');
        // $('#menu-').children()[1].children[0].children[0].click();
        // @ts-ignore
        $('#test1 > div > div > table > tfoot > tr > td > div > div.MuiInputBase-root-161.MuiTablePagination-input-151 > div > div').click();
        // @ts-ignore
        document.getElementById('menu-').children[1].children[0].children[0].click();
    };

    @action
    private onCreate = async (event: MouseEvent<any>) => {
        event.preventDefault();
        const result = await updateRecipeStore.create();
        if (result) {
            this.hide();
        }
    };
}