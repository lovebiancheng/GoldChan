using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CardData:MonoBehaviour
{
   
    public List<Card> cards;
    /// <summary>
    /// 从路径中读取卡牌数据信息
    /// </summary>
    public Card ReadCardDataByID(int id)
    {
        for (int i = 0; i < cards.Count; i++) 
        {
            if (cards[i].cardID == id)
            {
                return cards[i];
            }
        }
        return null;
    }
}

[Serializable]
public class Card 
{
    public string cardName;//卡片名称
    public string fetters;//羁绊
    public int cost;  //花费
    public Sprite sprite;//图片
    public int stars;//星级
    public int cardID;//卡牌的ID
}
