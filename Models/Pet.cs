using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType 
    {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever
    }
    public enum PetColorType 
    {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted
    }
    public class Pet
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color { get; set; }

        // public bool checkedIn { get; set;}
         public DateTime? checkedIn { get; set;}


        // This is the Id of the baker who made this bread
        // In a moment, we'll see how .NET can use this field to 
        // join our tables together for us
        [Required]
        [ForeignKey("PetOwners")]
        public int petOwnerId { get; set; }

        // While bakedById is an integer with the baker's ID,
        // this field is an actual Baker object. 
        // This will allow us to nest the baker object
        // inside our bread response from `GET /breads`
        public PetOwners petOwner { get; set; }
    }
}
