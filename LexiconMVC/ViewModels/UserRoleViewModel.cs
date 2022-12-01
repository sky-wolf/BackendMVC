﻿namespace LexiconMVC.ViewModels
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        
        public List<string> Roles { get; set; } = new List<string>();
    }
}