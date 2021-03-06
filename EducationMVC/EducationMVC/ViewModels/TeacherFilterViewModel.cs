﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EducationMVC.Models;

namespace EducationMVC.ViewModels
{
    public class TeacherFilterViewModel
    {
        public IList<Teacher> Teachers { get; set; }
        public string SearchFirstName { get; set; }
        public string SearchLastName { get; set; }
        public string SearchDegree { get; set; }
        public string SearchAcademicRank { get; set; }
    }
}
