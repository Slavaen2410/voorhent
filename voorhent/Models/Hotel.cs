namespace voorhent.Models;
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; } // Добавлено свойство City
        public string Country { get; set; } // Добавлено свойство Country
        public decimal PricePerNight { get; set; } // Добавлено свойство PricePerNight
    }
