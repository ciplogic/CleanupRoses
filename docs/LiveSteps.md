Start time: 7:40 AM (from the time the directory is copied locally)

Tools: Linux/.Net 5/Rider IDE (includes R# that would suggest some refactors)



Steps (with time stamp):

7:40 create this file and try to compile the app. It builds but it targets .Net 2.1

7:43 Cleanup files like .gitignore and make the repo pushable on just created GitHub project:

7:50 Make tests work (no renaming, just it works)

7:52 Split project in "app" and "tests"

7:56 Quick R# fixes:

* Move namespaces and navigate trough code. csharpcore -> Roses.App.Tests or Roses.App

* Remove target type name: 
```
new List<Item> { new Item() { Name = ...
```
becomes:
```
new List<Item> { new() { Name = ...
```

* Fix naming in solution (use R#'s naming, so making sure is consistent) Will fix parameter and variable names

* remove redundant "this" 

8:04. More R#:

* Change for to foreach (using R#): GildedRose.UpdateQuality

* move "IList" to "List" as there is no inherited API advantage of usign IList, but it makes the code cleaner.

* use "var" everywhere. 

