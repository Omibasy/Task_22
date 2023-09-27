using Api_Task_22.Model.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api_Task_22.Model.Data
{
    public class PersonalData : IPersonalData
    {
        public PersonalData() { }

        public int ID { get; set; }

        [ForeignKey("PersonID")]
        public int ID_Person { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public Person PersonID { get; set; }
    }
}
