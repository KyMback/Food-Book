
const domain = "http://qa-food-book.herokuapp.com";

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
    let xhr = new XMLHttpRequest();
    xhr.open(method, `${domain}/api/${url}`, false);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.withCredentials = true;
    if(method==='GET'){
        xhr.send();
    }else{
        xhr.send(JSON.stringify(options.body));
    }

    // const response = (method === 'GET')?
    //     await fetch(`${domain}/api/${url}`, {
    //         method,
    //         credentials: "include"
    //     })
    //     :  await fetch(`${domain}/api/${url}`, {
    //         method,
    //         mode: "no-cors",
    //         headers: getHeaders(),
    //         body: JSON.stringify(options.body),
    //         credentials: "include"
    //     });

    return {status: xhr.status, body: xhr.responseText};
}

function getHeaders(){
    let myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    return myHeaders;
}

declare type Options = {
    body?: any;
}