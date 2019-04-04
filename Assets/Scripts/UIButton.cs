using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour
{


    public Button btn;
 

    // Use this for initialization
    void Start()
    {
        btn = GetComponent<Button>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }   

    void OnMouseDown()
    {
        Debug.Log("YES");
        var pointer = new PointerEventData(EventSystem.current); // pointer event for Execute
        ExecuteEvents.Execute(btn.gameObject, pointer, ExecuteEvents.pointerEnterHandler);

    }


}
