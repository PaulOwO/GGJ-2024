using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public GameObject MessagePrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject pref = Instantiate(MessagePrefab, new Vector3(0,0,0), Quaternion.identity);
        pref.transform.SetParent(this.transform, false);

        pref.transform.position = transform.position;
        
        //pref.transform.position = this.transform.position;
        pref.transform.localScale = new Vector3(1, 1, 1);
        print("arf");
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        

        RectTransform arg = pref.GetComponent<RectTransform>();

        
        arg.offsetMin = new Vector2(rectTransform.rect.xMin, rectTransform.rect.xMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
