using System;

namespace holyBoly.Entities{
    public record User{
        public Guid Id {get;init;}
        public string FirstName {get;init;}
        public string LastName {get;init;}
        public string Email {get;init;}
        public string State {get;init;}
        public Int16 Phone {get;init;}
        public string Password {get;init;}
    }
    public record Message{
        public string message {get;init;}
        public Boolean auth {get;init;}
    }
}