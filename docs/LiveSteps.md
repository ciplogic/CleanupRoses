Start time: 7:40 AM (from the time the directory is copied locally)

Tools: Linux/.Net 5/Rider IDE (includes R# that would suggest some refactors)

Note: as not stated, before every commit/push I do run tests (manually, using `dotnet test` in termninal)

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

8:10

Extract larger methods to what they (appear to) do

8:20 Add extra safety in Item: set C# nulability to on and make "Name" not-null and "init" only. 

Add "RosesSpecs.txt" to docs (I had it open as a browser tab, but I forgot to add it to this repo as a reference)

8:25 Start extracting magic string constants. It would make it less likely to get typos. Especially GildedRose.cs is aggravating. Also Program.cs contains them.

8:43 Prepare the splitting/refactoring of updating item's state. So for this the structure is split logically so it makes more sense. This is WIP but still is a step in right direction.

8:48 Split the large method in 3:

```
   public static class DailyItemUpdatesLogic
    {
         public static void UpdateDailyItemState(this Item item)
        {
            UpdateDailyQuality(item);

            UpdateDailySellIn(item);

            UpdateDailyQualityFinalAdjustment(item);
        }

```
