# Gilded Rose Refactoring Kata (C# / xUnit)

Refactoring exercise for the Gilded Rose inventory system, including support
for a new "Conjured" item type. Requirements: see `GildedRoseRequirements.md`.

## Build

    dotnet build GildedRose.sln -c Debug

## Run

    dotnet run --project GildedRose -- 10

## Test

    dotnet test

## What was done

I started by running the existing tests and keeping them green as a safety
net before changing anything. `UpdateQuality()` was one large nested
if/else covering every item type at once, so once I understood the current
behaviour I split it into one small class per item type
(`NormalItemUpdater`, `AgedBrieUpdater`, `SulfurasUpdater`,
`BackstagePassUpdater`), with an `ItemUpdaterFactory` picking the right one
per item. That made the Conjured item easy to add afterwards as its own
class, without touching any of the existing ones.

`Item.cs` was left unmodified, per the exercise requirements.

## Tests

17 tests in total:

- One unit test per rule for each item type (normal, Aged Brie, Sulfuras,
  Backstage passes, Conjured), including quality cap/floor and boundary
  cases (e.g. a bonus bump blocked by the quality cap).
- Two approval tests (`ApprovalTest.Foo`, `ApprovalTest.ThirtyDays`) that
  run the CLI simulation and compare output against a checked-in reference
  file, used as a regression check during the refactor.
