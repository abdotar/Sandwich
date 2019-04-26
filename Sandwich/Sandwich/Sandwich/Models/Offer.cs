using System;
using System.Collections.Generic;
using System.Text;

namespace Sandwich.Models
{
	public class Offer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Discription { get; set; }
		public string ImagePath { get; set; }
		public bool IsMain { get; set; }
		public bool IsActive { get; set; }

		public override bool Equals(object obj)
		{
			Offer offer = obj as Offer;
			return this.Id == offer.Id;
		}
	}
}
