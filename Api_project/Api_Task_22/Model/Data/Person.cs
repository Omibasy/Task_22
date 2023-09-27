using Api_Task_22.Model.Interface;
using System.ComponentModel.DataAnnotations;

namespace Api_Task_22.Model.Data
{
    public class Person : IPersone
    {
        public Person() { }

        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string Surname { get; set; }


        [StringLength(20)]
        public string Name { get; set; }


        [StringLength(20)]
        public string Patomic { get; set; }
    }
}
