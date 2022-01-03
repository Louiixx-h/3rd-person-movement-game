using UnityEngine;

public class HideMouseCursor : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        
    }
}
