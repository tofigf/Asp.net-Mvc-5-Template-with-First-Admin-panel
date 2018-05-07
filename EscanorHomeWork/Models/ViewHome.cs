using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscanorHomeWork.Models
{
    public class ViewHome
    {
        public List<Feature> Features { get; set; }
        public About About { get; set; }
        public List<Service> Services { get; set; }
        public List<Skill> Skills { get; set; }

        public List<Category> Categories { get; set; }
        public List<Project> Projects { get; set; }

        public List<Stat> Stats { get; set; }

        public List<Package> Packages { get; set; }
        public List<Packageinfo> Packageinfos { get; set; }

        public List<Feedback> Feedbacks { get; set; }

        public List<Post> Posts { get; set; }
    }
}