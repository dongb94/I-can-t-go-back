
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace Script.System.MapEditor
{
    public class MouseEventListener : Singleton<MouseEventListener>
    {
        public GameObject ImageObject;
        public Sprite SampleImage;

        private void Awake()
        {
            ImageObject = GameObject.FindWithTag("Player");
            SampleImage = ImageObject.GetComponent<Sprite>();
        }

        private void Update()
        {
            //if (Input.GetMouseButtonDown(0))  
            {
                var screenPosition = Input.mousePosition;
                Debug.Log(screenPosition);
                var mainCamera = FindObjectOfType<Camera>();
                var localPosition = mainCamera.ScreenToWorldPoint(screenPosition);
                Debug.Log(localPosition);

                var gridPosition = BoardManager.GetInstance.ChangePositionToGrid(localPosition);

                ImageObject.transform.position = BoardManager.GetInstance.ChangeGridToPosition(gridPosition);
            }
        }
    }
}