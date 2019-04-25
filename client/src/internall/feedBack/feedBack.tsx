import {Component} from "react";
import {BaseModal} from "../../components/baseModal";
import React from "react";
import {Button, Form} from "react-bootstrap";
import {addNewRecipeStore} from "../../stores/authentication/addNewRecipeStore";
import {FormLine} from "../../components/form/fields/formLine";

interface State {
    show: boolean;
    value: string;
}

export class FeedBack extends Component<{}, State> {
    constructor(props: any) {
        super(props);

        this.state = {
            show: false,
            value: '',
        };
    }

    private sendMessage = () => {
        alert(this.state.value);
        this.setState({show: false});
    };

    private handleChange = (event: any) => {
        this.setState({value: event.target.value});
    };

    private getFooter = () => {
        return (
            <div className="d-flex justify-content-between">
                <span></span>
                <Button variant="primary"
                        type="submit"
                        onClick={this.sendMessage}>
                    Send
                </Button>
            </div>)
    }

    render() {
        // let props = {
        //     "onClick": null,
        //     "className": "list-group-item list-group-item-action",
        //     "disabled": false,
        //     "href": "#feedback"
        // };
        // let trigger = {
        //     comp: "button",
        //     text: "Feedback",
        //     attr: props
        // };

        return (
            <Form>
                <FormLine controlId="Recipe"
                          type=""
                          placeholder="Write here your wish"
                          labelText="Write here your wish"
                          as="textarea"
                          value={this.state.value}
                          onChange={this.handleChange}/>
                <Button variant="primary"
                        type="submit"
                        onClick={this.sendMessage}>
                    Send
                </Button>
            </Form>
        );
    }
}