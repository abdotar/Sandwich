
namespace Sandwich.Models
{
	public class Meal
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Discription { get; set; }
		public string ImagePath { get; set; }
		public int Price { get; set; }
		public int MealTypeId { get; set; }

		public override bool Equals(object obj)
		{
			Meal meal = obj as Meal;
			return this.Id == meal.Id;
		}
	}
}
