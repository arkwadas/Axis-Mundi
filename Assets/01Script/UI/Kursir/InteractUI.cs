using RPG.Combat;
using RPG.Core;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.AI;
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
    [SerializeField] float maxNavMeshProjectionDistance = 0.3f;
    [SerializeField] float raycastRadius = 0.3f;

    bool isDraggingUI = false;
    // Dodajemy zmienn� do przechowywania bie��cego CursorType
    private CursorType currentCursorType;


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

    private bool InteractWithComponent()
    {
        RaycastHit[] hits = RaycastAllSorted();
        foreach (RaycastHit hit in hits)
        {
            IRaycastable[] raycastables = hit.transform.GetComponents<IRaycastable>();
            foreach (IRaycastable raycastable in raycastables)
            {
                if (raycastable.HandleRaycast(this))
                {
                    SetCursor(raycastable.GetCursorType());
                    return true;
                }
            }
        }
        return false;
    }

    RaycastHit[] RaycastAllSorted()
    {
        //Get all hits
        RaycastHit[] hits = Physics.SphereCastAll(GetMouseRay(), raycastRadius);
        //Sort by distance
        //build array distances
        float[] distances = new float[hits.Length];
        for (int i = 0; i < hits.Length; i++)
        {
            distances[i] = hits[i].distance;
        }
        //Sort The hits
        Array.Sort(distances, hits);
        //Return
        return hits;
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    public CursorType GetCurrentCursorType()
    {
        return currentCursorType;
    }
}