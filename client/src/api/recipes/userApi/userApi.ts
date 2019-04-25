import { ApiResponse, httpGet, httpPost } from "../../requests";
import {async} from "q";
import {UserDetails} from "../../../internall/models/userDetails";

export async function signIn(data: {login: string, password: string}) : Promise<ApiResponse> {
    return await httpPost("signin", {body: data})
}

export async function signOut() : Promise<ApiResponse> {
    return await httpGet("signout",{});
}

export async function signUp(data: any) : Promise<ApiResponse> {
    return await httpPost("signup", {body: data})
}

export async function getUserDetails() : Promise<any> {
    const response =  await httpGet("useraccount/details", {body: {}});
    console.log(response);
    return response.data;
}