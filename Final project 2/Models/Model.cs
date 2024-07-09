using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

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
        public DateTime Joined_at { get; set; } =DateTime.Now;
        public string City_And_Country { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Favorit_food { get; set; } = string.Empty;
        public string Favorit_sport { get; set; } = string.Empty;

        public bool Is_Actived { get; set; } = false;

        public string Telegram { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;

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

    //public class Image_properties: Tour_Items
    //{
    //    public Image Image_propertie0 { get; set; }
    //    public Image Image_propertie1 { get; set; }
    //    public Image Image_propertie2 { get; set; }
    //    public Image Image_propertie3 { get;set; }
    //    public Image Image_propertie4 { get; set;}
    //    public Image Image_propertie5 { get; set;}
    //}



    public class Tour_Items :Tour
    {
        public IFormFile Image_holderbg { get; set; }
        public IFormFile Image_holder1 { get; set; }
        public IFormFile Image_holder2 { get;set; }
        public IFormFile Image_holder3 {  get;set; }
        public IFormFile Image_holder4 { get; set; }
        public IFormFile Image_holder5 { get; set; }
    }


    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Is_Actived { get; set; }


        public DateTime Time { get; set; }

        [NotMapped]
        public IEnumerable<Comments> Replies { get; set; }
        [NotMapped]
        public string Tour_Name { get; set; }
        [NotMapped]
        public string Person_Name { get; set; }
        public Tour Tour { get; set; }
        public Person Person { get; set; }
        
        [ForeignKey("Comments")]
        public Nullable<int> fk_comment { set; get; }
        [ForeignKey("Tour")]
        public int fk_Tour { get; set; }
        [ForeignKey("Person")]
        public int fk_Person { get; set; }

    }

    public class Reservation
    {
        public int Id { get; set; }
       
        [NotMapped]
        public string Tour_Name { get; set; }
        [NotMapped]
        public int fk_Tour { get; set; }
        [NotMapped]
        public string Person_Name { get; set; }
        public Active_Tours Active_Tour { get; set; }
        public Person Person { get; set; }
        public bool Is_Actived { get; set; } = false;
        public int Reserved_Count { get; set; }

        [ForeignKey("Active_Tour")]
        public int fk_Active_Tour { get; set; }
        [ForeignKey("Person")]
        public int fk_Person { get; set; }
    }

    public class Images
    {
        public int Id { get; set; }
        [ForeignKey("Tour")]
        public int fk_Tour { get; set; }
        public Tour Tour { get; set; }
        public string Image_Address { get; set; }
    }


    public class Active_Tours
    {
        public int Id { get; set; }

        public Tour Tour { get; set; }
        [ForeignKey("Tour")]
        public int fk_Tour { get; set; }
        public DateOnly Start_time { get; set; }
        public DateOnly End_time { get; set; }
    }

}
