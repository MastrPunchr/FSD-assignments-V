function getName(): Promise<string> {
    return new Promise(resolve => {
        setTimeout(() => resolve('PTEC G12'), 1000);
    })
}

getName()
    .then(value => console.log(value));

type User = {id: number; name: string; email: string;};

function getUser(id: number): Promise<User> {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            const user = findUser(id);
            if(user){
                resolve(user);
            } else {
                reject(new Error(`User ${id} not found`));
            }
        }, 1000);
    });
}

getUser(1)
    .then(user => console.log(user.name))
    .catch(error => console.log(error.message));
    
const users: User[] = [
  { id: 1, name: 'Ana Silva', email: 'ana@example.com' },
  { id: 2, name: 'Ben Okafor', email: 'ben@mitt.ca' },
  { id: 3, name: 'Chen Wei', email: 'chen@example.com' },
];

function findUser(id: number): User | undefined {
    return users.find(u => u.id === id);
}

console.log(findUser(1));
console.log(findUser(999));