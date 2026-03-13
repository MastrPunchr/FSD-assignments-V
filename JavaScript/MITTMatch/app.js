// Shuffle function from http://stackoverflow.com/a/2450976

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
  }
  let cards = document.querySelectorAll(".card");
  const restart = document.querySelector(".restart");
  let score = 0;
  let scoreCard = document.getElementById("score");

  scoreCard.textContent = score;

   cards.forEach((card) => {
    card.addEventListener("click", () => {
      score++;
      scoreCard.textContent = score;
      card.className = "card show";
    });
  });

  restart.addEventListener("click", () => {
    score = 0;
    scoreCard.textContent = score;
    cards.forEach((card) => {
      card.className = "card";
    });
  });

