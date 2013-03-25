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
		linePoints[0]=new Vector3(2.828f,0,2);
		linePoints[1]=new Vector3(0,-2.828f,2);
		a=new LineDrawer ();
		//a.DrawArcLine(new Vector3(2.828f,2,0),new Vector3(-2.828f,2,0),new Vector3(0,2,0),3.14f,2.828f,2,40,2,Color.yellow,null);
		a.DrawArcLine(new Vector3(2.828f,2,0),new Vector3(0,2,-2.828f),new Vector3(0,2,0),1.57f,2.828f,2,40,8,Color.red,null);
		//a.DrawArcLine(new Vector3(2.828f,0,2),new Vector3(2f,2,2),new Vector3(0,0,2),0.785f,2.828f,1,40,16,Color.black,null);
		a.DrawArcLine(new Vector3(2.828f,0,2),new Vector3(0,2.828f,2),new Vector3(0,0,2),1.57f,2.828f,1,40,8,Color.red,null);
		//a.DrawArcLine(new Vector3(2.828f,0,2),new Vector3(0,-2.828f,2),new Vector3(0,0,2),1.57f,2.828f,1,40,16,Color.black,null);
		//a.DrawStraightLine(linePoints[0],linePoints[1],2.0f,Color.yellow,null);
		a.DrawArcLine(new Vector3(2,2.828f,0),new Vector3(2,0,-2.828f),new Vector3(2,0,0),1.57f,2.828f,3,40,8,Color.black,null);
		a.DrawArcLine(new Vector3(2,2.828f,0),new Vector3(2,0,-2.828f),new Vector3(2,0,0),4.71f,2.828f,3,40,16,Color.yellow,null);
		nowtime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	     
		//while(Time.time-nowtime>4&&test){Vector.SetColor(a.straightLine,Color.red);test=false;}
		
	}
}
