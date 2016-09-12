/*
 * Created by SharpDevelop.
 * User: michel
 * Date: 9/09/2016
 * Time: 17:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Arsalis.WebcamLibrary.Test
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			Arsalis.WebcamLibrary.WebcamLibrary test = new WebcamLibrary();
			
			if(test.webcamAvailable)
			{
    			for(int i = 0; i<test.WebcamListNames.Length; i++)
    			{
    				Console.WriteLine(i.ToString() + ": " + test.WebcamListNames[i]);
    			}
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}