import {httpPost, httpPut} from "../../requests";

export async function createRecipe(data: any) : Promise<any>{
    return await httpPut("recipe", {body: data})
}

export async function getRecipe(data: any) : Promise<any> {
    return await httpPost("qraphql", {body: data})
}