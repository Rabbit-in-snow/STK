using UnityEngine;
using UnityEngine.EventSystems;

public class UIClickTest : MonoBehaviour, IPointerClickHandler
{
    //Detect if a click occurs
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(clickedObject);
    }
}