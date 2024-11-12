namespace MShop.Catalog.Settings
{
    public class DatabaseSetting : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProducCollectionName { get; set; }
        public string ProducDetailCollectionName { get; set; }
        public string ProducImageCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
        public string FeatureSliderCollectionName { get; set; }
    }
}
