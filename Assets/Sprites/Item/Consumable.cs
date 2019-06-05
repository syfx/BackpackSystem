using UnityEngine;
using System.Collections;

namespace PackSystem
{
    public class Consumable : Item
    {
        public float Hp { get; private set; }
        public float Mp { get; private set; }

        public Consumable(ItemType item_type, int id, string name, float buyprice, float sellprice,
                            string introduction, string icon, float hp, float mp) :
                            base(item_type, id, name, buyprice, sellprice, introduction, icon)
        {
            this.Hp = hp;
            this.Mp = mp;
        }
    }
}