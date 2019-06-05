using UnityEngine;
using System.Collections;

namespace PackSystem
{
    public class Armor : Item
    {
        public float HP { get; private set; }          //生命值加成
        public float Power { get; private set; }       //防御力（护甲）

        public Armor(ItemType item_type, int id, string name, float buyprice, float sellprice,
                        string introduction, string icon, float hp, float power) :
                        base(item_type, id, name, buyprice, sellprice, introduction, icon)
        {
            this.HP = hp;
            this.Power = power;
        }
    }
}

