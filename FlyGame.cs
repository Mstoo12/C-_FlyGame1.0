using System;
namespace FlyGame
{
	class program
	{
		//用静态字段模拟全局变量
		static int[] Maps = new int[100];
		
		//声明静态数组用来声明A,B的坐标
		static int[] PlayPos=new int[2];
		
		//
		static string[] PlayerNames=new string[2];
		
		//主函数
		static void Main(string[] args)
		{
			
			
			
			//调用GameShow
			GameShow();
			
			//输入玩家姓名的函数
			Console.WriteLine("请输入A姓名");
			PlayerNames[0]=Console.ReadLine();
			while(PlayerNames[0]=="")
			{
				Console.WriteLine("A的姓名不能为空，清重新输入");
				PlayerNames[0]=Console.ReadLine();
			}
			Console.WriteLine("输入玩家B的姓名");
			PlayerNames[1]=Console.ReadLine();
			while(PlayerNames[0]==PlayerNames[1]||PlayerNames[1]=="")
			{
				if(PlayerNames[1]=="")
				{
					Console.WriteLine("姓名不能为空，请重新输入");
					PlayerNames[1]=Console.ReadLine();
				}
				else
				{
					Console.WriteLine("A与B的名字相同，请重新输入");
					PlayerNames[1]=Console.ReadLine();
				}
				
			}//PlayerNames结尾
			
			//清屏函数，重新调用游戏头所需的各种函数
			Console.Clear();
			GameShow();
			Console.WriteLine("玩家A用{0}表示",PlayerNames[0]);
			Console.WriteLine("玩家B用{0}表示",PlayerNames[1]);
			
			//调用地图初始化方法
			InitailMap();
			
			//调用画地图的方法
			DrawMap();
			Console.ReadKey(true);
			
			//判断玩家是否在终点及游戏逻辑
			while(PlayPos[0]<99 && PlayPos[1]<99)
			{
				//PlayGame(0);
				//PlayGame(1);
				Console.WriteLine("{0}按任意键开始游戏",PlayerNames[0]);
				Console.ReadKey(true);
				Console.WriteLine("{0}是获得了4",PlayerNames[0]);
				Console.ReadKey(true);
				PlayPos[0]+=4;
				
				Console.ReadKey(true);
				Console.WriteLine("{0}按任意键开始游戏",PlayerNames[0]);
				Console.ReadKey(true);
				Console.WriteLine("{0}行动完了",PlayerNames[0]);
				
				if(PlayPos[0]==PlayPos[1])
				{
					Console.WriteLine("玩家{0}猜到了{1},玩家{2}退6格",PlayerNames[0],PlayerNames[1],PlayerNames[2]);
					PlayPos[1]-=6;
					Console.ReadKey(true);
				}
				
				else
				{
					switch(Maps[PlayPos[0]])
					{
						case 0:
						{
							Console.WriteLine("{0}踩到了方块，什么都不发生",PlayerNames[0]);
							Console.ReadKey(true);
							break;
						}
						case 1:
						{
							Console.WriteLine("{0}踩到了幸运轮盘,1-交换位置2-轰炸对方",PlayerNames[0]);
							string input=Console.ReadLine();
							while(true)
							{
								if(input=="1")
								{
									Console.WriteLine("玩家{0}与玩家{1}交换位置",PlayerNames[0],PlayerNames[1]);
									Console.ReadKey(true);
									int temp=PlayPos[0];
									PlayPos[0]=PlayPos[1];
									PlayPos[1]=temp;
									Console.WriteLine("交换完成，按任意键继续");
									Console.ReadKey(true);
									break;
						
								}
								
								else if(input == "2")
								{
									Console.WriteLine("玩家{0}轰炸玩家{1}",PlayerNames[0],PlayerNames[1]);
									Console.ReadKey(true);
									PlayPos[1]-=6;
									break;
								}
								
								
								
								else
								{
									Console.WriteLine("乱七八糟，错误");
									input=Console.ReadLine();
								}
								
							
								
							}
							
							break;
							
						
						}
						
						case 2:
						{
							Console.WriteLine("玩家{0}踩到了低劣，退6格",PlayerNames[0]);
							Console.ReadKey(true);
							PlayPos[0]-=6;
							break;
							
						}
						case 3:
						{
							Console.WriteLine("玩家{0}踩到了暂停，暂停一回合",PlayerNames[0]);
							Console.ReadKey(true);
							break;
						}
						case 4:
						{
							Console.WriteLine("玩家{0}踩到了时空隧道，前进10格",PlayerNames[0]);
							PlayPos[0]+=10;
							Console.ReadKey(true);
							break;
						}
					}//switch
				}//else				
				Console.Clear();
				DrawMap();	
			}//while			
			//控制台暂停
			
			
		}
		
