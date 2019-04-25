import {Component, RefObject} from "react";
// import {Catalog} from "./internall/catalog/catalog";
import React from "react";
import {LoginModal} from "./internall/authorization/login/loginModal";
import {Header} from "./internall/header";
import MaterialTable, {Query, QueryResult} from "material-table";
import {deleteRecipes, getAllRecipes, getMyRecipes, updateRecipes} from "./api/recipes/recipesApi/recipesApi";
import {signOut} from "./api/recipes/userApi/userApi";
import {userContextStore} from "./stores/userContextStore";
import {observer} from "mobx-react";
import {NewRecipe} from "./components/modal/newRecipe";
import {updateRecipeStore} from "./stores/authentication/updateRecipeStore";
import {UpdateRecipe} from "./components/modal/updateRecipe";
import {BaseRecipesTable} from "./components/table/baseTable";
import {MyRecipesTable} from "./components/table/myTable";
import {FeedBack} from "./internall/feedBack/feedBack";
import {ReadRecipe} from "./components/modal/readRecipe";
// import {Menu} from "./internall/menu"
// import {Progress} from "./components/common/Progress";


// class App extends Component {
//     render() {
//         return (
//             <div className="App" height="100%">
//                 <div className="d-flex" height="100%">
//                     <Menu/>
//                     <Catalog/>
//                 </div>
//                 <Progress />
//             </div>
//         );
//     }
// }

@observer
class App extends Component {
    private loginModalRef: RefObject<LoginModal> = React.createRef<LoginModal>();
    private updateModalRef: RefObject<UpdateRecipe> = React.createRef<UpdateRecipe>();
    private readModalRef: RefObject<ReadRecipe> = React.createRef<ReadRecipe>();
    private commonTable: RefObject<BaseRecipesTable> = React.createRef<BaseRecipesTable>();

    private renderCommonDetails(rowData: any): React.ReactNode {
        return (
            <div className="col-6 recepi">
                <h4>{rowData.title}</h4>
                <label><i>Created by: </i><strong>{rowData.createdBy}</strong></label>
                <h5>Recipe:</h5>
                <p><span>{rowData.ingredients}</span></p>
                <label><i>Created on: </i>{rowData.createdOn}</label>
            </div>
        )
    }

    private renderUsersDetails(rowData: any): React.ReactNode {
        return (
            <div className="col-6 recepi">
                <h4>{rowData.title}</h4>
                <label><i>Created by: </i><strong>{rowData.createdBy}</strong></label>
                <h5>Recipe:</h5>
                <p><span>{rowData.ingredients}</span></p>
                <label><i>Created on: </i>{rowData.createdOn}</label>
            </div>
        )
    }

    private deleteRecipe = async (id: string) => {
        return await deleteRecipes({id: id});
    };

    render() {
        const user = userContextStore.user;

        return (
            <div className="App">
                <div className="main">
                    <div>
                        <nav className="nav-extended">
                            <div className="nav-wrapper">
                                <a href="#" className="brand-logo">Logo</a>
                                <a href="#" data-target="mobile-demo" className="sidenav-trigger"><i
                                    className="material-icons">menu</i></a>
                                <ul id="nav-mobile" className="right hide-on-med-and-down">
                                    <li><Header/></li>
                                </ul>
                            </div>
                            <div className="nav-content">
                                <ul className="tabs tabs-transparent">
                                    <li className="tab"><a className="active" href="#test1">Home</a></li>
                                    <li className="tab"><a href="#test2">My recepy</a></li>
                                    <li className="tab disabled"><a href="#test3">Favorite</a></li>
                                    <li className="tab"><a href="#test4">FeedBack</a></li>
                                </ul>
                            </div>
                        </nav>

                        <ul className="sidenav" id="mobile-demo">
                            <li><a href="sass.html">Sass</a></li>
                        </ul>

                        <div id="test1" className="col s12">
                            <div className={'container table-tes'}>
                                <BaseRecipesTable
                                    ref={this.commonTable}
                                    // @ts-ignore
                                    open={this.openRecipe}/>
                            </div>
                        </div>
                        <div id="test2" className="col s12">
                            <div className={'container table-tes'}>
                                {user ? (
                                    this.getMyRecipeTable()
                                ) : <h3>Please Sign In</h3>}
                            </div>
                        </div>
                        <div id="test3" className="col s12">Test 3</div>
                        <div id="test4" className="col s12">
                            <div className={'container'}>
                                <div className={'container-about'}>
                                    <div className={'about'}>
                                        <h3>About us</h3>
                                        <p className={'flow-text'}> Сайт сделан силами студентов БРУИР 3 курса группы 650502.</p>
                                        <p className={'flow-text'}> В рамках курса ТРиТПО в формате изучения и практического применения гибкой методологии SCRUM.</p>
                                        <p className={'flow-text'}> Целью работы стала работа по этой методологии.</p>
                                        <strong className={'flow-text'}>В разработке учавствовали:</strong>
                                        <ul>
                                            <li><i>Соколовский Александр</i></li>
                                            <li><i>Сахарук Сергей</i></li>
                                            <li><i>Жучкевич Никита</i></li>
                                            <li><i>Левдорович дмитрий</i></li>
                                        </ul>
                                        <br/>
                                    </div>
                                    <div className={'feedback'}>
                                        <FeedBack/>
                                    </div>
                                    <span>BSUIR Minsk 2k19</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <ReadRecipe ref={this.readModalRef}/>
                <UpdateRecipe ref={this.updateModalRef}/>
            </div>
        );
    }

    private openRecipe = (recipe: any) => {
        updateRecipeStore.id = recipe.id;
        updateRecipeStore.title = recipe.title;
        updateRecipeStore.ingredients = recipe.ingredients;
        this.readModalRef.current!.showWindow();
    };

    private updateRecipe = (recipe: any) => {
        updateRecipeStore.id = recipe.id;
        updateRecipeStore.title = recipe.title;
        updateRecipeStore.ingredients = recipe.ingredients;
        this.updateModalRef.current!.showWindow();
    };


    private getMyRecipeTable = () => {
        return (
            <div>
                <MyRecipesTable update={this.updateRecipe} delete={this.deleteRecipe}/>
                <NewRecipe/>
            </div>
        )
    }
}

export default App;