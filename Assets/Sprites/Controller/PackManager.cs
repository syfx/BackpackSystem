using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using XLua;

public class PackManager : MonoBehaviour{

    public TextAsset textAsset;

    private static PackManager _Instance;
    public static PackManager Instance { get { return _Instance; } }
    private bool IsShowTooltip = false;          //是否正在显示Tooltip
    private bool IsDrag = false;                      //是否正在拖拽装备
    //装备信息
    private Dictionary<int, Item> ItemList = new Dictionary<int, Item>();

    [Tooltip("信息提示框")]
    public Tooltip tooltip;
    [Tooltip("拖拽时临时储存装备的格子")]
    public DragUI DragItem;
    [Tooltip("背包类")]
    public PackPanel ThePack;
    [Tooltip("添加装备按钮")]
    public Button AddItem;

    LuaEnv luaEnv;

    private void Awake()
    {
        _Instance = this;
        luaEnv = new LuaEnv();

        Load("PackManager.lua", "luasprite.v1");
        GridUI.OnEnter += GridUI_OnEnter;
        GridUI.OnExit += GridUI_OnExit;
        GridUI.OnLeftBeginDrag += GridUI_OnLeftBeginDrag;
        GridUI.OnLeftEndDrag += GridUI_OnLeftEndDrag;
        AddItem.onClick.AddListener(() => StoreItem(UnityEngine.Random.Range(0, 11)));
    }

