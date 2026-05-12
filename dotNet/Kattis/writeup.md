# 1. Parking
The Parking problem calculates the total cost of parking for 3 trucks based on how many are parked simultaneously at any given minute.

Key Steps:
1. Parse the three hourly rates: A (1 truck), B (2 trucks), C (3 trucks)
2. Adjust rates: multiply by 2 and 3 respectively (B is charged per 2-hour, C per 3-hour block)
3. Read arrival and departure times for all 3 trucks
4. Iterate through each minute from 1 to the latest departure time
5. For each minute, count how many trucks are parked (arrival ≤ minute < departure)
6. Apply the corresponding rate based on truck count
7. Sum all costs


**Edge cases accounted for:**
- Truck arrives and departs at the same time
  - arrival <= minute < departure makes sure the cost remains 0 since it did not stay for any minutes
- No trucks parked
  - Cost = 0 so no rate is applied

# 2. Radio commercials
The Radio Commercials problem finds the best contiguous sequence of commercial breaks to maximize profit, where profit for each break equals students watching minus the cost to air it.

Key Steps:
1. Parse N (number of breaks) and P (cost per break)
2. Read student counts for each break
3. Iterate through each break from 0 to N-1
4. For each break, calculate net profit = students[i] − P
5. Use a greedy approach: decide whether to extend the current sequence or start fresh
   - Keep a running total of profit from consecutive breaks
   - If adding the next break's profit keeps the total positive, add it
   - If the total becomes negative, reset to 0 and start fresh
   - `currentProfit = Math.Max(0, currentProfit + netProfit)` enforces this decision

6. Track the maximum profit found across all positions
7. Output the best profit (0 if no profitable sequence exists)

**Edge cases:**
- All breaks unprofitable (students[i] < P)	
  - Output is 0
- Single profitable break
  - Algorithm finds it in one pass
- Cost exceeds all student counts	
  - All net profits are negative; algorithm never does anything and outputs 0


# 3. Magical cows
The Magical cows problem simulates cows that magically duplicate and the movement of said cows into an adequate amount of farms to not go over the inspector's maximum amount of cows per farm

Key steps:
1. Parse C (capacity), N (initial farms), M (how many inspections there will be)
2. Build frequency map where `freq[cowCount] = numberOfFarmsWithThatCount`
    - Example: `freq[5] = 3` means 3 farms have 5 cows
3. Precompute all days up to day `arr.Max[]` (the last day the inspector visits)
4. Answer queries in O(1) by looking up with `res[day]`

**Edge cases:**
- Initial farm count = 1	
  - Works fine; frequency map handles single entries
    All farms same initial size	Precomputation remains efficient (few unique counts)
- Farm count explodes (2^50)	
  - Frequency map prevents storing 2^50 objects—only tracks unique sizes
- No farms exceed capacity	
  - All farms just double each day; frequency map updates smoothly
- Inspection day = 0	
  - res[0] stores initial farm count before any doubling
- Multiple farms split simultaneously	
  - Each group in frequency map splits independently; counts add correctly

**Optimizations:**
- Using a frequency map instead of storing individual farms - dramatically reduces memory
- Precomputes all days and stores them in array res[] to easily be called later on instead of computing on demand