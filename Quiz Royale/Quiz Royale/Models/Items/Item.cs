namespace Quiz_Royale.Models.Items
{
    /// <summary>
    /// Deze klasse dient als basis voor de verschillende items die worden gemaakt in de applicatie.
    /// </summary>
    public abstract class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int RequiredAmount { get; set; }

        public Payment Payment { get; set; }

        /// <summary>
        /// Creëert een item met de gegeven eigenschappen.
        /// </summary>
        /// <param name="id">Het id van het item.</param>
        /// <param name="name">De naam van het item.</param>
        /// <param name="picture">De afbeelding van het item.</param>
        /// <param name="requiredAmount">De vereiste hoeveelheid XP of coins dat nodig is om het item te kopen.</param>
        /// <param name="payment">De betaalwijze om het item te kopen.</param>
        public Item(int id, string name, string picture, int requiredAmount, Payment payment)
        {
            Id = id;
            Name = name;
            Picture = picture;
            RequiredAmount = requiredAmount;
            Payment = payment;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Item otherItem = (Item)obj;

            return Id == otherItem.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
