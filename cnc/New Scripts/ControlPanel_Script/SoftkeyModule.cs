using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class SoftkeyModule : MonoBehaviour {
	ControlPanel Main;
	CooSystem CooSystem_script;
	MDIEditModule MDIEdit_Script;
	//宋荣
	PositionModule Pos_Script;
	MDIInputModule MDIInput_Script;
	bool preSetSelected=false;
	//宋荣
	// Use this for initialization
	void Start () {
		Main = gameObject.GetComponent<ControlPanel>();
		CooSystem_script = gameObject.GetComponent<CooSystem>();
		MDIEdit_Script = gameObject.GetComponent<MDIEditModule>();
		//宋荣
		Pos_Script=gameObject.GetComponent<PositionModule>();
	    MDIInput_Script=gameObject.GetComponent<MDIInputModule>();
		//宋荣
		
	}
	
	public void Softkey () 
	{
		//屏幕下方功能软键++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++	
		if (GUI.Button(new Rect(20f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), "<"))            
		{
			if(Main.ScreenPower)
				PreviousPage();
		}
		
		if (GUI.Button(new Rect(90f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))           	
		{
			if(Main.ScreenPower)
				FirstButton();	
		}
		
		if (GUI.Button(new Rect(180f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            	
		{
			if(Main.ScreenPower)
				SecondButton();
		}
		
		if (GUI.Button(new Rect(270f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
				ThirdButton();
		}
		
		if (GUI.Button(new Rect(360f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
				FourthButton();
		}
		
		if (GUI.Button(new Rect(450f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ""))            
		{
			if(Main.ScreenPower)
				FifthButton();
		}
		
		if (GUI.Button(new Rect(520f/1000f*Main.width, 460f/1000f*Main.height, 40f/1000f*Main.width, 40f/1000f*Main.height), ">"))            
		{
			if(Main.ScreenPower)
				NextPage();
		}
	}
	
	//向前翻页软键
	void PreviousPage () {
		//程序界面时按下
		//宋荣
		if(Main.PosMenu)
		{
			if(Main.operationBottomScrInitial)
			{
				if(Main.statusBeforeOperation==1)
				{
					Main.RelativeCoo=false;
				    Main.AbsoluteCoo=true;
				    Main.GeneralCoo=false;
				}
				if(Main.statusBeforeOperation==2)
				{
					Main.RelativeCoo=true;
				    Main.AbsoluteCoo=false;
				    Main.GeneralCoo=false;
				}
				if(Main.statusBeforeOperation==3)
				{
					Main.RelativeCoo=false;
				    Main.AbsoluteCoo=false;
				    Main.GeneralCoo=true;
				}
				Main.operationBottomScrInitial=false;
				Main.posOperationMode=false;
				Pos_Script.xBlink=false;
				Pos_Script.yBlink=false;
				Pos_Script.zBlink=false;
				MDIInput_Script.isXSelected=false;
			    MDIInput_Script.isYSelected=false;
				MDIInput_Script.isZSelected=false;
				//Debug.Log("operationeInitial is true");
			}
			
			else if(Main.operationBottomScrExecute)
			{
				//Debug.Log("operationexec");
				Main.operationBottomScrInitial=true;
				Main.operationBottomScrExecute=false;
				Main.runtimeIsBlink=false;
				Main.partsNumBlink=false;
				
			}
		}
		//宋荣
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 0;
					}
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 1;
					else if(Main.ProgEDITFlip == 3)
						Main.ProgEDITFlip = 2;
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 1)
					{
						Main.ProgEDITFlip = 0;
						Main.ProgEDITProg = true;
						Main.ProgEDITList = false;
					}
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 1;
					else if(Main.ProgEDITFlip == 3)
						Main.ProgEDITFlip = 2;
				}
			}
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetTwo)
				{
					Main.OffSetTwo = false;
					Main.OffSetOne = true;
				}
			}
		}
	}
	
	//软键 Button1
	void FirstButton () {
		//位置界面时按下
		if(Main.PosMenu)
		{
			//绝对坐标
			//宋荣
			if(Main.posOperationMode)
			{
				/*if(Main.statusBeforeOperation==1)
				{
					Pos_Script.preSetAbsoluteCoo=CooSystem_script.absolute_pos;
					Debug.Log("预置成功");
				}
				if((Main.statusBeforeOperation==2||Main.statusBeforeOperation==3)&&(MDIInput_Script.isXSelected||MDIInput_Script.isYSelected||MDIInput_Script.isZSelected))
				{
					Pos_Script.preSetRelativeCoo=CooSystem_script.relative_pos;
					Debug.Log("预置相对坐标成功");
				}*/
				if(Main.operationBottomScrInitial)
			    {
				   if(Main.statusBeforeOperation==1)
					{
						Main.operationBottomScrInitial=false;
				        Main.operationBottomScrExecute=true;
				        preSetSelected=true;
					}
				   
				   if((Main.statusBeforeOperation==2||Main.statusBeforeOperation==3)&&(MDIInput_Script.isXSelected||MDIInput_Script.isYSelected||MDIInput_Script.isZSelected))
				   {
					    Pos_Script.preSetRelativeCoo=CooSystem_script.relative_pos;
						if(MDIInput_Script.isXSelected)
							Debug.Log("预置相对坐标x成功");
						if(MDIInput_Script.isYSelected)
							Debug.Log("预置相对坐标y成功");
						if(MDIInput_Script.isZSelected)
							Debug.Log("预置相对坐标z成功");
						MDIInput_Script.isXSelected=false;
						MDIInput_Script.isYSelected=false;
						MDIInput_Script.isZSelected=false;
				     	
				   }
				   //Main.operationBottomScrExecute=false;
			     }
				return;
			}
			//宋荣
			Main.AbsoluteCoo = true;
			Main.RelativeCoo = false;
			Main.GeneralCoo = false;
			//Debug.Log("sdfsdfsdf1234");
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				//程序
				if(Main.ProgEDITFlip == 0)
				{
					Main.ProgEDITProg = true;
					Main.ProgEDITList = false;
				}
			}
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = true;
				Main.OffSetSetting = false;
				Main.OffSetCoo = false;
			}
			else if(Main.OffSetCoo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.SearchNo(Main.InputText);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = 57f;
				}
			}	
		}
	}
	
	//软键 Button2
	void SecondButton () {
		//位置界面时按下
		if(Main.PosMenu)
		{
			//宋荣
			if(Main.posOperationMode)
			{
				if(Main.operationBottomScrInitial)
			    {
				  
				   
				   if((Main.statusBeforeOperation==2||Main.statusBeforeOperation==3)&&(MDIInput_Script.isXSelected||MDIInput_Script.isYSelected||MDIInput_Script.isZSelected))
				   {
						if(MDIInput_Script.isXSelected)
						{
					        CooSystem_script.relative_pos.x=0;
							Debug.Log("归零x成功");
						}
						
						if(MDIInput_Script.isYSelected)
						{
							
							CooSystem_script.relative_pos.y=0;
							Debug.Log("归零Y成功");
						}
						if(MDIInput_Script.isZSelected)
						{
							CooSystem_script.relative_pos.z=0;
							Debug.Log("归零Z成功");
						}
						MDIInput_Script.isXSelected=false;
						MDIInput_Script.isYSelected=false;
						MDIInput_Script.isZSelected=false;
				     	
				   }
				   //Main.operationBottomScrExecute=false;
			     }
				return;
			}
			//宋荣
			//相对坐标
			Main.AbsoluteCoo = false;
			Main.RelativeCoo = true;
			Main.GeneralCoo = false;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITFlip == 0)
				{
					//列表
					if(Main.current_filenum > 0)
						Main.RealListNum = Main.current_filenum;
					else
						Main.RealListNum = 1;
					Main.ProgEDITCusor = 175f;
					Main.FileNameList.Clear();
					Main.FileSizeList.Clear();
					Main.FileDateList.Clear();
					Main.ProgUnusedNum = 400;
					Main.ProgUnusedSpace = 419430400;
					Main.ProgUsedNum = 0;
					Main.ProgUsedSpace = 0;
					FileInfo FileTestExtension;	
					string[] TempFileList = Directory.GetFiles(Application.dataPath + "/Resources/Gcode/");
					string TestStr = "";
					string[] TempStrArray;
					string[] TempNameArray = new string[8];
					int[] TempSizeArray = new int[8];
					string[] TempDateArray = new string[8];
					int Eight = 0;
					for(int i = 0; i < TempFileList.Length; i++)
					{
						FileTestExtension = new FileInfo(TempFileList[i]);
						TestStr = FileTestExtension.Extension.ToUpper();
						if(TestStr == ".CNC" || TestStr == ".NC" || TestStr == ".TXT")
						{
							TempStrArray = TempFileList[i].Split('/');
							TempStrArray = TempStrArray[TempStrArray.Length - 1].Split('.');
							char[] temp_name = TempStrArray[0].ToString().ToCharArray();
							bool normal_flag = true;
							for(int q = 0; q < temp_name.Length; q++)
							{
								if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
									continue;
								else
								{
									normal_flag = false;
									break;
								}
							}
							if(normal_flag)
							{
								Main.FileNameList.Add(TempStrArray[0]);
								Main.FileSizeList.Add((Int32)FileTestExtension.Length);
								Main.ProgUsedNum++;
								Main.ProgUsedSpace +=  (Int32)FileTestExtension.Length;
								Main.FileDateList.Add(FileTestExtension.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
							}
						}	
					}
					Main.TotalListNum = Main.FileNameList.Count;
					int start_index = Main.RealListNum - 1;
					if(Main.FileNameList.Count  - start_index >= 8)
						Eight = start_index + 8;
					else
						Eight = Main.FileNameList.Count;
					for(int i = 0; i < 8; i++)
					{
						TempNameArray[i] = "";
						TempSizeArray[i] = 0;
						TempDateArray[i] = "";
					}
					int array_index = -1;
					for(int i = start_index; i < Eight; i++)
					{
						array_index++;
						TempNameArray[array_index] = Main.FileNameList[i];
						TempSizeArray[array_index] = Main.FileSizeList[i];
						TempDateArray[array_index] = Main.FileDateList[i];
					}
					
					Main.CodeName01 = TempNameArray[0];
					Main.CodeName02 = TempNameArray[1];
					Main.CodeName03 = TempNameArray[2];
					Main.CodeName04 = TempNameArray[3];
					Main.CodeName05 = TempNameArray[4];
					Main.CodeName06 = TempNameArray[5];
					Main.CodeName07 = TempNameArray[6];
					Main.CodeName08 = TempNameArray[7];
					
					Main.CodeSize01 = TempSizeArray[0];
					Main.CodeSize02 = TempSizeArray[1];
					Main.CodeSize03 = TempSizeArray[2];
					Main.CodeSize04 = TempSizeArray[3];
					Main.CodeSize05 = TempSizeArray[4];
					Main.CodeSize06 = TempSizeArray[5];
					Main.CodeSize07 = TempSizeArray[6];
					Main.CodeSize08 = TempSizeArray[7];
					
					Main.UpdateDate01 = TempDateArray[0];
					Main.UpdateDate02 = TempDateArray[1];
					Main.UpdateDate03 = TempDateArray[2];
					Main.UpdateDate04 = TempDateArray[3];
					Main.UpdateDate05 = TempDateArray[4];
					Main.UpdateDate06 = TempDateArray[5];
					Main.UpdateDate07 = TempDateArray[6];
					Main.UpdateDate08 = TempDateArray[7];
					
					Main.ProgUnusedNum -= Main.ProgUsedNum;
					Main.ProgUnusedSpace -= Main.ProgUsedSpace;
					Main.ProgEDITProg = false;
					Main.ProgEDITList = true;
				}
				
				if(Main.ProgEDITFlip == 1)
				{
					//O检索
					if(Main.ProgEDITList)
					{
						if(Main.FileNameList.Count == 0)
							Debug.Log("No files in the memory now!");
						else
						{
							if(Main.FileNameList[Main.RealListNum - 1].ToCharArray()[0] == 'O')
							{
								char[] temp_name = Main.FileNameList[Main.RealListNum - 1].ToString().ToCharArray();
								bool normal_flag = true;
								for(int q = 0; q < temp_name.Length; q++)
								{
									if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
										continue;
									else
									{
										normal_flag = false;
										break;
									}
								}
								if(normal_flag)
								{
									Main.ProgramNum = Convert.ToInt32(Main.FileNameList[Main.RealListNum - 1].Trim('O'));
									Main.current_filenum = Main.RealListNum;
									Main.current_filename = Main.FileNameList[Main.RealListNum - 1].ToString();
									Main.ProgEDITProg = true;
									Main.ProgEDITList = false;
									Main.CodeForAll.Clear();
									Main.RealCodeNum = 1;
									Main.HorizontalNum = 1;
									Main.VerticalNum = 1;
									string SLine = "";
									FileStream faceInfoFile;
									FileInfo ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt");
									if(ExistCheck.Exists)	
										faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt", FileMode.Open, FileAccess.Read);
									else 
									{
										ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc");
										if(ExistCheck.Exists)
											faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc", FileMode.Open, FileAccess.Read);
										else
											faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".nc", FileMode.Open, FileAccess.Read);
									}
									StreamReader sR = new StreamReader(faceInfoFile);
									SLine = sR.ReadLine();
									while(SLine != null)
									{
										Main.CodeForAll.Add(SLine.ToUpper().Trim().Trim(';', '；'));
										SLine = sR.ReadLine();
									}
									sR.Close();
									if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
										Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
									Main.TotalCodeNum = Main.CodeForAll.Count;
									MDIEdit_Script.CodeEdit();
									Main.ProgEDITCusorH = 32f;
									Main.ProgEDITCusorV = 100f;
									Main.EDITText.text = Main.TempCodeList[0][0];
									Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
								}
								else
									Debug.Log("Program name is ilegal!");
							}
							else	
								Debug.Log("Program name is ilegal!");
						}
					}
					else
					{
						if(Main.FileNameList.Count == 0)
						{
							FileStream prog_file;
							string[] TempFileList = Directory.GetFiles(Application.dataPath + "/Resources/Gcode/");
							if(TempFileList.Length > 0)
							{
								string TestStr = "";
								string[] TempStrArray;
								FileInfo FileTestExtension;	
								Main.FileNameList.Clear();
								Main.FileSizeList.Clear();
								Main.FileDateList.Clear();
								for(int i = 0; i < TempFileList.Length; i++)
								{
									FileTestExtension = new FileInfo(TempFileList[i]);
									TestStr = FileTestExtension.Extension.ToUpper();
									if(TestStr == ".CNC" || TestStr == ".NC" || TestStr == ".TXT")
									{
										TempStrArray = TempFileList[i].Split('/');
										TempStrArray = TempStrArray[TempStrArray.Length - 1].Split('.');
										char[] temp_name = TempStrArray[0].ToString().ToCharArray();
										bool normal_flag = true;
										for(int q = 0; q < temp_name.Length; q++)
										{
											if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
												continue;
											else
											{
												normal_flag = false;
												break;
											}
										}
										if(normal_flag)
										{
											Main.FileNameList.Add(TempStrArray[0]);
											Main.FileSizeList.Add((Int32)FileTestExtension.Length);
											Main.ProgUsedNum++;
											Main.ProgUsedSpace +=  (Int32)FileTestExtension.Length;
											Main.FileDateList.Add(FileTestExtension.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
										}						
									}	
								}
								for(int a = 0; a < TempFileList.Length; a++)
								{
									string directory_str = TempFileList[a].ToString().ToUpper();
									TempStrArray = directory_str.Split('/');
									string[] prog_num = TempStrArray[TempStrArray.Length - 1].ToString().Split('.');
									char[] temp_name = prog_num[0].ToString().ToCharArray();
									bool normal_flag = true;
									for(int q = 0; q < temp_name.Length; q++)
									{
										if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
											continue;
										else
										{
											normal_flag = false;
											break;
										}
									}
									if(normal_flag)
									{
										Main.ProgramNum = Convert.ToInt32(prog_num[0].ToString().Trim('O'));
										if(TempStrArray[TempStrArray.Length - 1].StartsWith("O"))
										{
											if(TempStrArray[TempStrArray.Length - 1].ToString().EndsWith(".TXT") || TempStrArray[TempStrArray.Length - 1].ToString().EndsWith(".CNC") || TempStrArray[TempStrArray.Length - 1].ToString().EndsWith(".NC"))
											{
												prog_file = new FileStream(Application.dataPath + "/Resources/Gcode/" + TempStrArray[TempStrArray.Length - 1], FileMode.Open, FileAccess.Read);
												StreamReader sR = new StreamReader(prog_file);
												string SLine = "";
												SLine = sR.ReadLine();
												while(SLine != null)
												{
													Main.CodeForAll.Add(SLine.ToUpper().Trim().Trim(';', '；'));
													SLine = sR.ReadLine();
												}
												sR.Close();
												if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
													Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
												Main.TotalCodeNum = Main.CodeForAll.Count;
												MDIEdit_Script.CodeEdit();
												Main.ProgEDITCusorH = 32f;
												Main.ProgEDITCusorV = 100f;
												Main.current_filenum = a + 1;
												Main.current_filename = prog_num[0];
												Main.EDITText.text = Main.TempCodeList[0][0];
												Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
												break;
											}
										}
									}	
								}
							}
							else
								Debug.Log("No files in the memory now!");
					}
					else
					{
						if(Main.current_filenum < Main.FileNameList.Count)
						{
							Main.current_filenum++;
							Main.RealListNum = Main.current_filenum;
						}
						else
						{
							Main.RealListNum = 1;
							Main.current_filenum = 1;
						}
						if(Main.FileNameList[Main.RealListNum - 1].ToCharArray()[0] == 'O')
						{
							char[] temp_name = Main.FileNameList[Main.RealListNum - 1].ToString().ToCharArray();
							bool normal_flag = true;
							for(int q = 0; q < temp_name.Length; q++)
							{
								if(temp_name[q] == 'O' || (temp_name[q] >= '0' && temp_name[q] <= '9'))
									continue;
								else
								{
									normal_flag = false;
									break;
								}
							}
							if(normal_flag)
							{
								Main.ProgramNum = Convert.ToInt32(Main.FileNameList[Main.RealListNum - 1].Trim('O'));
								Main.ProgEDITProg = true;
								Main.ProgEDITList = false;
								Main.CodeForAll.Clear();
								Main.RealCodeNum = 1;
								Main.HorizontalNum = 1;
								Main.VerticalNum = 1;
								string SLine = "";
								FileStream faceInfoFile;
								FileInfo ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt");
								if(ExistCheck.Exists)	
									faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".txt", FileMode.Open, FileAccess.Read);
								else 
								{
									ExistCheck = new FileInfo(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc");
									if(ExistCheck.Exists)
										faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".cnc", FileMode.Open, FileAccess.Read);
									else
										faceInfoFile = new FileStream(Application.dataPath + "/Resources/Gcode/" + Main.FileNameList[Main.RealListNum - 1] + ".nc", FileMode.Open, FileAccess.Read);
								}
								StreamReader sR = new StreamReader(faceInfoFile);
								SLine = sR.ReadLine();
								while(SLine != null)
								{
									Main.CodeForAll.Add(SLine.ToUpper().Trim().Trim(';', '；'));
									SLine = sR.ReadLine();
								}
								sR.Close();
								if(Main.CodeForAll[Main.CodeForAll.Count - 1] == "")
									Main.CodeForAll.RemoveAt(Main.CodeForAll.Count - 1);
								Main.TotalCodeNum = Main.CodeForAll.Count;
								MDIEdit_Script.CodeEdit();
								Main.ProgEDITCusorH = 32f;
								Main.ProgEDITCusorV = 100f;
								Main.EDITText.text = Main.TempCodeList[0][0];
								Main.TextSize = Main.sty_EDITTextField.CalcSize(new GUIContent(Main.EDITText.text));
							}
							else
								Debug.Log("Program name is ilegal!");
						}
						else	
							Debug.Log("Program name is ilegal!");	
					}
				}	
			}
		}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = false;
				Main.OffSetSetting = true;
				Main.OffSetCoo = false;
			}
			else if(Main.OffSetCoo)
			{
				CooSystem_script.Measure(Main.InputText);
				Main.InputText = "";
				Main.CursorText.text = Main.InputText;
				Main.ProgEDITCusorPos = 57f;
			}
		}
	}
	
	//软键 Button3
	void ThirdButton () 
	{
		//位置界面时按下
		if(Main.PosMenu)
		{
			//宋荣
			if(Main.posOperationMode)
				return;
			//宋荣
			//综合显示
			Main.AbsoluteCoo = false;
			Main.RelativeCoo = false;
			Main.GeneralCoo = true;
		}
		//程序界面时按下
		if(Main.ProgMenu)
		{
				
		}
		//设置界面时按下
		if(Main.SettingMenu)
		{
			if(Main.OffSetOne)
			{
				Main.OffSetTool = false;
				Main.OffSetSetting = false;
				Main.OffSetCoo = true;
			}
			else
			{
				
			}	
		}
	}
	
	//软键 Button4
	void FourthButton () 
	{	//宋荣
		if(Main.PosMenu)
		{
			if(Main.operationBottomScrInitial)
			{
				Main.operationBottomScrInitial=false;
				Main.operationBottomScrExecute=true;
				Main.runtimeIsBlink=false;
				Main.partsNumBlink=true;
				//Main.operationBottomScrExecute=false;
			}
		}
		//宋荣
		if(Main.ProgMenu)
		{
			if(Main.ProgEDITFlip == 0)
			{
				
			}
			else if(Main.ProgEDITFlip == 1)
			{
				
			}
			else if(Main.ProgEDITFlip == 2)
			{
				
			}
			else 
			{
				
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetCoo && Main.OffSetTwo)
			{
				if(Main.InputText != "")
				{
					CooSystem_script.PlusInput(Main.InputText, true);
					Main.InputText = "";
					Main.CursorText.text = Main.InputText;
					Main.ProgEDITCusorPos = 57f;
				}
			}
		}
	}
	
	//软键 Button5
	void FifthButton () {
		//宋荣 position模式下响应函数
		if(Main.PosMenu)
		{
			if(!Main.operationBottomScrInitial&&(Main.RelativeCoo||Main.AbsoluteCoo||Main.GeneralCoo))
			{
				Main.operationBottomScrInitial=true;
				Main.posOperationMode=true;
				if(Main.RelativeCoo)
					Main.statusBeforeOperation=2;
				if(Main.AbsoluteCoo)
					Main.statusBeforeOperation=1;
				if(Main.GeneralCoo)
					Main.statusBeforeOperation=3;
				Main.RelativeCoo=false;
				Main.AbsoluteCoo=false;
				Main.GeneralCoo=false;
				//if(Main.operationBottomScrInitial)
				 Debug.Log("响应fifth");
			}
			
			else if(Main.operationBottomScrInitial)
			{
				Main.operationBottomScrInitial=false;
				Main.operationBottomScrExecute=true;
				Main.runtimeIsBlink=true;
				Debug.Log("runtimeIsBlink变为true");
				Main.partsNumBlink=false;
				//Main.operationBottomScrExecute=false;
			}
			
		    else if(Main.operationBottomScrExecute)
			{
				Main.operationBottomScrInitial=true;
				Main.operationBottomScrExecute=false;
				if(Main.runtimeIsBlink)
				{
					Main.RunningTimeH=0;
					Main.RunningTimeM=0;
					//Debug.Log("运行时间归零");
				}
				if(Main.partsNumBlink)
				{
					Main.PartsNum=0;
				}
				if(preSetSelected)
				{
					if(Main.statusBeforeOperation==1)
				   {
					    Pos_Script.preSetAbsoluteCoo=CooSystem_script.absolute_pos;
						preSetSelected=false;
				 	    Debug.Log("预置成功");
				   }
				 /*  if((Main.statusBeforeOperation==2||Main.statusBeforeOperation==3)&&(MDIInput_Script.isXSelected||MDIInput_Script.isYSelected||MDIInput_Script.isZSelected))
				   {
					Pos_Script.preSetRelativeCoo=CooSystem_script.relative_pos;
					Debug.Log("预置相对坐标成功");
				   }*/
				}
				Main.runtimeIsBlink=false;
				Main.partsNumBlink=false;
				//
			}
		}
		//宋荣
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
				}
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 0)
						Main.ProgEDITFlip = 1;
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
				else if(Main.OffSetCoo)
				{
					if(Main.InputText != "")
					{
						CooSystem_script.PlusInput(Main.InputText, false);
						Main.InputText = "";
						Main.CursorText.text = Main.InputText;
						Main.ProgEDITCusorPos = 57f;
					}
				}
			}
		}
	}
	
	//向后翻页软键
	void NextPage () {
		//宋荣
		if(Main.PosMenu)
		{
			if(!Main.operationBottomScrInitial&&(Main.RelativeCoo||Main.AbsoluteCoo||Main.GeneralCoo))
			{
				Main.operationBottomScrInitial=true;
				Main.posOperationMode=true;
				if(Main.RelativeCoo)
					Main.statusBeforeOperation=2;
				if(Main.AbsoluteCoo)
					Main.statusBeforeOperation=1;
				if(Main.GeneralCoo)
					Main.statusBeforeOperation=3;
				Main.RelativeCoo=false;
				Main.AbsoluteCoo=false;
				Main.GeneralCoo=false;
				//if(Main.operationBottomScrInitial)
				 // Debug.Log("响应fifth");
			}
			
			
		}
		//宋荣
		if(Main.ProgMenu)
		{
			if(Main.ProgEDIT)
			{
				if(Main.ProgEDITProg)
				{
					if(Main.ProgEDITFlip == 1)	
						Main.ProgEDITFlip = 2;
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 3;
				}
				
				if(Main.ProgEDITList)
				{
					if(Main.ProgEDITFlip == 1)
						Main.ProgEDITFlip = 2;
					else if(Main.ProgEDITFlip == 2)
						Main.ProgEDITFlip = 3;
				}
			}
		}
		
		if(Main.SettingMenu)
		{
			if(Main.OffSetTool)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
			if(Main.OffSetCoo)
			{
				if(Main.OffSetOne)
				{
					Main.OffSetTwo = true;
					Main.OffSetOne = false;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
