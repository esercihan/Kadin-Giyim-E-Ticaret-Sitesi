using eserProje.Models;

namespace eserProje.ViewModel
{
    public class GiysiDetayViewModel
    {
        public Cloth Cloth { get; set; }

        public IEnumerable<Cloth> Clothes { get; set; }
        
    }
}
