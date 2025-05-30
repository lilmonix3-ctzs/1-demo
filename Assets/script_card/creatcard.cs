using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatcard : MonoBehaviour
{
    public int CardFlow = 0;
    public int TakeHowManyCard = 0;
    public GameObject[] HavingCard = null;
    private int HavingCardNum = 0;
    private int TakingCardNum = 1;
    public GameObject NewCard;
    public Transform CardCanvas;
    public GameObject startUI;
    private int TakeTime = 0;
    private float CardPosition = 0;

   

    public CardMessage[] Card = null;//用来储存我们设计的所有卡牌的信息的数组
    public IDictionary<int, int> CardGroup = new Dictionary<int, int>();//用来储存卡组中的，各种卡牌ID及其对应数量的字典
    public int TakeCardID;//要抽取的卡牌ID
    public int CardGroup_Species;//卡组中有几种卡
    public int CardGroup_Num;//卡组中有多少张卡

    void Start()
    {
        CardGroup.Add(1, 5);
        CardGroup.Add(2, 10);
        CardGroup_Species = 2;
        CardGroup_Num = 15;
    }
    void Update()
    {
        CardFlow_1();
        CardFlow_2();
        
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        CardFlow = 1;
        HavingCardNum = 0;
        TakeHowManyCard = 7;
        
    }

    public void TakeCard(int A)
    {
        ChooseCardID();
        if (TakeCardID >= 1)
        {
            NewCard.GetComponent<carddisplay>().Image_1.sprite = Card[TakeCardID - 1].Card_Art;
            NewCard.GetComponent<carddisplay>().Image_2.sprite = Card[TakeCardID - 1].Card_NameBack;
            NewCard.GetComponent<carddisplay>().Image_3.sprite = Card[TakeCardID - 1].Card_LevelBack;
            NewCard.GetComponent<carddisplay>().Image_4.sprite = Card[TakeCardID - 1].Card_CostBack;
            NewCard.GetComponent<carddisplay>().Image_5.sprite = Card[TakeCardID - 1].Card_TextBack;
            NewCard.GetComponent<carddisplay>().Image_6.sprite = Card[TakeCardID - 1].Card_Back;
            NewCard.GetComponent<carddisplay>().Image_7.sprite = Card[TakeCardID - 1].Card_Frame;
            NewCard.GetComponent<carddisplay>().Text_1.text = Card[TakeCardID - 1].Card_Name;
            NewCard.GetComponent<carddisplay>().Text_2.text = Card[TakeCardID - 1].Card_Text;
            NewCard.GetComponent<carddisplay>().Text_3.text = Card[TakeCardID - 1].Card_Cost.ToString();
            NewCard.GetComponent<carddisplay>().Text_4.text = Card[TakeCardID - 1].Card_Level.ToString();
            HavingCard[A] = Instantiate(NewCard, new Vector3(500, 500, 0), NewCard.transform.rotation, CardCanvas);
            HavingCard[A].GetComponent<RectTransform>().anchoredPosition = new Vector2(437, -12);
            LeanTween.rotate(HavingCard[A], new Vector3(0, 0, 0), 1.5f).setEaseInOutQuart();
            LeanTween.scale(HavingCard[A], new Vector3(1, 1, 1), 1.8f).setEaseInOutQuart();
        }
    }

    public void CardFlow_1()//抽出一张牌的阶段
    {
        if (CardFlow == 1 && TakeHowManyCard != 0)
        {
            if (TakingCardNum <= TakeHowManyCard)
            {
                TakeCard(HavingCardNum);//执行抽牌
                TakingCardNum = TakingCardNum + 1;
                CardFlow = 2;
            }

            else
            {
                TakingCardNum = 1;
                TakeHowManyCard = 0;
                CardFlow = 3;
            }

        }
    }

    public void CardFlow_2()//将卡牌展示后加入手牌的阶段
    {
        if (CardFlow == 2)
        {
            TakeTime = TakeTime + 1;//展示550帧
            if (TakeTime >= 550)
            {
                CardPosition = 630 / (HavingCardNum + 1);
                HavingCard[HavingCardNum].transform.LeanScale(new Vector3(1, 1, 0), 0.5f);
                LeanTween.moveLocal(HavingCard[HavingCardNum], new Vector3((-300 + CardPosition / 2 + (HavingCardNum) * CardPosition), -200, 0), 0.5f);//将卡放入手牌
                for (int i = 1; i < 7; i++)//前面的卡牌挪动位置
                {
                    if ((HavingCardNum - i) >= 0)
                    {
                        Debug.Log(HavingCard[HavingCardNum].transform.position);
                        LeanTween.moveLocal(HavingCard[HavingCardNum - i], new Vector3((-300 + CardPosition / 2 + (HavingCardNum  - i) * CardPosition), -200, 0), 0.12f);
                    }
                }
                TakeTime = 0;
            }
        }
        if (CardFlow == 2 && HavingCard[HavingCardNum].GetComponent<RectTransform>().anchoredPosition.y < -14)
        {
            CardGroup[TakeCardID] = CardGroup[TakeCardID] - 1;
            if (CardGroup[TakeCardID] <= 0)
            {
                CardGroup_Species = CardGroup_Species - 1;
                CardGroup.Remove(TakeCardID);
            }
            CardGroup_Num = CardGroup_Num - 1;
            HavingCardNum = HavingCardNum + 1;
            TakeTime = 0;
            CardFlow = 1;
        }

    }

    public void ChooseCardID()//生成卡组中要抽取卡牌的ID
    {
        int a = 0;//用来记录字典遍历次数
        int b = 0;//用来记录正在遍历的卡牌之前一共有多少张牌
        int d = 0;//生成的随机数
        int f = 0;//用来读取正在遍历的卡牌在数组中的数量
        bool c = true;//在遍历到最后一种卡时，用来跳出判断


        c = true;
        d = Random.Range(1, CardGroup_Num + 1);
        if(CardGroup_Num>0)
        {
            foreach(int A in CardGroup.Keys)
            {
                a = a + 1;
                if(c)
                {
                    if (a < CardGroup_Species && c)//还没决定ID，并且不是最后一种牌
                    {
                        f = CardGroup[A];
                        if (d <= (b + f) && d > b)
                        {
                            TakeCardID = A;
                            c = false;
                        }
                        else
                            b = b + f;
                    }

                    else
                    {
                        TakeCardID = A;
                        c = false;

                    }
                }
            }
        }
    }
}
