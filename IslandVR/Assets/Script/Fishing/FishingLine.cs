using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    public LineRenderer line;
    public Transform currentPos;
    public Transform lurePos;
    public Transform midPoint;
    public float vertexCount = 12;
    public float midPointYPosition = 2;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        midPoint.transform.position = new Vector3(
            (currentPos.transform.position.x + lurePos.transform.position.x),
            midPointYPosition,
            (currentPos.transform.position.z + lurePos.transform.position.z) / 2);
        var PointList = new List<Vector3>();

        for (float ratio = 0;ratio<=1;ratio+=1/vertexCount)
        {
            var tangent1 = Vector3.Lerp(currentPos.localPosition, lurePos.localPosition, ratio);
            var tangent2 = Vector3.Lerp(currentPos.localPosition, lurePos.localPosition, ratio);
            var curve = Vector3.Lerp(tangent1, tangent2, ratio);

            PointList.Add(curve);
        }

        line.positionCount = PointList.Count;
        line.SetPositions(PointList.ToArray());
    }
}
