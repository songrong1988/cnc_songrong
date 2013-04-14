using UnityEngine;
using System.Collections;
   
public class HandWheelFunction : MonoBehaviour {
	Rect PanelHandWheel = new Rect(0, 0, 670, 650);
	public GUIStyle sty_Button;
	public float width = 670F,height = 650F;
	public float X_Offset_HandWheelSet=0;//手轮控制下在X轴方向上的位移
	public float Y_Offset_HandWheelSet=0;//手轮控制下在Y轴方向上的位移
	public float Z_Offset_HandWheelSet=0;//手轮控制下在Z轴方向上的位移
    bool  HandWheel_OFF=true;//手轮是否处于off状态
    bool  X_HandWheel=false;//手轮进给时X轴选中
	bool  Y_HandWheel=false;//手轮进给时Y轴选中
	bool  Z_HandWheel=false;//手轮进给时Z轴选中
	bool  Axis4_HandWheel=false;//手轮进给时4轴选中
	float Scale_Offset_HandWheel=0.001f;//手轮进给的单位距离
	bool handWheelActive=false;//
	Vector3 lastMousePos=new Vector3(0,0,0);
	float currRotateAngle=0;//当前手轮旋转的角度；
	 bool initializeLastPos=false;
	 Vector2 handWheelOrigin=new Vector2(375,375);//手轮刻度盘圆心位置
	 Rect handWheelPlaneRect=new Rect(200,200,350,350);//手轮刻度盘贴图的位置
	 Rect handWheelRect=new Rect(320,310,125,125);//整个手轮贴图的位置		
    Rect handWheelAreaRect;//手轮激活贴图的位置
	int size=25;//手轮受力范围
    Vector2 handWheelPoint=new Vector2(430,320);//手轮受力点
	float handWheelRadius=0;
	float minDistance=0;
	float maxDistance=0;
	//public float angle=0f;//累计旋转的角度
    float deltaAngle=5f;//+1格或-1格的临界角度
	float rotateMinAngle=2f;//旋转手轮贴图的最小角度
	int handWheelDirection=0;//手轮旋转方向
	public Texture2D hand;//手轮贴图
	public Texture2D plane;//刻度盘贴图
	
