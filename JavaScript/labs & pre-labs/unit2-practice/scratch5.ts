import {API_KEY} from './config.ts';

const text = '{"id": 2, "first_name": "Janet", "last_name": "Weaver"}';
console.log(typeof text);

const user = JSON.parse(text);
console.log(typeof user);
console.log(user.first_name);

async function showStatus(){
    const response = await fetch('https://reqres.in/api/users/2', {
        headers: {'x-api-key': API_KEY},
    });
    console.log(response.status);
    console.log(response.ok);
    //console.log(response);
    const body = await response.json();
    console.log(body.data);

    console.log(body.data.email);
    console.log(body.data.first_name + ' ' + body.data.last_name);
    console.log(`Page ${body.data.page} of ${body.total_pages}`);
    console.log(body.data.length);
    console.log(body.data.first_name);
}

async function showNames(){
    const response = await fetch('https://reqres.in/api/users?page=2', {
        headers: {'x-api-key': API_KEY}
    });
    const body = await response.json();
    const names = body.data.map(user => `${user.first_name} ${user.last_name}`);
    console.log(names);
   //console.log(body.data);

    console.log(`Page ${body.page} of ${body.total_pages}`);
    console.log(body.data.length);
    console.log(body.data[0].first_name);
}

type User = {
    "id": number,
    "email": string,
    "first_name": string,
    "last_name": string,
    "avatar": string
}

const BASE_URL = 'https://reqres.in/api';

async function getUser(id: number): Promise<User>{
    const response = await fetch(`${BASE_URL}/users/${id}`, {
        headers: {'x-api-key': API_KEY}
    });
    const body = await response.json();
    return body.data;
}

//showStatus();
//showNames();
console.log(await getUser(2));