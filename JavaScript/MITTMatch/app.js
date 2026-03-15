// Shuffle function from http://stackoverflow.com/a/2450976

let cardList = document.querySelectorAll(".card");
let cards = document.getElementById("cards");
const restart = document.querySelector(".restart");
let score = 0;
let matched = 0;
let nextCardList = [];
let scoreCard = document.getElementById("score");
scoreCard.textContent = score;
let nextCard = document.querySelector("#next-card");
let isFlipped = false;

//Tried changing this from Fisher-Yates shuffle to Durstenfeld but didn't work since it seemed to only work for editing an array in place.
//Durstenfeld shuffle would be preferred since Fisher-Yates is not technically random but this is a school assignment lol.
let shuffle = function (array) {
  let currentIndex = array.length,
    temporaryValue,
    randomIndex;

  while (currentIndex !== 0) {
    randomIndex = Math.floor(Math.random() * currentIndex);
    currentIndex -= 1;
    temporaryValue = array[currentIndex];
    array[currentIndex] = array[randomIndex];
    array[randomIndex] = temporaryValue;
  }
  return array;
};

function newGame() {
  const shuffledItems = shuffle(Array.from(cardList));

  //Resetting variables to their initial states
  nextCardList = [];
  score = 0;
  matched = 0;
  scoreCard.textContent = score;

  //Adding the classes to next card list and resetting the cards to only have the card class
  cardList.forEach((card) => {
    card.className = "card";
    nextCardList.push(card.children[0].className);
  });

  //Shuffles the cards and the next cards
  nextCardList = shuffle(nextCardList);
  nextCard.children[0].className = nextCardList[matched];
  cards.innerHTML = "";
  shuffledItems.forEach((item) => {
    cards.appendChild(item);
  });
}

//EVENT LISTENERS
cardList.forEach((card) => {
  card.addEventListener("click", () => {
    if (card.className !== "card matched") {
      //DO NOT TRY PUTTING THESE INTO ONE IF STATEMENT. For some reason when you do the entire program has a seizure and freezes
      if (card.className !== "card show" && !isFlipped) {
        score++;
        scoreCard.textContent = score;
        card.className = "card show";
        let flipped = card.children[0].className.split(" ");
        let currentNextCard = nextCard.children[0].className.split(" ");
        isFlipped = !isFlipped;

        //I swear if I can't use setTimeout() I will implode and then promptly explode like I'm a supernova
        setTimeout(() => {
          if (
            flipped[flipped.length - 1] ==
            currentNextCard[currentNextCard.length - 1]
          ) {
            card.className = "card matched";
            matched++;
            if (matched == 12) {
              alert("winner"); //This is literally all the demo shows to do so I didn't add anything extra for showing the number of moves since that's already shown in the score box
            } else {
              nextCard.children[0].className = nextCardList[matched];
            }
          } else {
            card.className = "card";
          }
          isFlipped = !isFlipped;
        }, 700);
      }
    }
  });
  card.addEventListener("hover", () => {
    card.style.cursor = "pointer";
  });
});

restart.addEventListener("click", newGame);

//START
newGame();
