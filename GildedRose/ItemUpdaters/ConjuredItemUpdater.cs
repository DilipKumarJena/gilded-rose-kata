namespace GildedRoseKata.ItemUpdaters
{
    public class ConjuredItemUpdater : IItemUpdater
    {
        private const int DegradeRate = 2;

        public void Update(Item item)
        {
            DegradeQuality(item);

            item.SellIn--;

            if (item.SellIn < 0)
            {
                DegradeQuality(item);
            }
        }

        // Dropping by 2 at once can overshoot below 0, so clamp instead of a plain guard.
        private static void DegradeQuality(Item item)
        {
            item.Quality = System.Math.Max(QualityLimits.Min, item.Quality - DegradeRate);
        }
    }
}
