using System;
using System.ComponentModel.DataAnnotations;

namespace PickUpAndPlay.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int UserProfileId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string ParkName { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string Date { get; set; }
        
        [Required]
        public string Time { get; set; }
        
        [Required]
        public int AreaId { get; set; }
        
        [Required]
        public int SkillLevelId { get; set; }
        
        [Required]
        public DateTime CreatedDateTime { get; set; }
        
        [Required]
        public bool CleatsRequired { get; set; }
        
        [Required]
        public bool WhiteAndDarkShirt { get; set; }
        
        [Required]
        public bool BarefootFriendly { get; set; }
        
        [Required]
        public bool DogsAllowed { get; set; }
        
        [Required]
        public bool PlaygroundNearby { get; set; }
        
        [Required]
        public bool BathroomsNearby { get; set; }
        
        [Required]
        public bool DrinkingWaterNearby { get; set; }
        
        [Required]
        public bool AllAges { get; set; }
        
        [Required]
        public bool EighteenPlus { get; set; }

        public Area Area { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public UserProfile UserProfile { get; set; }
    }
}
