using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class Basket
    {
        public int Id { get; set; }
        public string ClientId { get; set; } // identify users basket
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public void AddCourseItem(Course course)
        {
            if (Items.All(Items => Items.CourseId != course.Id)) // check course doesn't already exist in the basket
            {
                Items.Add(new BasketItem { Course = course });
            }
        }
        public void RemoveCourse(Guid courseId)
        {
            var course = Items.FirstOrDefault(item => item.CourseId == courseId);
            Items.Remove(course);
        }
    }
}