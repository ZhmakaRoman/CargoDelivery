using UnityEngine;


public class MoveBox : MonoBehaviour
{
    public DrawWithMouse _DrawWithMouse;
    private bool startMovement = false;
    public int moveIndex;
    public float speed = 10f;
    public Vector3[] pos { get; set; }
    private Vector3[] positions;

    private void OnMouseDown()
    {
        _DrawWithMouse.StartLine(transform.position);
    }

    private void OnMouseDrag()
    {
        _DrawWithMouse.UpdateLine();
    }

    private void OnMouseUp()
    {
        positions = new Vector3[_DrawWithMouse.line.positionCount];
        _DrawWithMouse.line.GetPositions(positions);
        startMovement = true;
        moveIndex = 0;
    }

    private void Update()
    {
        if (startMovement == true)
        {
            Vector2 currentPosition = positions[moveIndex];
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, speed * Time.deltaTime);
            float distance = Vector2.Distance(currentPosition, transform.position);
            if (distance <= 0.05f)
            {
                moveIndex++;
            }

            if (moveIndex > positions.Length - 1)
            {
                startMovement = false;
            }
        }
    }
}