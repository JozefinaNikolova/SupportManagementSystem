namespace SMS.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CallSettings
    {
        public int Id { get; set; }

        [Required]
        public string SettingName { get; set; }

        [Required]
        public string SettingValue { get; set; }
    }
}
