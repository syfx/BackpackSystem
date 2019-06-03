using UnityEngine;
using System.Collections;


//武器类
public class Weapon : Item
{
    public float Attack { get; private set; }               //攻击力
    public float AttackSpeed { get; private set; }          //攻击速度


    public Weapon(ItemType item_type, int id, string name, float buyprice, float sellprice,
                    string introduction, string icon, float attack, float attackspeed) : 
                    base(item_type, id, name, buyprice, sellprice, introduction, icon)
    {
        this.Attack = attack;
        this.AttackSpeed = attackspeed;
    }
}
