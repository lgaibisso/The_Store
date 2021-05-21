using The_Store.Enums;

namespace The_Store.Models
{
    public class Payment
    {
        public int OrderId { get; set; }

        public CreditCard CreditCardType { get; set; }

        public string CreditCardNumber { get; set; }
    }
}