    private void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GameObject.Find("Canvas").transform as RectTransform,
            Input.mousePosition, null, out position);
        if (IsDrag)
        {
            //显示提示框
            DragItem.ShowToolTip();
            DragItem.SetPosition(position);
        }
        else if (IsShowTooltip)
        { 
            //显示提示框
            tooltip.ShowToolTip();
            tooltip.SetPosition(position);
        }
    }

    /// <summary>
    /// 添加装备
    /// </summary>
    /// <param name="ItemID"></param>
    public void StoreItem(int ItemID)
    {
        if (ThePack.IsFull())
            return;
        //字典里是否有这个ID
        if (!ItemList.ContainsKey(ItemID))
            return;
        Item TheItem = ItemList[ItemID];
        Transform Grid = ThePack.GetNullGrid();//得到一个空装备格
        CreateItem(TheItem, Grid);
    }

    /// <summary>
    /// 移除装备
    /// </summary>
    public void RemoveItem(int ItemID)
    {
        ItemModel.RemoveDate(ItemList[ItemID].Name);
    }

    /// <summary>
    /// 数据加载
    /// </summary>
    private void Load(string resName, string resPath)
    {
        //从服务器加载PackManager.lua脚本
        StartCoroutine(LoadAssetBundel(resName, resPath));
        LoadItemData();
    }

    /// <summary>
    /// 装备数据加载
    /// </summary>
    public void LoadItemData()
    {
        string path_w1 = "ItemImage/INV_2H_Auchindoun_01";
        Weapon w1 = new Weapon(ItemType.Weapon, 1, "萨德的弯刀", 300, 180, "萨德使用过的弯刀", path_w1, 20, 0);
        string path_w2 = "ItemImage/Ability_Warrior_WeaponMastery";
        Weapon w2 = new Weapon(ItemType.Weapon, 2, "幻影之刃", 600, 400, "世上武功，唯快不破", path_w2, 30, 0.2f);
        string path_w3 = "ItemImage/Ability_Warrior_Charge";
        Weapon w3 = new Weapon(ItemType.Weapon, 3, "泣血刀", 800, 500, "唯有鲜血才能使它平静下来", path_w3, 60, 0);
        string path_w4 = "ItemImage/INV_Axe_01";
        Weapon w4 = new Weapon(ItemType.Weapon, 4, "间斧", 200, 120, "就是很平常的斧头", path_w4, 13, 0);
        string path_w5 = "ItemImage/INV_Axe_02";
        Weapon w5 = new Weapon(ItemType.Weapon, 5, "万斧", 900, 600, "这个斧头就牛逼了", path_w5, 70, 0);

        string path_a1 = "ItemImage/Ability_Warrior_ShieldMastery";
        Armor a1 = new Armor(ItemType.Armor, 6, "圣盾", 400, 400, "神圣而不容侵犯的盾牌", path_a1, 0, 30);
        string path_a2 = "ItemImage/INV_Chest_Chain_06";
        Armor a2 = new Armor(ItemType.Armor, 7, "骑士铠甲", 900, 500, "曾经一个跟随一个骑士的铠甲", path_a2, 300, 20);
        string path_a3 = "ItemImage/INV_Helmet_08";
        Armor a3 = new Armor(ItemType.Armor, 8, "振奋头盔", 600, 400, "带上它就有一种莫名的兴奋感", path_a3, 300, 0);

        string path_c1 = "ItemImage/INV_Potion_06";
        Consumable c1 = new Consumable(ItemType.Consumable, 9, "大血瓶", 100, 60, "一种由恢复生命的药草浸泡而成的液体", path_c1, 200, 0);
        string path_c2 = "ItemImage/INV_Potion_03";
        Consumable c2 = new Consumable(ItemType.Consumable, 10, "大蓝瓶", 100, 60, "一种由恢复蓝量的药草浸泡而成的液体", path_c2, 0, 150);

        ItemList.Add(w1.ID, w1);
        ItemList.Add(w2.ID, w2);
        ItemList.Add(w3.ID, w3);
        ItemList.Add(w4.ID, w4);
        ItemList.Add(w5.ID, w5);
        ItemList.Add(a1.ID, a1);
        ItemList.Add(a2.ID, a2);
        ItemList.Add(a3.ID, a3);
        ItemList.Add(c1.ID, c1);
        ItemList.Add(c2.ID, c2);
    }

    /// <summary>
    /// 加载lua资源包
    /// </summary>
    public IEnumerator LoadAssetBundel(string resName, string resPath)
    {
        UnityWebRequest request = UnityWebRequest.GetAssetBundle("https://github.com/syfx/BackpackSystem/raw/master/AssetBundles/LuaScripts/" + resPath);
        yield return request.SendWebRequest();
        AssetBundle ab = (request.downloadHandler as DownloadHandlerAssetBundle).assetBundle;
        TextAsset luaText = ab.LoadAsset<TextAsset>(resName);
    }


    #region 事件回调
    private void GridUI_OnEnter(Transform obj)
    {
        Item item = ItemModel.GetData(obj.name);
        if (item == null)
            return;
        string text = GetToolTipText(item);
        tooltip.UpdateToolTip(text);
        IsShowTooltip = true;
    }
    private void GridUI_OnExit()
    {
        IsShowTooltip = false;
        tooltip.HideToolTip();
    }
    /// <summary>
    /// 左键开始拖拽
    /// </summary>
    /// <param name="obj"></param>
    private void GridUI_OnLeftBeginDrag(Transform obj)
    {
        if (obj.childCount == 0)
            return;
        
        Item item = ItemModel.GetData(obj.name);
        Sprite sprite = Resources.Load<Sprite>(item.Icon) as Sprite;
        DragItem.Set_Item(sprite);
        Destroy(obj.GetChild(0).gameObject);
        IsDrag = true;
    }
    private void GridUI_OnLeftEndDrag(Transform arg1, Transform arg2)
    {
        //扔装备
        if(arg2 == null)
            ItemModel.RemoveDate(arg1.name);
        else
        {
            Item item = ItemModel.GetData(arg1.name);   //得到装备数据
            ItemModel.RemoveDate(arg1.name);                //删除装备数据
            if (arg2.tag == "Grid")     //拖到装备格上
            {
                if (arg2.childCount == 0)       //拖到的格子上没装备
                    CreateItem(item, arg2);
                else
                {
                    Item _item = ItemModel.GetData(arg2.name);      //得到原有装备数据
                    ItemModel.RemoveDate(arg2.name);                    //删除原有装备数据
                    Destroy(arg2.GetChild(0).gameObject);                 //删除原有孩子
                    //交换
                    CreateItem(item, arg2);
                    CreateItem(_item, arg1);
                }
            }
            else//未拖到装备格上，再放回去
                CreateItem(item, arg1);
        }
        IsDrag = false;
        DragItem.HideToolTip();
    }
    #endregion
    /// <summary>
    /// 获取装备的提示信息
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private string GetToolTipText(Item item)
    {
        if (item == null)
            return null;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("<color=red>{0}</color>\n\n", item.Name);

        switch (item.Item_Type)
        {
            case ItemType.Weapon:
                Weapon weapon = item as Weapon;
                if(weapon.Attack != 0)
                    sb.AppendFormat("<color=white>攻击力：{0}</color>\n", weapon.Attack);
                if(weapon.AttackSpeed != 0)
                    sb.AppendFormat("<color=white>攻击速度：{0}</color>\n", weapon.AttackSpeed);
                break;
            case ItemType.Armor:
                Armor armor = item as Armor;
                if (armor.HP != 0)
                    sb.AppendFormat("<color=white>生命值：{0}</color>\n", armor.HP);
                if (armor.Power != 0)
                    sb.AppendFormat("<color=white>防御力：{0}</color>\n", armor.Power);
                break;
            case ItemType.Consumable:
                Consumable consumable = item as Consumable;
                if (consumable.Hp != 0)
                    sb.AppendFormat("<color=blue>恢复HP：{0}</color>\n", consumable.Hp);
                if (consumable.Mp != 0)
                    sb.AppendFormat("<color=blue>恢复MP：{0}</color>\n", consumable.Mp);
                break;
            default: break;
        }
        sb.AppendFormat("\n");
        sb.AppendFormat("<color=white>{0}</color>\n\n", item.Introduction);
        sb.AppendFormat("<color=yellow>购买价格：{0}</color>\n", item.Buyprice);
        sb.AppendFormat("<color=yellow>出售价格：{0}</color>", item.SellPrice);
        return sb.ToString();
    }

    /// <summary>
    /// 创建装备
    /// </summary>
    /// <param name="item"></param>
    private void CreateItem(Item item, Transform ParentTF)
    {
        GameObject NewItem = Resources.Load<GameObject>("Prefabs/ItemUI");
        GameObject TheItemObgect = GameObject.Instantiate(NewItem) as GameObject;

        Sprite TheSprite = Resources.Load<Sprite>(item.Icon) as Sprite;
        TheItemObgect.GetComponent<ItemUI>().Set_Item(TheSprite);     //设置图标

        TheItemObgect.transform.SetParent(ParentTF);
        TheItemObgect.transform.localPosition = Vector3.zero;
        TheItemObgect.transform.localScale = Vector3.one;

        ItemModel.StoreData(ParentTF.name, item);
    }

}
