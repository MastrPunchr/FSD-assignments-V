function timerDone(): Promise<void> {
    return new Promise (resolve => {
        setTimeout(() => resolve(), 1000);
    });
}

timerDone()
    .then(() => console.log('1 second has passed'));

const p = new Promise<void>(resolve => {
    setTimeout(() => resolve(), 1000);
});

function getNumberCallback(callback: (n: number) => void) {
    setTimeout(() => callback(10), 1000);
}

function getNumberPromise(): Promise<number>{
    return new Promise(resolve => {
        getNumberCallback(n => resolve(n));
    });
}

getNumberPromise()
    .then(n => console.log(n));

function loadNumber(id: number, callback: (error: Error | null, n?: number) => void) {
    setTimeout(() => {
        if(id === 1){
            callback(null, 10);
        } else {
            callback(new Error(`Nothing saved for id ${id}`), 1000);
        }
    })
}

loadNumber(1, (error, n) => {
    if (error) {
        console.log(error.message);
    } else {
        console.log(n);
    }
});

function loadNumberAsync(id: number): Promise<number>{
    return new Promise((resolve, reject) =>{
        loadNumber(id, (error, n) => {
            if (error || n === undefined){
                reject(error);
            } else {
                resolve(n);
            }
        });
    });
}

loadNumberAsync(1).then(n => console.log(n));
loadNumberAsync(2).catch(error => console.log(error.message));