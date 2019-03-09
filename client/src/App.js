import React, { Component } from 'react';
import './App.css';
import "bootstrap/dist/css/bootstrap.css";
import { ListGroup, Form, FormControl, Button,Table } from "react-bootstrap";
import Modal from "react-bootstrap/Modal";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import ModalFooter from "react-bootstrap/ModalFooter";
import {MyModal} from "./Components/testTS";

export function sendMessage(m) {
    alert(m)
}


class ModalLogin extends Component{
    constructor(props, context) {
        super(props, context);

        this.handleShow = this.handleShow.bind(this);
        this.handleClose = this.handleClose.bind(this);

        this.state = {
            show: false,
        };
    }

    handleClose() {
        this.setState({ show: false });
    }

    handleShow() {
        this.setState({ show: true });
    }

    render() {
        return (
            <div>
                <a href="#" onClick={this.handleShow}>
                    LOG IN
                </a>

                <Modal show={this.state.show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Log in</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form>
                            <Form.Group as={Row} controlId="Email">
                                <Form.Label column sm={2}>
                                    Email
                                </Form.Label>
                                <Col sm={10}>
                                    <Form.Control type="email" placeholder="Email" />
                                </Col>
                            </Form.Group>
                            <Form.Group as={Row} controlId="Password">
                                <Form.Label column sm={2}>
                                    Password
                                </Form.Label>
                                <Col sm={10}>
                                    <Form.Control type="password" placeholder="Password" />
                                </Col>
                            </Form.Group>
                            <Form.Group as={Row} controlId="Check">
                                <Col sm={{ span: 10, offset: 2 }}>
                                    <Form.Check label="Remember me" />
                                </Col>
                            </Form.Group>

                            <Form.Group as={Row}>
                                <Col sm={{ span: 10, offset: 2 }}>
                                    <Button type="submit" >Sign in</Button>
                                </Col>
                            </Form.Group>
                        </Form>
                    </Modal.Body>
                    {/*<Modal.Footer>*/}
                        {/*<Button variant="secondary" onClick={this.handleClose}>*/}
                            {/*Close*/}
                        {/*</Button>*/}
                        {/*<Button variant="primary" onClick={this.handleClose}>*/}
                            {/*Save Changes*/}
                        {/*</Button>*/}
                    {/*</Modal.Footer>*/}
                </Modal>
            </div>
        );
    }
}


class ModalReg extends Component{
    render() {
        return(
            <MyModal>
                <Modal.Header closeButton>
                    <Modal.Title>Registration</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group as={Row} controlId="Login">
                            <Form.Label column sm={2}>
                                Login
                            </Form.Label>
                            <Col sm={10}>
                                <Form.Control type="text" placeholder="Login123" />
                            </Col>
                        </Form.Group>
                        <Form.Group as={Row} controlId="Email">
                            <Form.Label column sm={2}>
                                Email
                            </Form.Label>
                            <Col sm={10}>
                                <Form.Control type="email" placeholder="Email" />
                            </Col>
                        </Form.Group>
                        <Form.Group as={Row} controlId="Password">
                            <Form.Label column sm={2}>
                                Password
                            </Form.Label>
                            <Col sm={10}>
                                <Form.Control type="password" placeholder="Password" />
                            </Col>
                        </Form.Group>
                        <Form.Group as={Row} controlId="ConPassword">
                            <Form.Label column sm={2}>
                                Password
                            </Form.Label>
                            <Col sm={10}>
                                <Form.Control type="password" placeholder="Confirm password" />
                            </Col>
                        </Form.Group>
                        <Form.Group as={Row}>
                            <Col sm={{ span: 2, offset: 10   }}>
                                <button className="btn btn-primary" type="button" onClick={()=>{}}>Ok</button>
                            </Col>
                        </Form.Group>
                    </Form>
                </Modal.Body>
            </MyModal>
        )
    }
}

class ModalAbout extends Component{
    constructor(props, context) {
        super(props, context);

        this.handleShow = this.handleShow.bind(this);
        this.handleClose = this.handleClose.bind(this);

        this.state = {
            show: false,
        };
    }

    handleClose() {
        this.setState({ show: false });
    }

    handleShow() {
        this.setState({ show: true });
    }

    render() {
        return (
            <div>
                <ListGroup.Item action onClick={this.handleShow}>
                    About
                </ListGroup.Item>
                <Modal show={this.state.show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>About FoodBook</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <div>
                            <span>
                                BSUIR Minsk 2k19
                            </span>
                        </div>
                    </Modal.Body>
                </Modal>
            </div>
        );
    }
}

class FeedBack extends Component{
    constructor(props, context) {
        super(props, context);

        this.handleShow = this.handleShow.bind(this);
        this.handleClose = this.handleClose.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.sendMessage = this.sendMessage.bind(this);

        this.state = {
            show: false,
            value: ''
        };
    }

    handleClose() {
        this.setState({ show: false });
    }

    handleShow() {
        this.setState({ show: true });
    }

    sendMessage() {
        sendMessage(this.state.value);
        this.setState({ show: false });
    }

    handleChange(event) {
        this.setState({value: event.target.value});
    }

    render() {
        return (
            <div>
                <ListGroup.Item action onClick={this.handleShow}>
                    FeedBack
                </ListGroup.Item>
                <Modal show={this.state.show} onHide={this.handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>About FoodBook</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form.Group controlId="exampleForm.ControlTextarea1">
                            <Form.Control value={this.state.value} as="textarea" rows="3" placeholder="Write here your wish"
                                          onChange={this.handleChange}/>
                        </Form.Group>
                    </Modal.Body>
                    <ModalFooter>
                        <div className="d-flex justify-content-between">
                            <span></span>
                            <Button variant="primary" type="submit" action onClick={this.sendMessage}>
                                Send
                            </Button>
                        </div>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
}

class Menu extends Component{
    render(){
        return(
                <div className="d-flex right-side-bar col-2">
                    <ListGroup as="ul" defaultActiveKey="#link1" className="col-12" >
                        <li>
                            <span className="stroke">👍</span>
                            <span className="logo">FoodBook</span>
                        </li>
                        <li>
                            <a href="#" className="button plus"></a>
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

class Header extends Component{
    render() {
        return (
            <div className="d-flex justify-content-between">
                <div>
                    <Form inline>
                        <FormControl type="text" placeholder="Search" className="mr-sm-4" />
                        <Button variant="outline-success">Search</Button>
                    </Form>
                </div>
                <div>
                    <div>
                        <ModalLogin/>
                    </div>
                    <div>
                        <ModalReg/>
                    </div>
                </div>
            </div>
        );
    }
}

class Catalog extends Component{
    render() {
        return (
            <div className="d-flex flex-column col-10">
                <Header/>
                <div>
                    <Table striped bordered hover>
                        <thead>
                        <tr>
                            <th>#</th>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th>Username</th>
                        </tr>
                        </thead>
                        <tbody>
                        <tr>
                            <td>1</td>
                            <td>Mark</td>
                            <td>Otto</td>
                            <td>@mdo</td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Jacob</td>
                            <td>Thornton</td>
                            <td>@fat</td>
                        </tr>
                        </tbody>
                    </Table>
                </div>
            </div>
        );
    }
}

class App extends Component {
    render(){
    return (
      <div className="App" height="100%">
          <div className="d-flex" height="100%">
              <Menu/>
              <Catalog/>
          </div>

      </div>
    );
  }
}

export default App;
