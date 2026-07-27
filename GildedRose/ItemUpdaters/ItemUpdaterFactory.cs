namespace GildedRoseKata.ItemUpdaters
{
    public static class ItemUpdaterFactory
    {
        public static IItemUpdater For(Item item)
        {
            switch (item.Name)
            {
                case ItemNames.AgedBrie:
                    return new AgedBrieUpdater();

                case ItemNames.Sulfuras:
                    return new SulfurasUpdater();

                case ItemNames.BackstagePasses:
                    return new BackstagePassUpdater();

                default:
                    if (item.Name != null && item.Name.StartsWith(ItemNames.ConjuredPrefix))
                    {
                        return new ConjuredItemUpdater();
                    }
                    return new NormalItemUpdater();
            }
        }
    }
}
