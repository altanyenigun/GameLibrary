using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibraryApi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Username { get; set; } = string.Empty;
        public string PasswordHash {get;set;} = string.Empty;
        public string Role {get;set;} = string.Empty;
    }
}