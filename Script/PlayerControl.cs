using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private MiniMap miniMap;
    private GameObject enemy;
    private bool isCreated;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        isCreated = true;
        miniMap = GameObject.Find("MiniMap").GetComponent<MiniMap>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        Supervise();
    }
    private void Supervise()
    {
        float dis = Vector3.Distance(transform.position, enemy.transform.position);
        float dx = (enemy.transform.position.x - transform.position.x)/50;
        float dy = (enemy.transform.position.z - transform.position.z) / 50;
        if (dis <= 50 && isCreated)
        {
            image=MiniMap.RenderIcon();
            isCreated = false;
            Debug.Log("Isn't Created");
        }
        if (!isCreated)
        {
            miniMap.ShowEnemy(image,dx,dy);
        }
    }
}