		//游戏首界面
		public static void GameShow()
		{
			
			Console.ForegroundColor=ConsoleColor.Yellow;
			Console.WriteLine("****************");
			Console.ForegroundColor=ConsoleColor.Red;
			Console.WriteLine("****************");
			Console.ForegroundColor=ConsoleColor.Blue;
			Console.WriteLine("****************");
			Console.ForegroundColor=ConsoleColor.Red;
			Console.WriteLine("***飞行棋游戏*****");
			Console.WriteLine("****************");
			Console.ForegroundColor=ConsoleColor.Green;
			Console.WriteLine("****************");
		
		}
		
		
		//初始化地图
		public static void InitailMap()
		{
			
			
			int[] luckyturn={6,23,40,55,69,83};//幸运轮盘
			for(int i=0;i<luckyturn.Length;i++){
				Maps[luckyturn[i]]=1;
			}
			
			int[] landMine={5,13,17,33,38,50,64,80,94};//地雷
			for(int i=0;i<landMine.Length;i++){
				Maps[landMine[i]]=2;
				
			}
			
			int[] pause={9,27,60,93};//暂停
			for(int i=0;i<pause.Length;i++){
				Maps[pause[i]]=3;
			}
			
			
			int[] timeTunnel={20,25,45,63,72,88,90};//时空隧道
			for(int i=0;i<timeTunnel.Length;i++){
				Maps[timeTunnel[i]]=4;
			}
			
			
		}		
		
		
		//画地图
		public static void DrawMap()
		{
			//竖行换行判断
			Console.WriteLine();
			
			for(int i=0;i<30;i++){
				
				Console.Write(DrawStringMap(i));
			}
			//第一竖行
			Console.WriteLine();//第一横行之后需要换行
			for(int i=30;i<35;i++){
				for(int j=0;j<=28;j++){
					Console.Write("  ");
				}
				//竖行判断，绘制地图关
				Console.Write(DrawStringMap(i));
				Console.WriteLine();
			}
			
			//第二横行
			for(int i=64;i>=35;i--)
			{
				Console.Write(DrawStringMap(i));
			}
			Console.WriteLine();//第二横行换行
			
			for(int i=65;i<=69;i++)
			{
				Console.Write(DrawStringMap(i));
				Console.WriteLine();
			}
			for(int i=70;i<=99;i++)
			{
				Console.Write(DrawStringMap(i));
			}
			Console.WriteLine();
			
			
		}//DrawMap结尾
		
