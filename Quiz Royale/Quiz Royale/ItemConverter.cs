using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class ItemConverter: JsonConverter<Item>
    {
        public class ItemDTO
        {
            public int Id { get; set; }
            public ItemType ItemType { get; set; }
            public string Name { get; set; }
            public string Picture { get; set; }
            public int Cost { get; set; }
            public Payment PaymentType { get; set; }
            public string Description { get; set; }
        }

        public override Item Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ItemDTO item = JsonSerializer.Deserialize<ItemDTO>(ref reader, options); // todo reuse factory
            return new ItemFactory().MakeItem(
                item.Id, 
                item.ItemType, 
                item.Name, 
                item.Picture, 
                item.Cost, 
                item.PaymentType, 
                item.Description);
        }

        public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
