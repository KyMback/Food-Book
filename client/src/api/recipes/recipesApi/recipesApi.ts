import {httpGraphQl, httpPut} from "../../requests";
import { Query, QueryResult } from "material-table";
import {getUserDetails} from "../userApi/userApi";
import {async} from "q";
import {func} from "prop-types";
import {userContextStore} from "../../../stores/userContextStore";

export async function createRecipe(data: any) : Promise<any>{
    return await httpPut("recipe", {body: data})
}

export async function getRecipe(data: any) : Promise<any> {
    return await httpGraphQl(data)
}

export async function getMyRecipes(request: Query) : Promise<QueryResult>{
    return await getRecipes(request, false)
}

export async function getAllRecipes(request: Query) : Promise<QueryResult>{
    return await getRecipes(request, true)
}

export async function getRecipes(request: Query, get_all: boolean) : Promise<QueryResult> {
    const query = `query test($from: Int!, $count: Int!, $ownerId: String) {
                        recipes(from: $from, count: $count, ownerId: $ownerId) {
                            entities {
                                id
                                title
                                ingredients
                                createdBy
                                createdOn
                            }
                            count
                        }
                    }`;
    let variables;
    if(get_all) {
        variables = {
            from: request.page * request.pageSize,
            count: request.pageSize,
            // @ts-ignore
        };
    }else{
        variables = {
            from: request.page * request.pageSize,
            count: request.pageSize,
            // @ts-ignore
            "ownerId": userContextStore.user.id,
        }
    }
    const result = await httpGraphQl({query, variables});

    return {
        data: result.data!.recipes.entities,
        page: request.page,
        totalCount: result.data!.recipes.count
    };
}