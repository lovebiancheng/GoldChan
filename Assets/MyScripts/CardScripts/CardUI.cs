using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CardUI:MonoBehaviour
{
    public string cardName;//卡片名称
    public string fetters;//羁绊
    public int cost;  //花费
    public Sprite sprite;//图片
    public int stars;//星级
    public int cardID;//卡牌的ID

    public void Init(Card data)
    {
        Transform ts = transform.Find("CardPrice");
        ts = transform.Find("CardName");
        this.cardName=data.cardName;
        this.fetters = data.fetters;
        this.cost = data.cost;
        this.sprite = data.sprite;
        this.stars = data.stars;
        this.cardID = data.cardID;
    }
    



    //按键点击事件
    public void Buy(ref int money)
    {
        if (money - cost < 0)
        {
            Debug.Log("你的钱不够");
            return;
        }
        else
        {
            money=money-cost;
            ObjectPool.Instance.ReturnToPool(gameObject.tag,this.gameObject);

        }
    }

    public void CreatCube()
    {

    }
}
