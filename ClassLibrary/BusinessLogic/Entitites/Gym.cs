using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestDep.Entities
{
    public partial class Gym
    {        
        public Gym() {
            Rooms = new List<Room>();
            Activities = new List<Activity>();

        }
        public Gym(DateTime closingHour, int discountLocal,int discountRetined, double freeUserPrice, string name, DateTime openingHour, int zipCode)
        {
            ClosingHour = closingHour;
            DiscountLocal = discountLocal;
            DiscountRetired = discountRetined;
            FreeUserPrice = freeUserPrice;       
            Name = name;
            OpeningHour = openingHour;
            ZipCode = zipCode;

            Rooms = new List<Room>();
            Activities = new List<Activity>();           
        }

        public Activity getActivityById(int id)
        {
            foreach (Activity act in Activities)
            {
                if (act.Id == id)
                {
                    return act;
                }
            }
            return null;
        }
        public List<int> getIdFromFutureActivity()
        {
            List<Activity> actsFromCurrent = actFromCurrent();
            List<int> res = new List<int>();
            foreach (Activity activity in actsFromCurrent)
            {
                res.Add(activity.Id);
            }

            return res;
        }
        public List<Activity> actFromCurrent()
        {
            List<Activity> res = new List<Activity>();
            foreach (Activity activity in Activities)
            {
                if (DateTime.Now.CompareTo(activity.StartDate) <= 0)
                {
                    res.Add(activity);
                }
                else
                {
                    if (DateTime.Now.CompareTo(activity.FinishDate) < 0)
                    {
                        res.Add(activity);
                    }
                }
            }
            return res;
        }


    }
}
