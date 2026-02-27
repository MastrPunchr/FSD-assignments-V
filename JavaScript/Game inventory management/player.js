const prompt = require("prompt-sync")();

function main(){
    let players = [{name: "temp", inventory: {milk: 2, banana: 3}}, {name: "george", inventory: {pee: 3}}];

    function addPlayer(){
        let named = prompt("Enter the player name (leave blank to exit): ");
        if(!named){
            return;
        } else {
            //Check if named is already a player
            for(let i = 0; i < players.length; i++){
                if(players[i].name == named){
                    console.log(`Player ${named} already exists in database.`);
                    return;
                }
            }
            players.push({name: named, inventory: {}});
            console.log(`Player added to the list! Current Players: ${players.length}`);
        }
    }

    function removePlayer(){
        let named = prompt("Enter the player name (leave blank to exit): ");
        for(let i = 0; i < players.length; i++){
            //checks if the player exists or not
            if(players[i].name == named){
                players = players.filter((player) => player.name != named);
                console.log(`${named} removed!`);
                return;
            } else {
                continue;
            }
        }
        console.log(`${named} not found in database.`);
    }

    function playerEdit(){
        let choice = 0; //This is used as the index for which player to modify in the players array
        let option = ""; //This string stores the user input from functions that take a number from a list of options within the playerEdit function while also acting as a boolean for their respective do while loops
        for(let i = 0; i < players.length; i++){
            let playerInventory = [];
            for(key in players[i].inventory){
                playerInventory.push(`"${key}: ${players[i].inventory[key]}"`);
            }
            console.log(`${i+1}.  ${players[i].name}, inventory = [${playerInventory}]`);
        }
        console.log(`${players.length+1}.  Go Back`);
        do{
            option = prompt();
            if(option == players.length+1){
                return;
            } else if (option > players.length+1 || option <= 0 || isNaN(option)){
                console.log("Invalid choice! Going back to main menu...");
                return;
            } else if(option > 0 && option <= players.length){
                choice = Number(option)-1;
                option = "";
            }
        } while(option);  

        do{
            option = prompt(`Editing ${players[choice].name}... What do you want to change? (1. Username, 2. Inventory, 3. Go Back)\n> `);

            switch(option){
                case "1":
                    changeName();
                    break;
                case "2":
                    editInventory();
                    break;
                case "3":
                    console.log("Going back to main menu...");
                    break;
                default:
                    console.log("Invalid choice! Try again.");
            }
        } while(option != 3);

        function changeName(){ //I considered using the option variable here but figured it would end up causing issues if the program were to be further expanded
            let rename = prompt("Enter the new username (leave blank for unchanged): ");
            if(!rename) return;
            //Checks to make sure no other players already have this name
            for(let i = 0; i < players.length; i++){
                if(players[i].name == rename){
                    console.log(`Player ${rename} already exists in database.`);
                    return;
                }
            }
            players[choice].name = rename;
            console.log(`Name changed to ${rename}!`);
        }

        function editInventory(){
            do{
                option = prompt(`Editing the inventory of ${players[choice].name}... What would you like to do? (1. add item, 2. remove item, 3. list items, 4. Go Back)\n> `);
                switch(option){
                    case "1":
                        addItem();
                        return;
                    case "2":
                        removeItem();
                        return;
                    case "3":
                        listItems();
                        return;
                    case "4":
                        console.log("Going back to main menu...");
                        return;
                    default:
                        console.log("Invalid choice! Try again.");
                        return;
                }
            } while(option != 4);

            function addItem(){
                let itemName = prompt("Enter the item name (leave empty to exit): ");
                if(!itemName) return;
                let itemQty = prompt("Enter the quantity: ");
                if(itemQty < 0 || isNaN(itemQty)){
                    console.log("Invalid quantity, returning to main menu...");
                    return;
                } else if (!players[choice].inventory[itemName]) {
                    players[choice].inventory[itemName] = itemQty;
                } else {
                    players[choice].inventory[itemName] += itemQty;
                }
                console.log(`${itemQty}x ${itemName} added!`);
            }

            function removeItem(){
                let itemName = prompt("Enter the item name: ");
                let itemQty = prompt("Enter the quantity: ");
                if (players[choice].inventory[itemName]) {
                    if(itemQty < 0 || isNaN(itemQty)){
                        console.log("Invalid quantity, returning to main menu...");
                        return;
                    } else if (players[choice].inventory[itemName] < itemQty) {
                        console.log(`Cannot remove ${itemQty}. Only ${players[choice].inventory[itemName]} available.`);
                    }else {
                        players[choice].inventory[itemName] -= itemQty;
                        if (players[choice].inventory[itemName] <= 0) delete players[choice].inventory[itemName];
                        console.log(`${itemQty} of ${itemName} removed!`);
                    }
                } else {
                    console.log(`${itemName} not found in inventory.`);
                }
            }

            function listItems(){
                let inventoryList = `${players[choice].name}'s inventory:\n`;
                for(let item in players[choice].inventory){
                    inventoryList += `${item}: ${players[choice].inventory[item]}\n`;
                }
                console.log(inventoryList.trim() || "Inventory is empty!");
            }
        }
    }

    function display(){
        for(let i = 0; i < players.length; i++){
            let playerInventory = [];
            for(key in players[i].inventory){
                playerInventory.push(`"${key}: ${players[i].inventory[key]}"`);
            }
            console.log(`${players[i].name}, inventory = [${playerInventory}]`);
        }
    }

    //Main loop
    let userInput = "";
    do {
        userInput = prompt("What would you like to do? (1. Add Player, 2. Delete Player, 3. Show Players, 4. Edit Players, 5. Exit >");

        switch(userInput){
            case "1":
                addPlayer();
                continue;
            case "2":
                removePlayer();
                continue;
            case "3":
                display();
                continue;
            case "4":
                playerEdit();
                continue;
            case "5":
                console.log("Thanks for storing your players!")
                return;
            default:
                console.log("Invalid input");
                continue;
        }
    } while (userInput !=5);
}

main();