# Assignment 2: Fairies to fairies, dust to dust
Hi! You might notice there are very few comments throughout most of the classes. Well, it's because I put them here! Instead of including the same comment at every point throughout all the classes, it was much quicker to just include them all in the notes section in this readme file.

### notes
- All the test cases have been reimplemented in Program.cs as to not end up assigning several different fairies for each demonstration, but instead to use the same ones for all demonstrations.
- Almost all the constructor variables are private as the user does not need to access them directly. If the user wants to see the values they can print out the whole object and view it. The user should also not be able to change any of the values post item creation (at least I would believe) which contributed to the decision to leave these as private and not include a get or set.
- All ToString functions were overridden to instead show all the details in a formatted matter.
- Some redundant functions were removed for simpler, more performant, or more secure implementations. There should be comments where those functions used to be.