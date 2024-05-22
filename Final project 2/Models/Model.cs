using System.ComponentModel.DataAnnotations;

namespace Final_project_2.Models
{

    public class Person
    {
        public int Id { get; set; }
        public bool Is_Admin {  get; set; } = false;
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(11)]
        public string PhoneNumber { get; set; } 
        public DateTime Joined_at { get; set; }
        public string City_And_Country { get; set; }
        public string Language { get; set; }
        public string Favorit_food { get; set; }
        public string Favorit_sport { get; set; }
        
        public bool Is_Actived { get; set; }

        public string Telegram { get; set; }
        public string Instagram { get; set; }

    }

    public class Tour
    {
        public int Id { get; set; }
        public string Tour_Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Capacity { get; set; }
        public string Price_per_person { get; set; }

        public bool Is_Acive { get; set; }

        public string Quality_level { get; set; }
        public string Status_limit { get; set; }

        public string Image1 {get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image_bg { get; set; }

        public string Touring_area { get; set;}
    }


    public class Comments
    {
        public int Id { get; set; }
        public Tour Tour { get; set; }
        public Person Person { get; set; }
        public string Text { get; set; }
        public bool Is_Actived { get; set; }

    }

    public class Reservation
    {
        public int Id { get; set; }
        public Active_Tours Active_Tour { get; set; }
        public Person Person { get; set; }
        public bool Is_Actived { get; set; }
        public int Reserved_Count { get; set; }

    }

    public class Images
    {
        public int Id { get; set; }
        public Tour Tour { get; set; }
        public string Image_Address { get; set; }
    }


    public class Active_Tours
    {
        public int Id { get; set; }
        public Tour Tour { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
    }

}
