using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {

	// Use this for initialization
	public VectorLine straightLine;
	void Start () {
	     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DrawStraightLine(Vector3 startPoint,Vector3 endPoint,float lineWidth,Color lineColor,Material mat)
	{
		Vector3[] line=new Vector3[2];
		line[0]=startPoint;
		line[1]=endPoint;
		straightLine=new VectorLine("line",line,lineColor,mat,lineWidth);
		Vector.DrawLine3DAuto(straightLine);
	}
	
	
}
