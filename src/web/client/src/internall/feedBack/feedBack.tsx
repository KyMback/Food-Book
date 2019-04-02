import {Component} from "react";
import {CustomModal} from "../../components/customModal";
import React from "react";
import {Button, Form} from "react-bootstrap";

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

    private sendMessage = ()=>{
        alert(this.state.value);
        this.setState({show: false});
    };

    private handleChange = (event: any)=>{
        this.setState({value: event.target.value});
    };

    private changeState = (value: boolean) => {
        this.setState({show: value})
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
        let props = {
            "onClick": null,
            "className": "list-group-item list-group-item-action",
            "disabled": false,
            "href": "#feedback"
        };
        let trigger = {
            comp: "button",
            text: "Feedback",
            attr: props
        };

        return (
            <CustomModal show={this.state.show} handlShow={this.changeState} trigger={trigger} title="About FoodBook" footer={this.getFooter()}>
                <Form.Group controlId="exampleForm.ControlTextarea1">
                    <Form.Control value={this.state.value} as="textarea" rows="3" placeholder="Write here your wish"
                                  onChange={this.handleChange}/>
                </Form.Group>
            </CustomModal>
        );
    }
}