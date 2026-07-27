using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void GeneralItem_ReducesByOnePerDay()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 11, Quality = 22 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(10, Items[0].SellIn);
        Assert.Equal(21, Items[0].Quality);
    }

    [Fact]
    public void GeneralItem_QualityNeverGoesNegative()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void AgedBrie_IncreasesInQualityWithAge()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(1, Items[0].Quality);
    }

    [Fact]
    public void AgedBrie_QualityNeverExceedsFifty()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.AgedBrie, SellIn = 2, Quality = 50 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void AgedBrie_IncreasesByTwo_AfterSellInHasPassed()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.AgedBrie, SellIn = 0, Quality = 1 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(3, Items[0].Quality);
    }

    [Fact]
    public void Sulfuras_NeverChanges()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].SellIn);
        Assert.Equal(80, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_IncreaseByOne_WhenMoreThanTenDaysLeft()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.BackstagePasses, SellIn = 15, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(21, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_IncreaseByTwo_WhenTenDaysOrFewerLeft()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.BackstagePasses, SellIn = 10, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(22, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_IncreaseByThree_WhenFiveDaysOrFewerLeft()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.BackstagePasses, SellIn = 5, Quality = 20 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(23, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_SecondBonusBump_IsBlockedByQualityCap()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.BackstagePasses, SellIn = 10, Quality = 49 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(50, Items[0].Quality);
    }

    [Fact]
    public void BackstagePasses_DropsToZero_AfterConcertHasPassed()
    {
        IList<Item> Items = new List<Item> { new Item { Name = ItemNames.BackstagePasses, SellIn = 0, Quality = 40 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void Conjured_DegradesTwiceAsFastAsNormalItem()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(2, Items[0].SellIn);
        Assert.Equal(4, Items[0].Quality);
    }

    [Fact]
    public void Conjured_DegradesFourTimesAsFast_AfterSellInHasPassed()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(6, Items[0].Quality);
    }

    [Fact]
    public void Conjured_QualityNeverGoesNegative()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 1 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(0, Items[0].Quality);
    }

    [Fact]
    public void NullNamedItem_FallsBackToNormalUpdater_WithoutThrowing()
    {
        IList<Item> Items = new List<Item> { new Item { Name = null, SellIn = 5, Quality = 10 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(4, Items[0].SellIn);
        Assert.Equal(9, Items[0].Quality);
    }
}
