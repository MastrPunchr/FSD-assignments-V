import {getUser} from './lesson1/api.ts';

async function showName(id: number){
    try{
        const user = await getUser(id);
        console.log(user.name);
    } 
    catch (error){
        console.log((error as Error).message);
    }
}

async function getUserName(id: number): Promise<string>{
    const user = await getUser(id);
    return user.name;
}

async function greet(id: number) {
    const name = await getUserName(id);
    console.log(`Hello, ${name}`);
}

// showName();
// console.log("--------------");
// getUser(1)
//     .then(user => console.log(user.name));

console.log(getUserName(1));
getUserName(1).then(name => console.log(name));

greet(2);