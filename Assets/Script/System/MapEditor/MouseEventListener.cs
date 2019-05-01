
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
                var screenPosition = Input.mousePosition;
                Debug.Log(screenPosition);
                var mainCamera = FindObjectOfType<Camera>();
                var localPosition = mainCamera.ScreenToWorldPoint(screenPosition);
                Debug.Log(localPosition);
            }
        }
    }
}