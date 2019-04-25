
    using UnityEngine;

    public class SystemRoot : Singleton<SystemRoot>
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
