
const domain = process.env.REACT_APP_API_SERVER;

export async function httpPost(url: string, options: Options) : Promise<any> {
    return await request("POST", url, options)
}
export async function httpGet(url: string, options: Options) : Promise<any> {
    return await request("GET", url, options)
}
export async function httpPut(url: string, options: Options) : Promise<any> {
    return await request("PUT", url, options)
}

export async function httpDelete(url: string, options: Options) : Promise<any> {
    return await request("DELETE", url, options)
}

export async function httpGrapQl(query: any) : Promise<any> {
    return await request("POST", `graphql`, {body: query})
}

async function request(method: string, url: string, options: Options) {
    const response = await fetch(`${domain}/api/${url}`, {
        method,
        headers: getHeaders(),
        body: getBody(method, options),
        credentials: "include",
        mode: "cors"
    });

    return response;
}

function getBody(method: string, options: Options): string | null {
    if (method === 'GET') {
        return null;
    }

    return JSON.stringify(options.body)
}

function getHeaders() {
    let myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    return myHeaders;
}

declare type Options = {
    body?: any;
}