using Newtonsoft.Json;

namespace TelephoneBookWeb.Models
{
    public class Persone
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string FatherName { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
    }
}
