using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Activity
    {
        public Activity() {
            Enrollments = new List<Enrollment>();
            Rooms = new List<Room>();
        }

        public Activity(Days activityDays,string description, TimeSpan duration,  DateTime finishDate,
            int maximumEnrollments, int minimumEnrollments, double price, DateTime startDate, DateTime startHour)
        {
            ActivityDays = activityDays;
            Description = description;
            Duration = duration;
            FinishDate = finishDate;
            MaximumEnrollments = maximumEnrollments;
            MinimumEnrollments = minimumEnrollments;
            Price = price;
            StartDate = startDate;
            StartHour = startHour;
            Cancelled = false;
            
            Enrollments = new List<Enrollment>();
            Rooms = new List<Room>();
        }

        //Checks if the user given is signed up to any activity
        public bool userAlreadySignedUp(User u)
        {
            foreach (Enrollment inscription in Enrollments)
            {
                if (u == inscription.User)
                {
                    return true;
                }
            }
            return false;
        }

        public Enrollment getEnrollmentById(int id)
        {
            foreach (Enrollment inscription in Enrollments)
            {
                if (inscription.Id == id)
                {
                    return inscription;
                }
            }
            return null;
        }

        //Checks if the user given is signed up to the given activity
        public bool enrolledToActivity(User u, Activity a)
        {
            foreach (Enrollment inscription in Enrollments)
            {
                if (u == inscription.User && inscription.Activity == a)
                {
                    return true;
                }
            }
            return false;
        }

        public double calculateQuota(User u, int discLocal, int discRetired, int zipcode)
        {
            double res = Price;

            if (u.ZipCode == zipcode)
            {
                res -= (double)discLocal / 100;
            }
            if (u.Retired == true)
            {
                res -= (double)discRetired / 100;
            }

            return res;
        }

    }
}
