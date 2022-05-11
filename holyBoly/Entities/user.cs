using System;

namespace holyBoly.Entities{
    public record User{
        public Guid Id {get;init;}
        public string FirstName {get;init;}
        public string LastName {get;init;}
        public string Email {get;init;}
        public string State {get;set;}
        public string Phone {get;set;}
        public string Password {get;set;}
    }

    public record UserInfo{
        public string FirstName {get;init;}
        public string LastName {get;init;}
        public string Email {get;init;}
        public string State {get;init;}
        public string Phone {get;init;}
        public string Password {get;set;}
    }
    public record Message{
        public string message {get;init;}
        public Boolean auth {get;init;}
        public UserInfo userData{get;init;}
    }
        public record UserInfoCP{
        public string FirstName {get;init;}
        public string LastName {get;init;}
        public string Email {get;init;}
        public string State {get;init;}
        public string Phone {get;init;}
        public string Password {get;set;}
         public string newPassword {get;set;}
    }
}