	public Texture2D activeArea;
    bool initializeAngleOffset=false;
    float angleOffset=0;
	//public int Add_Interval_Num=0;
	//public int Sub_Interval_Num=0; 
	//GUI.Button(new Rect(750f/1000f*width, 850f/1000f*height, 50f/1000f*width, 50f/1000f*height), "DOWN"	
	// Use this for initialization
	void Start (){
		// print(Mathf.Asin(0.5F));
	    handWheelAreaRect=new Rect(handWheelPoint.x-size,handWheelPoint.y-size,2*size,2*size);
		//Debug.Log(handWheelPoint);
	   Debug.Log(handWheelAreaRect);
		handWheelRadius=(handWheelPoint.x-handWheelOrigin.x)*(handWheelPoint.x-handWheelOrigin.x)+(handWheelPoint.y-handWheelOrigin.y)*(handWheelPoint.y-handWheelOrigin.y);
		handWheelRadius=Mathf.Pow (handWheelRadius,0.5f);
		Debug.Log(handWheelRadius);
		minDistance=Mathf.Pow( handWheelRadius,0.5f)-15;
		maxDistance=Mathf.Pow( handWheelRadius,0.5f)+15;
	    
				  
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 mousePos=Input.mousePosition;
		//Debug.Log(Screen.height-mousePos.y);
		mousePos.y=Screen.height-mousePos.y;
		//Debug.Log(handWheelAreaRect);
		//Debug.Log(handWheelRect);
		//Debug.Log(mousePos);
		//float distance=(mousePos.x-handWheelOrigin.x)*(mousePos.x-handWheelOrigin.x)+(mousePos.y-handWheelOrigin.y)*(mousePos.y-handWheelOrigin.y);
		if(handWheelAreaRect.Contains(mousePos))
		//distance=Mathf.Pow (distance,0.5f);
		//if(distance>minDistance&&distance<maxDistance)
		{   
			
	        if(Input.GetMouseButtonDown(0))
            {
				//Debug.Log(mousePos);
				if(!initializeAngleOffset)
		       {
		           angleOffset=180 - Mathf.Atan2(mousePos.x- handWheelOrigin.x, mousePos.y - handWheelOrigin.y) * Mathf.Rad2Deg;
					//currRotateAngle=angleOffset;
			       initializeAngleOffset=true;
		        }
		     	
		    //	mousePos.y=Screen.height-mousePos.y;
		    	Debug.Log(mousePos);
			
				
			   if(!initializeLastPos)
			   {
				  lastMousePos=mousePos;
				  initializeLastPos=true;
				 // Debug.Log("shubiao click");
			 	}
			    
				handWheelActive=true;
			}
		 
	      	if(Input.GetMouseButtonUp(0))
	    	{
		    	handWheelActive=false;
				initializeLastPos=false;
	    	}
		}
		else
		{
		   handWheelActive=false;
			initializeLastPos=true;
			//Debug.Log(handWheelAreaRect);
		}
		
	}
	void ChangeHandWheelPoint()
	{
		   /* if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				//handWheelDirection=2;//-1格；
			     
				
			}
			else if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=1;//+1格
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				handWheelDirection=1;
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=2;
			}*/
	}
	void OnGUI()
	{ 
		//GUI.depth = 1;
		GUI.DrawTexture( handWheelPlaneRect,plane);
		
		PanelHandWheel = GUI.Window(0, PanelHandWheel, PanelWindow, "HandWheel Panel");   
		//GUI.Label(new Rect(40f/1000f*width,395f/1000f*height,230f/1000f*width,25f/1000f*height),"OFF", sty_Button);
		if (GUI.Button(new Rect(60f/1000f*width, 150f/1000f*height, 80f/1000f*width, 50f/1000f*height), "OFF"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			HandWheel_OFF=true;
			X_HandWheel=false;
	        Y_HandWheel=false;
	        Z_HandWheel=false;
	        Axis4_HandWheel=false;
			
		}
	    if (GUI.Button(new Rect(60f/1000f*width, 200f/1000f*height, 80f/1000f*width, 50f/1000f*height), "X"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			HandWheel_OFF=false;
			X_HandWheel=true;
	        Y_HandWheel=false;
	        Z_HandWheel=false;
	        Axis4_HandWheel=false;
		}
		if (GUI.Button(new Rect(60f/1000f*width, 250f/1000f*height, 80f/1000f*width, 50f/1000f*height), "Y"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			HandWheel_OFF=false;
			X_HandWheel=false;
	        Y_HandWheel=true;
	        Z_HandWheel=false;
	        Axis4_HandWheel=false;
			
		}
		if (GUI.Button(new Rect(60f/1000f*width, 300f/1000f*height, 80f/1000f*width, 50f/1000f*height), "Z"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			HandWheel_OFF=false;
			X_HandWheel=false;
	        Y_HandWheel=false;
	        Z_HandWheel=true;
	        Axis4_HandWheel=false;
			
		}
		if (GUI.Button(new Rect(60f/1000f*width, 350f/1000f*height, 80f/1000f*width, 50f/1000f*height), "4"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			HandWheel_OFF=false;
			X_HandWheel=false;
	        Y_HandWheel=false;
	        Z_HandWheel=false;
	        Axis4_HandWheel=true;
			
		}
		if (GUI.Button(new Rect(250f/1000f*width, 150f/1000f*height, 80f/1000f*width, 50f/1000f*height), "X1"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			Scale_Offset_HandWheel=0.001f;
			
		}
		if (GUI.Button(new Rect(250f/1000f*width, 200f/1000f*height, 80f/1000f*width, 50f/1000f*height), "X10"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			Scale_Offset_HandWheel=0.01f;
		}
		if (GUI.Button(new Rect(250f/1000f*width, 250f/1000f*height, 80f/1000f*width, 50f/1000f*height), "X100"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			Scale_Offset_HandWheel=0.1f;
		}
		if (GUI.Button(new Rect(350f/1000f*width, 150f/1000f*height, 80f/1000f*width, 50f/1000f*height), "+1格")) 
			//手轮往右移动一格
		{
			//Debug.Log("sldjflkdsjflkds");
			if(!HandWheel_OFF)
			{
				if(X_HandWheel)
				{
					X_Offset_HandWheelSet+=Scale_Offset_HandWheel;
					//Debug.Log(X_Offset_HandWheelSet);
				}
				else if(Y_HandWheel)
				{
					Y_Offset_HandWheelSet+=Scale_Offset_HandWheel;
				}
				else if(Z_HandWheel)
				{
					Z_Offset_HandWheelSet+=Scale_Offset_HandWheel;
				}
				
			}
		}
		if (GUI.Button(new Rect(350f/1000f*width, 250f/1000f*height, 80f/1000f*width, 50f/1000f*height), "-1格"))            
		{
			//Debug.Log("sldjflkdsjflkds");
			if(!HandWheel_OFF)
			{
				if(X_HandWheel)
				{
					X_Offset_HandWheelSet-=Scale_Offset_HandWheel;
					//Debug.Log(X_Offset_HandWheelSet);
				}
				else if(Y_HandWheel)
				{
					Y_Offset_HandWheelSet-=Scale_Offset_HandWheel;
				}
				else if(Z_HandWheel)
				{
					Z_Offset_HandWheelSet-=Scale_Offset_HandWheel;
				}
				
			}
		}
		if(!handWheelActive)
		{
			float deltAngle=currRotateAngle-angleOffset;
			if(deltAngle>=0)
				GUIUtility.RotateAroundPivot(currRotateAngle-angleOffset,handWheelOrigin);	
			else 
			{
				GUIUtility.RotateAroundPivot(360+deltAngle,handWheelOrigin);	
			}
		    GUI.DrawTexture( handWheelRect,hand);
		}
		//GUI.DrawTexture( handWheelAreaRect,activeArea);
		if(handWheelActive)
		{
			//Debug.Log("active");
			//获取当前鼠标坐标
			Vector3 currentMousePos=Input.mousePosition;
			//handWheelAreaRect=new Rect(currentMousePos.x-size,Screen.height-currentMousePos.y-size,2*size,2*size);
			//计算在手轮圆心的哪一侧
			currentMousePos.y=Screen.height-currentMousePos.y;
			//根据相对手轮圆心的位置和鼠标y值的变化趋势确定是+1格还是-1格
			if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=2;//-1格；
				
			}
			else if(currentMousePos.x>handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				handWheelDirection=1;//+1格
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y<lastMousePos.y)
			{
				handWheelDirection=1;
			}
			else if(currentMousePos.x<handWheelOrigin.x&&currentMousePos.y>lastMousePos.y)
			{
				handWheelDirection=2;
			}
			//根据tan值求angle
			/*float distance =Mathf.Pow(currentMousePos.x-lastMousePos.x,2.0f)+Mathf.Pow (currentMousePos.y-lastMousePos.y,2f);
			distance=Mathf.Pow(distance,0.5f);
			float radius=Mathf.Pow (currentMousePos.x-handWheelOrigin.x,2f)+Mathf.Pow(currentMousePos.y-handWheelOrigin.y,2f);
			radius=Mathf.Pow(radius,0.5f);
			
			float sinValue=(distance/2)/radius;*/
		    float rotateAngle=180 - Mathf.Atan2(currentMousePos.x- handWheelOrigin.x, currentMousePos.y -handWheelOrigin.y) * Mathf.Rad2Deg;
			
			handWheelAreaRect=new Rect((handWheelRadius)*(Mathf.Sin(rotateAngle/Mathf.Rad2Deg))+handWheelOrigin.x-size,(-Mathf.Cos(rotateAngle/Mathf.Rad2Deg))*handWheelRadius+handWheelOrigin.y-size,2*size,2*size);
			//旋转贴图
			/*if(rotateAngle>=rotateMinAngle)
			{
				//根据handwheeldirection旋转rotateangle度
				lastMousePos=currentMousePos;
			}*/
			//若angle>=阈值，响应的X_offset_handWheel或Y_offset_handWheel或z_offset_handWheel改变
			Debug.Log(handWheelAreaRect);
			Debug.Log (rotateAngle);
			float r=Mathf.Abs((Mathf.Abs(rotateAngle)-Mathf.Abs(currRotateAngle)));
			//Debug.Log(r);
			if(r>=deltaAngle)
			{
				Debug.Log("rotateangle");
		    	Debug.Log(rotateAngle);
		    	Debug.Log("currRotateAngle");
		    	Debug.Log(currRotateAngle);
				//根据handwheeldirection旋转rotateangle度
				float deltAngle=rotateAngle-angleOffset;
			    if(deltAngle>=0)
				   GUIUtility.RotateAroundPivot(deltAngle,handWheelOrigin);	
			    else 
			    {
				  GUIUtility.RotateAroundPivot(360+deltAngle,handWheelOrigin);	
			    }	
				//Debug.Log("dfds");
		        GUI.DrawTexture(handWheelRect,hand);
				//handWheelAreaRect=new Rect(currentMousePos.x -size,currentMousePos.y-size,2*size,2*size);
				lastMousePos=currentMousePos;
				//if(Mathf.Abs((Mathf.Abs(rotateAngle)-Mathf.Abs(currRotateAngle)))>=deltaAngle)
				//{
				if(handWheelDirection==1)
				{
					
					//handWheelPoint.x=
					//ChangeHandWheelPoint();
					
					if(X_HandWheel)
					{
						X_Offset_HandWheelSet+=Scale_Offset_HandWheel;
						Debug.Log("x+1");
					}
					else if(Y_HandWheel)
						Y_Offset_HandWheelSet+=Scale_Offset_HandWheel;
					else if(Z_HandWheel)
						Z_Offset_HandWheelSet+=Scale_Offset_HandWheel;
				}
				else if(handWheelDirection==2)
				{
					if(X_HandWheel)
					{
						X_Offset_HandWheelSet-=Scale_Offset_HandWheel;
						Debug.Log("x-1");
					}
					else if(Y_HandWheel)
						Y_Offset_HandWheelSet-=Scale_Offset_HandWheel;
					else if(Z_HandWheel)
						Z_Offset_HandWheelSet-=Scale_Offset_HandWheel;
				}
				//}
			    currRotateAngle=rotateAngle;
				
				
			}
			else 
			{
				float deltAngle=currRotateAngle-angleOffset;
			    if(deltAngle>=0)
				   GUIUtility.RotateAroundPivot(currRotateAngle-angleOffset,handWheelOrigin);	
			    else 
			    {
			     	GUIUtility.RotateAroundPivot(360+deltAngle,handWheelOrigin);	
			    }
		       GUI.DrawTexture( handWheelRect,hand);
			}
			/*else
			{
				if(rotateAngle>=rotateMinAngle)
			       angle+=rotateAngle;
			
			}*/
		}
		
	}    
	void PanelWindow(int windowID)
	{
		if(windowID==0)
		{
		}
	}
}
