/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 6/17/2024
 * Time: 8:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace codeTranslator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		public string line = " ";
		public string [] keywords = {" ","FOR","TO","NEXT","THEN","WHILE","IF","ELSE","ENDIF","DO","GOTO","SUB","END","PRINT","INPUT","PROCEDURE","FUNCTION","DIM","REDIM","INTEGER","REAL","DOUBLE","CHAR","STRING"};
		public char[] separator = {' ','(',')','='};
		public string [] linecode;// = line.Split(separator);
		public int [] indexkeyqords = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		
		public void getLineOfCode(string s)
		{
			line  = s ;
		}
		
		public int[] searchForKeyWords(int G)
		{
		
			int i = 0;
		
			linecode = line.Split(separator);
			int countergasite = -1;
			while(i<linecode.Length-1)
			{
				for(int k = 0 ; k < keywords.Length-1;k++){
					if(G==0){
						if(linecode[i].ToString().ToUpper()!=keywords[k])
						{
							countergasite++;
							try{
								indexkeyqords[countergasite]=k;
							}
							catch{};
							
						}
					}
					else if(G==1)
					{
						if(linecode[i].ToString().ToUpper()==keywords[k])
						{
							countergasite++;
							try{
								indexkeyqords[countergasite]=k;
							}
							catch{};
							
						}
					}
				
				
					
				}
				i++;
			};
			return indexkeyqords;
		}
		
		
		void Button1Click(object sender, EventArgs e)
		{
			int typeofrezult = 1;
			getLineOfCode(this.textBox1.Text);
	
			int [] rez = searchForKeyWords(0);
			int i = 0;
			string s = " ";
			
			//search founded 
			if(typeofrezult==0){
			while(i<rez.Length){
			
				s += rez[i].ToString() + " \r\n";
			
			
				i++;
			};
			}
			if(typeofrezult==2){
			while(i<rez.Length){
			
					
				s += keywords[rez[i]].ToString() +  " \r\n";
				i++;
			};
			}
			if(typeofrezult==1){
			//show line of code atoms
			 i = 0;
			 string c = "";
			 int FLAGOFOP =-1;
			while(i<linecode.Length){
			
			 	c = linecode[i].ToString();
			 	//if(c==" "){c="//*<SPACE>*//";}
			 	//if(c==""){c="//*<EMPTY>*//";}
			 	//if(c.Contains("2")==true){c="//*" + c + "*//"; }
			 	if(c.Contains("2")==true){c=" ";}
			 	if(c=="INPUT"){c="INPUT(";FLAGOFOP=1;}
			 	//s += c + " : " + i.ToString() + " \r\n";
			 	s+=c;
				i++;
			};
			 if(FLAGOFOP==1){s+=");";}
			}
			this.textBox2.Text =  s;
		}
		
	}
}
