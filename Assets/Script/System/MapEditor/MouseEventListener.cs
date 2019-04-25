
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Script.System.MapEditor
{
    public class MouseEventListener : Singleton<MouseEventListener>
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(Input.mousePosition);
            }
        }
    }
}