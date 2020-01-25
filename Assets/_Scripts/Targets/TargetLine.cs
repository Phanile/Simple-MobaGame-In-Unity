using UnityEngine;

public class TargetLine : MonoBehaviour
{
    [Header("Stats")]
    public int segments = 50;
    public float xradius = 1;
    public float yradius = 1;
    private LineRenderer line;

    private void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }

    private void CreatePoints()
    {
        float x, y, z;
        float angle = 20f;
        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;
            line.SetPosition(i, new Vector3(x, 0, z));
            angle += (360f / segments);
        }
    }
}