import {getUser, getOrders} from './lesson1/api.ts'

// type Order = {
//     id: number;
//     userId: number;
//     total: number;
// }

// const orders: Order[] = [
//     { id: 101, userId: 1, total: 25 },
//     { id: 102, userId: 2, total: 40 },
//     { id: 103, userId: 3, total: 15 }
// ];

// function getOrders(userId: number): Promise<Order[]>{
//     return new Promise(resolve => {
//         setTimeout(() => resolve(orders.filter(o => o.userId === userId)), 1000);
//     });
// }

// getOrders(1).then(list => console.log(list));
// getOrders(3).then(list => console.log(list));

getUser(1)
    .then(user => {
        getOrders(user.id)
            .then(list => console.log(list));
    });

const namePromise = getUser(1).then(user => user.name);
console.log(namePromise);
namePromise.then(name => console.log(name.toUpperCase()));

getUser(999)
    .then(user => getOrders(user.id))
    .then(list => console.log(list))
    .catch(error => console.log(error.messages));