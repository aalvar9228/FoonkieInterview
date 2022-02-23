﻿namespace FoonkieInterview.Repository.Models.Repositories
{
    public class CaseStudy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int LaboratoryId { get; set; }

        public CaseStudy()
        {
            Image = "monkey.png";
        }
    }
}
