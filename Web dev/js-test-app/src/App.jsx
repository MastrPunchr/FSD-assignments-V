import { useState } from 'react';
import './App.css';
import {buildStyles, CircularProgressbar } from 'react-circular-progressbar';
import 'react-circular-progressbar/dist/styles.css';

function App() {
  const [count, setCount] = useState(0);
  const [goal, setGoal] = useState(10);
  const progress = Math.min((count / goal) * 100, 100);
  document.title="banana";

  return (
    <>
      <div className="app">
        <div className="circle">
          <CircularProgressbar
            value={progress}
            text={`${count}`}
            styles={buildStyles({
              pathTransitionDuration: 0.5,
              pathColor: `#c3973e`,
              textColor: '#bd8d2c',
              trailColor: '#d6d6d6'
            })}
          />
        </div>
        <input type="number"
        value={goal}
        onChange={(e) => setGoal(e.target.value)}
        className='goal-input'
        />
        <div className="buttons">
          <button onClick={() => setCount(count + 1)} disabled={count==goal}>+1</button>
          <button onClick={() => setCount(count - 1)} disabled={count<1}>-1</button>
        </div>
      </div>
    </>
  )
}

export default App
