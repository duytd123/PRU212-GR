using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNornaml;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hotspot = new Vector2(16, 48);
    void Start()
    {
        Cursor.SetCursor(cursorNornaml, hotspot, CursorMode.Auto);
    }

    void Update()
    {
        // chuot trai co duoc nhan va so luong dan con > 0 va thoi gian hien tai > thoi gian tiep theo
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(cursorNornaml, hotspot, CursorMode.Auto);
        }
        if(Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(cursorReload, hotspot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Cursor.SetCursor(cursorNornaml, hotspot, CursorMode.Auto);
        }
    }
}
