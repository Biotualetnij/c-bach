using System;

namespace holyBoly.Entities{
    public record Item{
        public Guid Id {get;init;}
        public string Name {get;init;}
        public decimal Price {get;init;}
        public string Description {get;init;}
        public string ImageUrl {get;init;}
        public DateTimeOffset CreatedDate {get;init;}

    }
}