using System;
using System.Resources;
using System.Drawing;

	class MCResources
	{		
		static void Main()
		{
			ResourceWriter rw = new ResourceWriter("MCListBox.resources");
			using(Image image = Image.FromFile("../../TRFFC10a.ICO"))
			{
				rw.AddResource("StopLight",image);
				rw.Close();
			}
		}
	}

