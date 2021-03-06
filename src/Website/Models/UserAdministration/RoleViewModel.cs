﻿using System.Collections.Generic;
using System.Web.Security;

namespace MusicCompany.Website.Models.UserAdministration
{
	public class RoleViewModel
	{
		public string Role { get; set; }
		public IEnumerable<MembershipUser> Users { get; set; }
	}
}