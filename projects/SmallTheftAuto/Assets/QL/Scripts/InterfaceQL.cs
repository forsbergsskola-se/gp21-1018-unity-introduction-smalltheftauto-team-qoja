public interface IWeapon
{
   IHand EquippedTo { get; }
   int Power { get; }
   //void EquipTo(IHand hand){}
   //void UnEquip(){}
}

public interface IHand
{
    IWeapon Weapon { get; set; }
}
