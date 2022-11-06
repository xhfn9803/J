using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickTest : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    RectTransform Lever;
    RectTransform RectTransform;

    [SerializeField, Range(10, 150)]
    float LeverRange;

    Vector3 InputDir;
    bool IsInput;

    [SerializeField]
    MoveTest Controller;

    void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
        IsInput = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ControlJoystickLever(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Lever.anchoredPosition = Vector2.zero;
        IsInput = false;
        Controller.Move(Vector3.zero);
    }

    void ControlJoystickLever(PointerEventData eventData)
    {
        var InputPos = eventData.position - RectTransform.anchoredPosition;
        var InputVector = InputPos.magnitude < LeverRange ? InputPos : InputPos.normalized * LeverRange;
        Lever.anchoredPosition = InputVector;
        InputDir = InputVector / LeverRange;
    }

    void InputControlVector()
    {
        Controller.Move(InputDir);
        Debug.Log(InputDir.x + "/" + InputDir.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInput)
        {
            InputControlVector();
        }
    }
}
