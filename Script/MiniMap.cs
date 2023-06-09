using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    private RectTransform rect;
    private Transform player;
    private static Image item;
    private Image playerImage;
    // Start is called before the first frame update
    void Start()
    {
        item = Resources.Load<Image>("Image");
        Debug.Log(item.name);
        rect=GetComponent<RectTransform>();
        Debug.Log(rect.name);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(player.name);
        if (player != null)
        {
            playerImage = Instantiate(item) as Image;
            Debug.Log(playerImage.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowPlayer();
    }
    public void ShowEnemy(Image image,float disX,float disY)
    {
        image.rectTransform.sizeDelta = new Vector2(25, 25);
        image.rectTransform.anchoredPosition= new Vector2(disX*100,disY*100) ;
        Debug.Log(disX +(disY ).ToString());
        image.sprite = Resources.Load<Sprite>("Texture/Enemy");
        Debug.Log("Enemy Spirte is:"+image.sprite);
        image.transform.SetParent(transform,false);
    }
    private void ShowPlayer()
    {
        playerImage.rectTransform.sizeDelta = new Vector2(20, 20);
        playerImage.rectTransform.anchoredPosition=new Vector2(0, 0);
        playerImage.rectTransform.eulerAngles = new Vector3(0, 0, -player.transform.eulerAngles.y);
        playerImage.sprite = Resources.Load<Sprite>("Texture/Player");
        playerImage.transform.SetParent(transform, false);
    }
    public static Image RenderIcon()
    {
        return Instantiate(MiniMap.item) as Image;
    }
}
