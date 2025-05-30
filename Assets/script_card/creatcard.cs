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

   

    public CardMessage[] Card = null;//��������������Ƶ����п��Ƶ���Ϣ������
    public IDictionary<int, int> CardGroup = new Dictionary<int, int>();//�������濨���еģ����ֿ���ID�����Ӧ�������ֵ�
    public int TakeCardID;//Ҫ��ȡ�Ŀ���ID
    public int CardGroup_Species;//�������м��ֿ�
    public int CardGroup_Num;//�������ж����ſ�

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

    public void CardFlow_1()//���һ���ƵĽ׶�
    {
        if (CardFlow == 1 && TakeHowManyCard != 0)
        {
            if (TakingCardNum <= TakeHowManyCard)
            {
                TakeCard(HavingCardNum);//ִ�г���
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

    public void CardFlow_2()//������չʾ��������ƵĽ׶�
    {
        if (CardFlow == 2)
        {
            TakeTime = TakeTime + 1;//չʾ550֡
            if (TakeTime >= 550)
            {
                CardPosition = 630 / (HavingCardNum + 1);
                HavingCard[HavingCardNum].transform.LeanScale(new Vector3(1, 1, 0), 0.5f);
                LeanTween.moveLocal(HavingCard[HavingCardNum], new Vector3((-300 + CardPosition / 2 + (HavingCardNum) * CardPosition), -200, 0), 0.5f);//������������
                for (int i = 1; i < 7; i++)//ǰ��Ŀ���Ų��λ��
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

    public void ChooseCardID()//���ɿ�����Ҫ��ȡ���Ƶ�ID
    {
        int a = 0;//������¼�ֵ��������
        int b = 0;//������¼���ڱ����Ŀ���֮ǰһ���ж�������
        int d = 0;//���ɵ������
        int f = 0;//������ȡ���ڱ����Ŀ����������е�����
        bool c = true;//�ڱ��������һ�ֿ�ʱ�����������ж�


        c = true;
        d = Random.Range(1, CardGroup_Num + 1);
        if(CardGroup_Num>0)
        {
            foreach(int A in CardGroup.Keys)
            {
                a = a + 1;
                if(c)
                {
                    if (a < CardGroup_Species && c)//��û����ID�����Ҳ������һ����
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
