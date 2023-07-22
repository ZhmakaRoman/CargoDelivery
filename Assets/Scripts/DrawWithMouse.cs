using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    public LineRenderer line;
    public float _minDistance = 0.1f;
    [SerializeField, Range(0.1f, 2f)] private float _width;

    private Vector3 _previousPosition;

    private void Start()
    {
        line.positionCount = 1;
        _previousPosition = transform.position;
        line.startWidth = line.endWidth = _width;
    }

    public void StartLine(Vector2 position)
    {
        line.positionCount = 1;
        line.SetPosition(0, position);
    }


    public void UpdateLine()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, Vector3.zero);
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 currentPosition = ray.GetPoint(distance);
                if (Vector3.Distance(currentPosition, _previousPosition) > _minDistance)
                {
                    if (_previousPosition == transform.position)
                    {
                        line.SetPosition(0, currentPosition);
                    }
                    else
                    {
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, currentPosition);
                    }

                    _previousPosition = currentPosition;
                }
            }
        }
    }
}