using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using TaskHouseApi.Model.ServiceModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TaskHouseApi.Model
{
    public class User : BaseModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [JsonIgnore]
        [StringLength(60, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        [JsonIgnore]
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public string Discriminator { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
        public int LocationId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }

        public User()
        {
            RefreshTokens = new List<RefreshToken>();
            Messages = new List<Message>();
            nameOfPropertysToIgnore = new string[] { "Password", "Salt", "RefreshTokens", "Discriminator" };
        }
    }
}
