using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solid : MonoBehaviour
{
    public int Type;
    public List<Sprite> Images;
    public SpriteRenderer img;

    public void SetType(int type)
    {
        switch (type)
        {
            //case 0:
            //    Type = type;
            //    img.sprite = Images[type];
            //    break;
            case 1:
                Type = type;
                img.sprite = Images[type];
                break;
            case 2:
                Type = type;
                img.sprite = Images[type];
                break;
            //case 3:
            //    Type = type;
            //    img.sprite = Images[type];
            //    break;
            //case 4:
            //    Type = type;
            //    img.sprite = Images[type];
            //    break;
            //case 5:
            //    Type = type;
            //    img.sprite = Images[type];
            //    break;
            case 6:
                Type = type;
                img.sprite = Images[type];
                break;
            //case 7:
            //    Type = type;
            //    img.sprite = Images[type];
            //    break;
            default:
                Type = 2;
                img.sprite = Images[2];
                break;
        }
        
    }
}

