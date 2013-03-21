using UnityEngine;
using System.Collections;

public class DrawLineTest : MonoBehaviour {

	// Use this for initialization
	private Vector3[] linePoints=new Vector3[2];
	private Material theMat;
	VectorLine line;
	float nowtime;
	bool test=true;
	LineDrawer a;
	void Start () {
		/*linePoints[0]=new Vector3(0,0,0);
		linePoints[1]=new Vector3(2,2,2);
		theMat = new Material(Shader.Find("Self-Illumin/VertexLit"));
	    line=new VectorLine("line",linePoints,theMat,2);
		Vector.DrawLine3D(line);
		
		Debug.Log("vector.drawLine");*/
		linePoints[0]=new Vector3(0,0,0);
		linePoints[1]=new Vector3(1,2,2);
		a=new LineDrawer ();
		a.DrawStraightLine(linePoints[0],linePoints[1],2.0f,Color.yellow,null);
		nowtime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	     
		while(Time.time-nowtime>4&&test){Vector.SetColor(a.straightLine,Color.red);test=false;}
		
	}
}
