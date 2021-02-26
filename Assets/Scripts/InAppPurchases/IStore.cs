public interface IStore {
    
    //IAP requires products of 2 variants
    //Consumable(limited amount of purchases, eg. Disable Ads purchase should only be able to happen once)
    //Non-Consumable - such as boosters
    
    public bool purchase();
    
}
