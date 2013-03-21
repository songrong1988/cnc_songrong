using UnityEngine;
using System.Collections;

public class LineDrawer : MonoBehaviour {

	// Use this for initialization
	public VectorLine straightLine;
	public VectorLine arcLine;
	void Start () {
	     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void DrawArcLine(Vector3 startPoint,Vector3 endPoint,Vector3 origin,float rads,int planeFlag,int segments,float lineWidth,Color lineColor,Material mat)
	{
		Vector3[] linePoints=new Vector3[segments+1];
		
	}
	public Vector3 CalculateNextPoint(Vector3 stP,Vector3 endP,Vector3 orgn,float r,int planeFlag,float angle)
	{
		//Vector3 nexPos;
		float c=r*r;
		float d=(Mathf.Sin(angle/2))*2*r;
		if(planeFlag==1)//平行于xoy平面画弧线
		{
			float x=0;float y=0;
			float m=c-d+stP.x*stP.x+stP.y*stP.y-orgn.x*orgn.x-orgn.y*orgn.y;
			float p=m/(2*(stP.x-orgn.x));
			float q=(stP.y-orgn.y)/(stP.x-orgn.x);
			float j=orgn.x-p;
			float t=2*(j*q-orgn.y);
			float s=j*j-c+orgn.y*orgn.y;
			float temp=t*t-8*s;
			if(temp<0)
			{
				Debug.LogError("没有符合要求的解！");
				return new Vector3(0,0,0);
			}
			if(temp==0)
			{
				y=(-t)/4;
				x=p-q*y;
				return new Vector3(x,y,stP.z);
			}
			else{
				float y1=(-t+Mathf.Pow(temp,0.5f))/4;
			    float y2=(-t-Mathf.Pow(temp,0.5f))/4;
			    float x1=p-q*y1;
				float x2=p-q*y2;
				float absstx=Mathf.Abs(stP.x);
				float absedx=Mathf.Abs(endP.x);
				float maxX=(absstx>absedx)?absstx:absedx;
				float minX=(absstx<absedx)?absstx:absedx;
				float abssty=Mathf.Abs(stP.y);
				float absedy=Mathf.Abs(endP.y);
				float maxY=(abssty>absedy)?abssty:absedy;
				float minY=(abssty<absedy)?abssty:absedy;
				float absx1=Mathf.Abs(x1);
				float absx2=Mathf.Abs(x2);
				float absy1=Mathf.Abs(y1);
				float absy2=Mathf.Abs(y2);
				if(((x1-orgn.x)*(x1-orgn.x)-(y1-orgn.y)*(y1-orgn.y))==r*r&&(absx1>minX&&absx1<maxX&&absy1>minY&&absy1<maxY))
				{
					return new Vector3(x1,y1,stP.z);
				}
				else if(((x2-orgn.x)*(x2-orgn.x)-(y2-orgn.y)*(y2-orgn.y))==r*r&&(absx2>minX&&absx2<maxX&&absy2>minY&&absy2<maxY))
				{
					return new Vector3(x2,y2,stP.z);
				}
				else{
					Debug.LogError("没有符合要求的解！");
					return new Vector3(0,0,0);
				}
			}
			
		}
		if(planeFlag==2)//平行于xoz平面画弧线
		{
			float x=0,z=0;
			float m=c-d+stP.x*stP.x+stP.z*stP.z-orgn.x*orgn.x-orgn.z*orgn.z;
			float p=m/(2*(stP.x-orgn.x));
			float q=(stP.z-orgn.z)/(stP.x-orgn.x);
			float j=orgn.x-p;
			float t=2*(j*q-orgn.z);
			float s=j*j-c+orgn.z*orgn.z;
			float temp=t*t-8*s;
			if(temp<0)
			{
				Debug.LogError("没有符合要求的解！");
				return new Vector3(0,0,0);
			}
			if(temp==0)
			{
				z=(-t)/4;
				x=p-q*z;
				return new Vector3(x,stP.y,z);
			}
			else{
				float z1=(-t+Mathf.Pow(temp,0.5f))/4;
			    float z2=(-t-Mathf.Pow(temp,0.5f))/4;
			    float x1=p-q*z1;
				float x2=p-q*z2;
				float absstx=Mathf.Abs(stP.x);
				float absedx=Mathf.Abs(endP.x);
				float maxX=(absstx>absedx)?absstx:absedx;
				float minX=(absstx<absedx)?absstx:absedx;
				float absstz=Mathf.Abs(stP.z);
				float absedz=Mathf.Abs(endP.z);
				float maxz=(absstz>absedz)?absstz:absedz;
				float minz=(absstz<absedz)?absstz:absedz;
				float absx1=Mathf.Abs(x1);
				float absx2=Mathf.Abs(x2);
				float absz1=Mathf.Abs(z1);
				float absz2=Mathf.Abs(z2);
				if(((x1-orgn.x)*(x1-orgn.x)-(z1-orgn.z)*(z1-orgn.z))==r*r&&(absx1>minX&&absx1<maxX&&absz1>minz&&absz1<maxz))
				{
					return new Vector3(x1,stP.y,z1);
				}
				else if(((x2-orgn.x)*(x2-orgn.x)-(z2-orgn.z)*(z2-orgn.z))==r*r&&(absx2>minX&&absx2<maxX&&absz2>minz&&absz2<maxz))
				{
					return new Vector3(x2,stP.y,z2);
				}
				else{
					Debug.LogError("没有符合要求的解！");
					return new Vector3(0,0,0);
				}
			}
			
		}
		if(planeFlag==3)//平行于yoz平面画弧线
		{
			float y=0,z=0;
			float m=c-d+stP.y*stP.y+stP.z*stP.z-orgn.y*orgn.y-orgn.z*orgn.z;
			float p=m/(2*(stP.y-orgn.y));
			float q=(stP.z-orgn.z)/(stP.y-orgn.y);
			float j=orgn.y-p;
			float t=2*(j*q-orgn.z);
			float s=j*j-c+orgn.z*orgn.z;
			float temp=t*t-8*s;
			if(temp<0)
			{
				Debug.LogError("没有符合要求的解！");
				return new Vector3(0,0,0);
			}
			if(temp==0)
			{
				z=(-t)/4;
				y= p-q*z;
				return new Vector3(stP.x,y,z);
			}
			else{
				float z1=(-t+Mathf.Pow(temp,0.5f))/4;
			    float z2=(-t-Mathf.Pow(temp,0.5f))/4;
			    float y1=p-q*z1;
				float y2=p-q*z2;
				float abssty=Mathf.Abs(stP.y);
				float absedy=Mathf.Abs(endP.y);
				float maxY=(abssty>absedy)?abssty:absedy;
				float minY=(abssty<absedy)?abssty:absedy;
				float absstz=Mathf.Abs(stP.z);
				float absedz=Mathf.Abs(endP.z);
				float maxz=(absstz>absedz)?absstz:absedz;
				float minz=(absstz<absedz)?absstz:absedz;
				float absy1=Mathf.Abs(y1);
				float absy2=Mathf.Abs(y2);
				float absz1=Mathf.Abs(z1);
				float absz2=Mathf.Abs(z2);
				if(((y1-orgn.y)*(y1-orgn.y)-(z1-orgn.z)*(z1-orgn.z))==r*r&&(absy1>minY&&absy1<maxY&&absz1>minz&&absz1<maxz))
				{
					return new Vector3(stP.x,y1,z1);
				}
				else if(((y2-orgn.y)*(y2-orgn.y)-(z2-orgn.z)*(z2-orgn.z))==r*r&&(absy2>minY&&absy2<maxY&&absz2>minz&&absz2<maxz))
				{
					return new Vector3(stP.x,y2,z2);
				}
				else{
					Debug.LogError("没有符合要求的解！");
					return new Vector3(0,0,0);
				}
			}
			
		}
		Debug.LogError("请选择旋转平面");
		return new Vector3(0,0,0);
	}
	public void DrawStraightLine(Vector3 startPoint,Vector3 endPoint,float lineWidth,Color lineColor,Material mat)
	{
		
		Vector3[] line=new Vector3[4];
		line[0]=startPoint;
		line[1]=endPoint;
		line[2]=endPoint;
		line[3]=new Vector3(5,5,5);
		straightLine=new VectorLine("line",line,lineColor,mat,lineWidth);
		Vector.DrawLine3DAuto(straightLine);
	}
	
	
}
