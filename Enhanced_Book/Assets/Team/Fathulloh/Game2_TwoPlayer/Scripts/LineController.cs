using UnityEngine;

namespace Game2_TwoPlayer
{
    /// <summary>
    /// LineRenderer komponentasi qo�shilgan obyektni boshqaruvchi script.
    /// </summary>
    public class LineController : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private Transform[] points;

        private void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }


        public void SetUpLine(Transform[] points)
        {
            lineRenderer.positionCount = points.Length;
            this.points = points;
        }


        private void Update()
        {
            for (int i = 0; i < points.Length; i++)
            {
                lineRenderer.SetPosition(i, points[i].position);
            }
        }


    }
}
