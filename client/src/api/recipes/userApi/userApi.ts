import {httpGet, httpPost} from "../../requests";
import {async} from "q";

export async function SignIn(data: any) : Promise<any> {
    return await httpPost("signin", {body: data})
}

export async function SignOut(data: any) : Promise<any> {
    return await httpGet("signout", {body: data})
}

export async function SignUp(data: any) : Promise<any> {
    return await httpPost("signup", {body: data})
}

export async function GetUserDetails() {
    return await httpGet("useraccount/details", {body: {}})
}