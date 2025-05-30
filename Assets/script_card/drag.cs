using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class drag : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler
{
    public RectTransform RT;
    public RectTransform MoveLimitRT;
    public Vector2 MinPoint;
    public Vector2 MaxPoint;
    public Vector2 StartPoint;
    public Vector2 EndPoint;
    public float MoveSpeed;
    private bool CheckCard;
    public bool MoveBack;


    //private bool onDrag = false;
    void Start()
    {
       
        //SetDragRange();
        CheckCard = true;
        MoveBack = true;
    }


    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (CheckCard)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(RT, eventData.position, eventData.pressEventCamera, out Vector3 MousePosition))
        {
          
            //onDrag = true;
            //transform.position = eventData.position;
            RT.position = MousePosition;
            //CheckCard = false;
        }


    }

    //void SetDragRange()//anchoredPosition
    //{
    //    //��Сx���� = ������ǰx����-�������ľ�����߽�ľ���+UI���ľ�����߽�ľ���
    //    MinPoint.x = MoveLimitRT.position.x - MoveLimitRT.pivot.x * MoveLimitRT.rect.width + RT.rect.width * RT.pivot.x * 2;

    //    //���x���� = ������ǰx����-�������ľ����ұ߽�ľ���-UI���ľ����ұ߽�ľ���
    //    MaxPoint.x = MoveLimitRT.position.x + (1 - MoveLimitRT.pivot.x) * MoveLimitRT.rect.width - RT.rect.width * (1 - RT.pivot.x) * 2;

    //    //��Сy���� = ������ǰy����-�������ľ���ױߵľ���+UI���ľ���ױߵľ���
    //    MinPoint.y = MoveLimitRT.position.y - MoveLimitRT.pivot.y * MoveLimitRT.rect.height + RT.rect.height * RT.pivot.y * 2;

    //    //���y���� = ������ǰx����+�������ľ��붥�ߵľ���-UI���ľ��붥�ߵľ���
    //    MaxPoint.y = MoveLimitRT.position.y + (1 - MoveLimitRT.pivot.y) * MoveLimitRT.rect.height - RT.rect.height * (1 - RT.pivot.y) * 2;

    //}

    //�������귶Χ

    //Vector3 DragRangeLimit(Vector3 pos)
    //{
    //    pos.x = Mathf.Clamp(pos.x, MinPoint.x, MaxPoint.x);
    //    pos.y = Mathf.Clamp(pos.y, MinPoint.y, MaxPoint.y);
    //    return pos;

    //}

    public void OnEndDrag(PointerEventData eventData)
    {
        //CheckCard = true;
        transform.localScale = new Vector3(1, 1, 1);
        
    }

    //public void FixedUpdate()
    //{
    //    if(CheckCard)
    //    {
            
    //        if(MoveBack)
    //        {
    //            transform.localPosition = Vector3.MoveTowards(transform.localPosition, StartPoint, MoveSpeed * Time.deltaTime * 100.0f);

    //        }
    //        else
    //        {
    //            transform.localPosition = Vector3.MoveTowards(transform.localPosition, EndPoint, MoveSpeed * Time.deltaTime * 100.0f);
    //        }


    //    }
    //}
    
}
