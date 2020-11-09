using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MapClickDetector : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,
       IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    MapManager mapManager;
    public float durationThreshold = 1.0f;
    private bool isPointerDown = false;
    private bool longPressTriggered = false;
    private float timePressStarted;

    public UnityEvent onLongPress = new UnityEvent();

    void Start()
    {
        addPhysicsRaycaster();
        mapManager = GameObject.Find("Map Manager").GetComponent<MapManager>();
    }

    void Update()
    {
        if (isPointerDown && !longPressTriggered)
        {
            if (Time.time - timePressStarted > durationThreshold)
            {
                longPressTriggered = true;
                mapManager = new MapManager();
                mapManager.mapLongClick(gameObject);
            }
        }
    }

    void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mapManager.mapclick(gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mapManager.mapMouseDown(gameObject);
        timePressStarted = Time.time;
        isPointerDown = true;
        longPressTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mapManager.mapMouseUp(gameObject);
        isPointerDown = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mapManager.mapMouseEnter(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mapManager.mapMouseExit(gameObject);
    }
}