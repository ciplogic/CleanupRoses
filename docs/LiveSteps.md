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

8:52 Make smallest safe cleanups in large method:
- X = X+1  -> X++; X = X-1 -> X--
- invert ifs and getting out "switch" strings out of if comparisons.

8:58 Cleanup (still WIP) switch case with removing redundancies.

For example duplicate switch case cases and remove true/false if branches

9:15 work on a mini-class to extract named logic to be out of UpdatesLogic.

This class will be committed first to see integration later. This class uses generics just to say that I can use generics.
It is not mandatory

9:30 Update code to use the split by name logic.

9:35 Make methods static and outside of the main method so the setup looks less clutered.

9:42 Update the latest clean code of quality updaters so it looks very concise and extensible.

10:00 Update names and try to make the code to match the specification. The code in `ItemQualityUpdaters.BackstagePassesToATafkal80EtcConcert` has a lot of state that is passsed around and instead it should be aligned with spec. 
WIP but committed just so the reviewer can see what is it about.

10:05 The code inside `ItemQualityUpdaters` seems very fragile (meaning that making the cases a bit different, would make the code to break), so I will add unit tests around ItemQualityUpdaters and I will make the code more functional

10:40 Added unit tests for both regular updaters and final adjustments code.

10:42: Cleanup `ItemQualityUpdatersValues.BackstagePassesToATafkal80EtcConcertQuality` which was said at 10:05 as being "fragile" so it is more explicit.

10:45 Small break

10:50 Handle the broken "Conjored" part that is not working. As implementation is concerned the spec states:
"	- "Conjured" items degrade in Quality twice as fast as normal items"

so I took Default methods and I did double the decrease quality based on it.

Because Conjured items are fixed now, the ApprovalTest of 30 days content file has to be updated. It has to be done and before making the change, I added local unit tests around method `CondjuredQuality` so it is less likely there is any regression with the update.

11:03 Rename `GildedRoseTest` to `IntegrationTests`.

11:20 Reading carefully the specification (and as I prepare to wrap up) it canb e noticed that some items are named by category but they are hard-coded as value. For instance: "Backstage passes" or "Conjured" items would not be handled if the concert name is changed, so a mapping between the item and the cateogry is done. Updaters will be now mapped instead of magic constants: `ItemNames. ...`, now they will be moved to `ItemCategory. ...` . If this change would not be made, every time a new Conjdured item would appear, the code would have to be updated. Now it shouldn't.

11:30 Use JSON to setup the app, so no code changes need to be done if a different configuration is necessary.

11:40 Make code Async/Await

Few post review notes:

1. Modifying the Items class even if not allowed to add extra safety
(noticed and decided explicitly to not follow trough, but depending on the circumstance, I would revert it... when I write this, I am mixed, so I would talk with the goblin):

In spec says to not touch the "Items" class, but the code will not compile with added "Nullability" safety of C# (that I enabled it).

If the goblin is very evil, I will have to reduce the trivial change back and disable nulability (or set it as "warnings").

So, if the code is really not touchable, consider:
```
   public class Item
    {
        public string Name { get; init; } = "";
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }
```
is reverted and it is getting the original form with no Nullability check.

2. Using generics for NamedBehaviorRunner: it is not necessary, just though I wanted to explicitly show that I know generics well. In fact, it may look better without generics and the call to "Invoke" will have 1 parameter less (which is nice).

3. "Clean Code" and in my experience, commenting inside methods (and comments not getting updated) make the code less readable (in long term). Given this, I will not add comments in code excluding there is really a huge need for them (as when I write this, I didn't think yet if I should comment the APIs yet, but I may do it).
