using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Assessment4Apr17.Areas.Identity.Data;

// Add profile data for application users by adding properties to the EditorUser class
public class EditorUser : IdentityUser
{
    public string Name { get; set; }
}

