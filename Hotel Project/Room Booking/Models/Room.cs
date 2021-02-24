using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Room_Booking.Models
{
    public class Room
    {
        // (number of beds, room-size/quality, etc.)

        [Key]
        public int Id { get; set; }

        //[Range(1, 5, ErrorMessage = "Number must be between 1 and 5")]
        [DisplayName("Number Of Beds")]
        [Required]
        public int NumberOfBeds { get; set; }

        //[Range(10, 100, ErrorMessage = "Size must be between 10 and 100m²")]
        [DisplayName("Room Size (m²)")]
        [Required]
        public int RoomSize { get; set; }


        [DisplayName("Room Quality")]
        [Required]
        public int RoomQuality { get; set; }

        //[EnumDataType(typeof(Quality))]
        //public Quality RoomQuality { get; set; }


        //public SelectList Genres { get; set; }
        //public string MovieGenre { get; set; }


        //[EnumDataType(typeof(Gender))]
        //public Gender GenderType { get; set; }


        //public enum Gender
        //{
        //    Male = 1,
        //    Female = 2
        //}


        public bool Available { get; set; }


        //public enum Quality
        //{
        //    BAD, OK, GOOD, EXCELLENT
        //}

        //public Quality RoomQuality
        //{
        //    get { return roomQuality; }
        //    set
        //    {
        //        switch (value)
        //        {
        //            case 1:
        //            {
        //                    roomQuality = Quality.BAD;
        //            }
        //                break;
        //        }
        //    }
        //}

    }

}
