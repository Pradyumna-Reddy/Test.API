using System.Collections.Generic;

namespace Test.API.Data
{  
    public class Grade
    {
        public int Id { get; set; }

        public string GradeName { get; set; }

        public IList<Student> Students { get; set; }
    }
}