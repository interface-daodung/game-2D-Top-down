using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Texture2D NormalCursor;
    [SerializeField] private Texture2D ReloadCursor;
    [SerializeField] private Texture2D ShootCursor;
    [SerializeField] private Vector2 hotSpot =new Vector2(16,48);

    void Start()
    {
        Cursor.SetCursor(NormalCursor, hotSpot, CursorMode.Auto);
    }


    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Cursor.SetCursor(ShootCursor, hotSpot, CursorMode.Auto);
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            Cursor.SetCursor(ReloadCursor, hotSpot, CursorMode.Auto);
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            Cursor.SetCursor(NormalCursor, hotSpot, CursorMode.Auto);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(NormalCursor, hotSpot, CursorMode.Auto);
        }
    }
}
