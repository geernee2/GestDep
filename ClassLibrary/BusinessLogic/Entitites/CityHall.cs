using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class CityHall
    {
        public CityHall()
        {
            Gyms = new List<Gym>();
            People = new List<Person>();
            Payments = new List<Payment>();
        }

        public CityHall(String name)
        {
            Name = name;
            Gyms = new List<Gym>();
            People = new List<Person>();
            Payments = new List<Payment>();
        }

        public ICollection<Instructor> getAllInstructors()
        {

            ICollection<Instructor> allInstructors = new List<Instructor>();

            foreach (var instructor in People)
            {
                if (instructor is Instructor)
                {
                    Instructor ins = (Instructor)instructor;
                    allInstructors.Add(ins);
                }

            }

            return allInstructors;
        }
        public Instructor getInstructorById(string id)
        {
            foreach (var instructor in People)
            {
                if ((instructor is Instructor ) && string.Equals(instructor.Id, id))
                {
                    return (Instructor )instructor;
                }
            }
            return null;
        }
        public User getUserById(string id)
        {
            foreach (var u in People)
            {
                if ( ( u is User) && u.Id.Equals(id))
                {
                    return (User)u;
                }
            }
            return null;
        }

        public Payment getPaymentById(int id)
        {
            foreach (Payment p in Payments)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
