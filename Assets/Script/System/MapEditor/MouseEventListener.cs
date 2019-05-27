
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Script.System.MapEditor
{
    public class MouseEventListener : Singleton<MouseEventListener>
    {
        public GameObject ImageObject;
        public Sprite SampleImage;

        private Grid2D focus;

        private void Awake()
        {
            ImageObject = GameObject.FindWithTag("Player");
            SampleImage = ImageObject.GetComponent<Sprite>();
        }

        private void Update()
        {
            var screenPosition = Input.mousePosition;
            var mainCamera = FindObjectOfType<Camera>();
            var localPosition = mainCamera.ScreenToWorldPoint(screenPosition);
            focus = BoardManager.GetInstance.ChangePositionToGrid(localPosition);

            ImageObject.transform.position = BoardManager.GetInstance.ChangeGridToPosition(focus);
            
            if (Input.GetMouseButton(0))
            {
                MouseClick();
            }
        }

        private void MouseClick()
        {
            if (focus.x == -1 || focus.y == -1) return;
            TileManager.GetInstance.GetTile(focus.x, focus.y, TilePointer.GetInstance.currentTile,
                TilePointer.GetInstance.currentColor);
        }
    }
}