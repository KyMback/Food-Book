import {Component} from "react";
import {Catalog} from "./internall/catalog/catalog";
import React from "react";
import {Menu} from "./internall/menu"
import { Progress } from "./components/common/Progress";


class App extends Component {
    render() {
        return (
            <div className="App" height="100%">
                <div className="d-flex" height="100%">
                    <Menu/>
                    <Catalog/>
                </div>
                <Progress />
            </div>
        );
    }
}
export default App;