		//封装函数，判断关卡
		public static string DrawStringMap(int i)
		{
			
			string str="";
			if(PlayPos[0]==PlayPos[1] && PlayPos[0]==i)//判断玩家相对位置
			{
					
				str=("<>");
			}
			else if(PlayPos[0]==i)
			{
				str=("A");
			}
			else if(PlayPos[1]==i)
			{
				str=("B");
			}
			else
			{
				switch(Maps[i])//给地图赋值
				{
					case 0: 
						Console.ForegroundColor=ConsoleColor.Green;
						str="□"; break;
					case 1:
						Console.ForegroundColor=ConsoleColor.Yellow;
						str="◎"; break;
					case 2: 
						Console.ForegroundColor=ConsoleColor.Red;
						str="☆"; break;
					case 3: 
						Console.ForegroundColor=ConsoleColor.Blue;
						str="▲"; break;
							
					case 4:
					{
						Console.ForegroundColor=ConsoleColor.Green;
						str="卍"; break;
					}
						
				}
					
			}
			return str;
					
			
		}//DrawStringMap的结尾
		
	
		/*public static int PlayGame(int PlayerNames)
		{
			//Random r = new Random();
			//int rNumber=r.Next(1,7);
			Console.WriteLine("{0}按任意键开始游戏",PlayerNames[PlayerNames]);
			Console.ReadKey(true);
			Console.WriteLine("{0}是获得了4",PlayerNames[PlayerNames]);
			Console.ReadKey(true);
			PlayPos[0]+=4;
				//ChangePos();
				
			Console.ReadKey(true);
			Console.WriteLine("{0}按任意键开始游戏",PlayerNames[PlayerNames]);
			Console.ReadKey(true);
			Console.WriteLine("{0}行动完了",PlayerNames[PlayerNames]);
				
			if(PlayPos[PlayerNames]==PlayPos[1-PlayerNames])
			{
				Console.WriteLine("玩家{0}猜到了{1},玩家{2}退6格",PlayerNames[PlayerNames],PlayerNames[1-PlayerNames],PlayerNames[1-PlayerNames]);
				PlayPos[1-PlayerNames]-=6;
					//ChangePos();
				Console.ReadKey(true);
			}
				
			else
			{
				switch(Maps[PlayPos[PlayerNames]])
				{
					case 0:
					{
						Console.WriteLine("{0}踩到了方块，什么都不发生",PlayerNames[PlayerNames]);
						Console.ReadKey(true);
						break;
					}
					case 1:
					{
						Console.WriteLine("{0}踩到了幸运轮盘,1-交换位置2-轰炸对方",PlayerNames[PlayerNames]);
						string input=Console.ReadLine();
						while(true)
						{
							if(input=="1")
							{
								Console.WriteLine("玩家{0}与玩家{1}交换位置",PlayerNames[PlayerNames],PlayerNames[1-PlayerNames]);
								Console.ReadKey(true);
								int temp=PlayPos[PlayerNames];
								PlayPos[PlayerNames]=PlayPos[1-PlayerNames];
								PlayPos[1-PlayerNames]=temp;
								Console.WriteLine("交换完成，按任意键继续");
								Console.ReadKey(true);
								break;
						
							}
								
							else if(input == "2")
							{
								Console.WriteLine("玩家{0}轰炸玩家{1}",PlayerNames[PlayerNames],PlayerNames[1-PlayerNames]);
								Console.ReadKey(true);
								PlayPos[1-PlayerNames]-=6;
								//ChangePos();
								break;
							}
								
								
								
							else
							{
								Console.WriteLine("乱七八糟，错误");
								input=Console.ReadLine();
							}
								
							
								
						}
							
						break;
							
						
					}
						
					case 2:
					{
						Console.WriteLine("玩家{0}踩到了低劣，退6格",PlayerNames[PlayerNames]);
						Console.ReadKey(true);
						PlayPos[PlayerNames]-=6;
						//ChangePos();
						break;
							
					}
					case 3:
					{
						Console.WriteLine("玩家{0}踩到了暂停，暂停一回合",PlayerNames[PlayerNames]);
						Console.ReadKey(true);
						break;
					}
					case 4:
					{
						Console.WriteLine("玩家{0}踩到了时空隧道，前进10格",PlayerNames[PlayerNames]);
						PlayPos[PlayerNames]+=10;
						//ChangePos();
						Console.ReadKey(true);
						break;
					}
				}//switch
			}//else				
			Console.Clear();
			DrawMap();			
		}//playgame
	*/
	//当玩家坐标改变时
		/*public static void ChangePos()
		{
			if(PlayPos[0] < 0)
			{
				PlayPos[0]=0;
			}
			if(PlayPos[0]>=99)
			{
				PlayPos[0]=99;
			}
			if(PlayPos[1]<0)
			{
				PlayPos[1]=0;
			}
			if(PlayPos[1]>=99)
			{
				PlayPos[1]=99;
			}
		}
		*/
	
	}
	
	
	
	
	
	
	
}