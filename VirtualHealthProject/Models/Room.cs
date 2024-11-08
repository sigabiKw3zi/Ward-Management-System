using System.ComponentModel.DataAnnotations;


namespace VirtualHealthProject.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
    }
}
