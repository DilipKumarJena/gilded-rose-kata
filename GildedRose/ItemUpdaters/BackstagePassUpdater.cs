namespace GildedRoseKata.ItemUpdaters
{
    public class BackstagePassUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            if (item.Quality < QualityLimits.Max)
            {
                item.Quality++;

                if (item.SellIn < BackstagePassThresholds.MediumBonusSellIn && item.Quality < QualityLimits.Max)
                {
                    item.Quality++;
                }

                if (item.SellIn < BackstagePassThresholds.HighBonusSellIn && item.Quality < QualityLimits.Max)
                {
                    item.Quality++;
                }
            }

            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = QualityLimits.Min;
            }
        }
    }
}
