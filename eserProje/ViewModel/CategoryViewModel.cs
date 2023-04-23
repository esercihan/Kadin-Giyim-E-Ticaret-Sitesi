using eserProje.Models;

namespace eserProje.ViewModel
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<MainCategory> MainCategories { get; set; }
    }
}
