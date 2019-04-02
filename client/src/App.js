import {Component} from "react";
import {Catalog} from "./internall/catalog/catalog";
import React from "react";
import {Menu} from "./internall/menu"


class App extends Component {
    render() {
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