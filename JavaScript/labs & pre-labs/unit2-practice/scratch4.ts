import {getUser} from './lesson1/api.ts';

async function showName(){
    const user = await getUser(1); //Forgetting await!!
    console.log(user.name);
}

getUser(1)
    .then(user => {
        user.email;
    })
    .then(email => console.log(email));

getUser(1)
    .then(user => {
        return user.email;
    })
    .then(email => console.log(email));
    
async function getUserOrNull(id: number){
    try{
        const user = await getUser(id);
        return user;
    } catch {
        return null;
    }
}

getUserOrNull(999)
.then(result => console.log('resolved with: ', result))
.catch(error => console.log('rejected anyway: ', error.message));

async function getNames(ids: number[]): Promise<string[]>{
    const names: string[] = [];
    // ids.forEach(async id => {
    //     const user = await getUser(id);
    //     names.push(user.name);
    // });
    for (const id of ids){
        const user = await getUser(id);
        names.push(user.name);
    }
    return names;
}

getNames([1, 2, 3]).then(names => console.log(names));