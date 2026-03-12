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
  const cards = document.querySelectorAll(".card");
  const restart = document.querySelector(".restart");
  let score = 0;
  let scoreCard = document.getElementById("score");
  let cardClasses = ["fas fa-atom", "fas fa-frog", "fas fa-feather-alt", "fas fa-cogs", "fas fa-anchor", "fas fa-fan", "fas fa-bolt", "fas fa-hat-wizard", "fas fa-apple-alt", "fas fa-bell", "fas fa-bomb", "fas fa-brain"];
  scoreCard.textContent = score;

   cards.forEach((card, i) => {
    card.addEventListener("click", () => {
      score++;
      scoreCard.textContent = score;
      card.className = "cards matched";
    });
    card.children.className = cardClasses[i]; 
  });

  restart.addEventListener("click", () => {
    score = 0;
    scoreCard.textContent = score;
    cardClasses = shuffle(cardClasses);
  });

