using System;
using System.Collections.Generic;
using System.Text;

namespace Sandwich.Models
{
	public class New
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Discription { get; set; }
		public string VideoPath { get; set; }
		public bool IsActive { get; set; }


		//new is not available and we use new1
		public override bool Equals(object obj)
		{
			New new1 = obj as New;
			return this.Id == new1.Id;
		}
	}

}
