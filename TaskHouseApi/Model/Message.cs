using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TaskHouseApi.Model
{
    public class Message : BaseModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime SendAt { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [JsonIgnore]
        public int TaskId { get; set; }

        public Message()
        {
        }
    }
}
