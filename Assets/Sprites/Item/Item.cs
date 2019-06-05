using System.Collections;
using System.Collections.Generic;
using XLua;

namespace PackSystem
{
    public enum ItemType
    {
        Weapon,                     //武器
        Armor,                        //防具
        Consumable,              //消耗品
        Others                        //其他    
    }
    //装备基类
    [LuaCallCSharp]
    public class Item
    {

        /// <summary>
        /// 装备类型
        /// </summary>
        public ItemType Item_Type { get; protected set; }
        public int ID { get; private set; }                               //装备ID
        public string Name { get; private set; }                    //装备名称
        public float Buyprice { get; private set; }                  //买入价格
        public float SellPrice { get; private set; }                  //卖出价格
        public string Introduction { get; private set; }         //武器简介
        public string Icon { get; private set; }                      //图标路径

        //构造函数
        public Item(ItemType item_type, int id, string name, float buyprice,
                    float sellprice, string introduction, string icon)
        {
            this.Item_Type = item_type;
            this.ID = id;
            this.Name = name;
            this.Buyprice = buyprice;
            this.SellPrice = sellprice;
            this.Introduction = introduction;
            this.Icon = icon;
        }
    }
}
