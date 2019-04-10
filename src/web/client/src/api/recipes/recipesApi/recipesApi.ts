import {httpGraphQl, httpPut} from "../../requests";
import { Query, QueryResult } from "material-table";

export async function createRecipe(data: any) : Promise<any>{
    return await httpPut("recipe", {body: data})
}

export async function getRecipe(data: any) : Promise<any> {
    return await httpGraphQl(data)
}

export async function getRecipes(request: Query) : Promise<QueryResult> {
    const query = `query test($from: Int!, $count: Int!) {
                        recipes(from: $from, count: $count) {
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
    const variables = {
        from: request.page * request.pageSize,
        count: request.pageSize,
    };
    const result = await httpGraphQl({query, variables});

    return {
        data: result.data!.recipes.entities,
        page: request.page,
        totalCount: result.data!.recipes.count
    };
}