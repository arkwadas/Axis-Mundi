using UnityEngine.EventSystems;
using UnityEngine;
using RPG.Control;

public class InteractUI : MonoBehaviour
{
    EventSystem eventSystem;

    [System.Serializable]
    struct CursorMapping // do kursora
    {
        public CursorType type;
        public Texture2D texture;
        public Vector2 hotspot;
    }
    [SerializeField] CursorMapping[] cursorMappings = null; // do kursora
    [SerializeField] float maxNavMeshProjectionDistance = 1f;
    [SerializeField] float raycastRadius = 1f;

    bool isDraggingUI = false;

    private void Update()
    {
        if (InteractWithUI()) return;
    }

    private bool InteractWithUI()
    {
        if (Input.GetMouseButtonDown(0))
            isDraggingUI = false;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDraggingUI = true;
            }
            SetCursor(CursorType.UI);
            return false;
        }
        if (isDraggingUI)
        {
           return true;
        }
        if(!isDraggingUI)
        {
            SetCursor(CursorType.None);
        }
        return false;
    }

    private void SetCursor(CursorType type) //kursor
    {
        CursorMapping mapping = GetCursorMapping(type);
        Cursor.SetCursor(mapping.texture, mapping.hotspot, CursorMode.Auto);
    }

    private CursorMapping GetCursorMapping(CursorType type) //kursor
    {
        foreach (CursorMapping mapping in cursorMappings)
        {
            if (mapping.type == type)
            {
                return mapping;
            }
        }
        return cursorMappings[0];
    }
    
}