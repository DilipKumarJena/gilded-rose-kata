namespace GildedRoseKata
{
    public static class BackstagePassThresholds
    {
        // Checked before SellIn is decremented, so these are one higher than
        // the "10 days" / "5 days" wording in the requirements doc.
        public const int MediumBonusSellIn = 11;
        public const int HighBonusSellIn = 6;
    }
}
