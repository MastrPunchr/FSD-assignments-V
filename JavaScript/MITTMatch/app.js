// Shuffle function from http://stackoverflow.com/a/2450976

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
let cards = document.querySelectorAll(".card");
const restart = document.querySelector(".restart");
let score = 0;
let scoreCard = document.getElementById("score");
let nextCard = document.querySelector("#next-card");

  let shuffle = function(array) {
    let currentIndex = array.length, temporaryValue, randomIndex;

    while (currentIndex !== 0) {
      randomIndex = Math.floor(Math.random() * currentIndex);
      currentIndex -= 1;
      temporaryValue = array[currentIndex];
      array[currentIndex] = array[randomIndex];
      array[randomIndex] = temporaryValue;
    }
    return array;
  card.addEventListener("click", () => {
    if (card.className !== "card matched") {
      score++;
      scoreCard.textContent = score;
      card.className = "card show";
      let cardClass = card.children[0].className.split(" ");
      let nextCardClass = nextCard.children[0].className.split(" ");
      setTimeout(() => {
        if (
          cardClass[cardClass.length - 1] ==
          nextCardClass[nextCardClass.length - 1]
        ) {
          card.className = "card matched";
          //add a shuffle for nextCard here
        } else {
          card.className = "card";
        }
      }, 700);
    }
  });
  card.addEventListener("hover", () => {
    card.style.cursor = "pointer";
  });
});

restart.addEventListener("click", () => {
  score = 0;
  scoreCard.textContent = score;
  cards.forEach((card) => {
    card.className = "card";
  });
});
