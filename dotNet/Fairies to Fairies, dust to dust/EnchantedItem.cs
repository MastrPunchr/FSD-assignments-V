namespace FairiesToFairies;

public class EnchantedItem
{
    private string _itemName;
    private int _enchantmentPower;
    private Fairy _enchantedBy;
    //The rationale behind this boolean is in the comment on line 29
    public bool IsActivated { get; private set; }

    public EnchantedItem(string itemName, int enchantmentPower, Fairy enchantedBy)
    {
        _itemName = itemName;
        _enchantmentPower = enchantmentPower;
        _enchantedBy = enchantedBy;
        IsActivated = true;
    }

    public string DeactivateEnchantment()
    {
        if (IsActivated)
        {
            IsActivated = !IsActivated;
            return $"{_itemName} is now deactivated";
        }
        return $"{_itemName} is already deactivated";
    }
    
    //Removed GetActivationStatus. Opted to make IsActivated public with a private setter so that the user can read the variable but not assign it. The private setter makes sure the variable can still be assigned within the constructor class but not be reassigned by the user for security reasons.
    
    public override string ToString()
    {
        return $"Item: {_itemName}\nEnchantment power: {_enchantmentPower}\nEnchanted by: {_enchantedBy}\nIs activated: {IsActivated}";
    }
}