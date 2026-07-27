namespace GildedRoseKata.ItemUpdaters
{
    public class AgedBrieUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            if (item.Quality < QualityLimits.Max)
            {
                item.Quality++;
            }

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < QualityLimits.Max)
            {
                item.Quality++;
            }
        }
    }
}
