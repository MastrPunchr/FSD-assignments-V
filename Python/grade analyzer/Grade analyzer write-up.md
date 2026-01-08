# Write up
### Problems:
**Final_grade:**
- When you would initially run the program, you would end up with multiple division by zero errors. These division by zero errors were the result of modifying the original lists within the library when dropping the smallest grade to calculate the averages. This was a simple fix of cloning the original lists from the library to a temporary variable that would be edited instead, thus keeping the original lists intact.
- Improper average calculations: the averages would consistently appear lower than what they should have been. This was caused by line 19 saying "drop = max(x)", therefore dropping the highest grade as opposed to the lowest grade. This was able to be rectified by simply changing it to "drop = min(x)" to properly remove the lowest grade.

**Class_median:**
- Initially, the median would consistenlty return one of the students's averages instead of the actual median. This turned out to be because the system was only designed to handle a class with an odd number of students and could not properly handle the division for an even numbered class. This was easliy rectified by adding an if statement to check whether there was an even or odd amount of students in the class, and to add the middle two averages and then divide them by two if it were even so as to get the correct median.

**Largest_single_jump:**
- Initially the jump numbers would be returning very small amounts of at most 2 points, which turned out to be the result of subtracting the current value from the next one (current - next) when the required equation was next - current. This was easily fixed by changing line 41 from "jump = scores[i] - scores[i+1]" to "jump = scores[i+1] - scores[i]".

**Top_n:**
- At first, this function would print out the lowest two grades in the class in ascending order alongside their grade to several decimal places, including the name and grade in a tuple. To fix the order of students, the reversed=True attribute needed to be added to the sorted list. Then to make it only return the names of who placed the highest, the first element of the first n tuples would be added to a new list so that the grades would not be included; returning this new list instead. N is also no longer permanently set as 2 and is now declared when the function is called

**Assignment_averages:**
- This function would initially only show the first 3 assignments due to an unnecessary subtraction. This was easily fixed by changing line 62 from "for i in range(num_assignments - 1):" to "for i in range(num_assignments):".

**Pass_rate:**
- Threshold would originally always be 60 with a student needing a higher grade than 60 to be considered a pass. The function would also always return a single digit number or a decimal. These were fixed by setting threshold to be defined when the function is called and changing > to >= on line 73, and multiplying the final product by 100 and including a percentage symbol in the line where it is called so that it would display a propper decimal.

**Summarize:**
- The only change here was including a percentage symbol after getting the pass rate so as to get a proper percentage.

### Challenges:
- The only real challenge encountered during the debugging process was finding out what was causing the division by zero errors. After going through step by step with the debugger I noticed that when "Final_grade" was called, it would be given an empty list of what once was the grades. After further debugging I had noticed that final_grade was removing the characters from the initial list, thus making it so it would be shorter and shorter on every run through until it was empty; thus leading the program to try and divide 0 by 0. This was then easily rectified by copying the list to a separate local variable so as to leave the original list intact.