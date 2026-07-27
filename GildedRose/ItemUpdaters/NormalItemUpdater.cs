namespace GildedRoseKata.ItemUpdaters
{
    public class NormalItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            if (item.Quality > QualityLimits.Min)
            {
                item.Quality--;
            }

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality > QualityLimits.Min)
            {
                item.Quality--;
            }
        }
    }
}
