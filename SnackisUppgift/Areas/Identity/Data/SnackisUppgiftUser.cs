﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using SnackisUppgift.Models;

namespace SnackisUppgift.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SnackisUppgiftUser class
public class SnackisUppgiftUser : IdentityUser
{
    [PersonalData]
    public int Birthyear { get; set; }

    [PersonalData]
    public string FirstName { get; set; }

    [PersonalData]
    public string LastName { get; set; }
	public ICollection<DirectMessage> MessagesSent { get; set; }
	public ICollection<DirectMessage> MessagesReceived { get; set; }
}

