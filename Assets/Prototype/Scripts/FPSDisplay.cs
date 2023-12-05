using UnityEngine;

namespace Prototype.Scripts
{
    public class FPSDisplay : MonoBehaviour
    {
        float deltaTime = 0.0f;
        private float FPS;

        private float currentTime = 0;
        private float delay = 0.5f;
        void Update()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

            if (currentTime >= delay)
            {
                FPS = 1.0f / deltaTime;
                currentTime = 0;
            }

            currentTime += Time.deltaTime;
        }

        void OnGUI()
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 4 / 100;
            style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

            string text = string.Format("{0:0.} FPS", FPS);
            GUI.Label(rect, text, style);
        }
    }
}