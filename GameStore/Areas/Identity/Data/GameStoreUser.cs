using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace GameStore.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GameStoreUser class
public class GameStoreUser : IdentityUser
{
    public int Email { get; set; }
    public string Password { get; set; }
}

